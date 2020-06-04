using System;
using whitewaterfinder.Repo.Weather;
using whitewaterfinder.BusinessObjects.Weather;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace whitewaterfinder.Core.Weather
{
    public interface IWeatherService
    {
        Task<IEnumerable<NWSPeriod>> GetForecast(string latitude, string longitude);
        Task<NWSCurrentConditions> GetCurrentConditions(string latitude, string longitude);
    }

    public class WeatherService : IWeatherService
    {
        private readonly IForecastRepository _repo;
        public WeatherService(IForecastRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<IEnumerable<NWSPeriod>> GetForecast(string latitude, string longitude)
        {
            var location = await _repo.GetNWSOfficeAsync(latitude, longitude);

            if(!string.IsNullOrEmpty(location.Forecast))
            {
                return await _repo.GetForecast(location.Forecast);
            } 
            if(!string.IsNullOrEmpty(location.CWA) 
                && !string.IsNullOrEmpty(location.GridX) 
                && !string.IsNullOrEmpty(location.GridY))
            {
                return await _repo.GetForecast(location.CWA, location.GridX, location.GridY);
            }
    
            return null;
        }

        public async Task<NWSCurrentConditions> GetCurrentConditions(string latitude, string longitude)
        {
            //TODO:  This needs to know what your nearest station is.
            var station = string.Empty;
            var location = await _repo.GetNWSOfficeAsync(latitude, longitude);
            var stations = await _repo.GetOfficeStations(location.CWA, location.GridX, location.GridY);

            var map = new SortedDictionary<double, string>();
            foreach(var site in stations)
            {
                var stationName = site.Properties.StationIdentifier;
                var coords = site.Geometry.Coordinates;
                var distance = new Haversine(Convert.ToDouble(latitude), 
                                            Convert.ToDouble(longitude), 
                                            coords[1], 
                                            coords[0]).Distance;
                map.Add(distance, stationName);
            }
            station = map.First().Value;

            var conditions = await _repo.GetCurrentConditions(station);

            return conditions;
        }
    }
}
