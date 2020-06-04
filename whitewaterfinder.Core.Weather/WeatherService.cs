using System;
using whitewaterfinder.Repo.Weather;
using whitewaterfinder.BusinessObjects.Weather;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using whitewaterfinder.Core.Weather.Extensions;

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

            var location = await _repo.GetNWSOfficeAsync(latitude, longitude);
            var stations = await _repo.GetOfficeStations(location.CWA, location.GridX, location.GridY);

            var station = stations.NearestObservationStation(latitude, longitude);

            return await _repo.GetCurrentConditions(station.Properties.StationIdentifier);
        }
    }
}
