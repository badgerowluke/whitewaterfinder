using System;
using whitewaterfinder.Repo.Weather;
using whitewaterfinder.BusinessObjects.Weather;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace whitewaterfinder.Core.Weather
{
        /*
            https://www.weather.gov/documentation/services-web-api#

            1. get location
                https://api.weather.gov/points/39.8522449,-82.8868636
            
            2. get forecast for that location
                https://api.weather.gov/gridpoints/ILN/88,76/forecast
            


            "https://api.weather.gov/gridpoints/ILN/37,37/forecast",
            "https://api.weather.gov/stations/KLUK/observations/current"
        */
    public interface IWeatherService
    {

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

        public async Task<object> GetCurrentConditions(string latitude, string longitude)
        {
            //TODO:  This needs to know what your nearest station is.
            var station = string.Empty;
            var location = await _repo.GetNWSOfficeAsync(latitude, longitude);
            var stations = await _repo.GetOfficeStations(location.CWA, location.GridX, location.GridY);

            return station;
        }
    }
}
