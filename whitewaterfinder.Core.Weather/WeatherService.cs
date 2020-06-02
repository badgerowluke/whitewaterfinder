using System;

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
        public WeatherService()
        {
            
        }
        public object GetForecast(string latitude, string longitude)
        {
            /*
            1. 
            */
            return null;
        }

        public object GetCurrentConditions(string latitude, string longitude)
        {
            return null;
        }
    }
}
