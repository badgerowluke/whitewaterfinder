using System;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using whitewaterfinder.BusinessObjects.Weather;
using System.Collections.Generic;
using whitewaterfinder.Repo.Extensions;

namespace whitewaterfinder.Repo.Weather
{
    public interface IForecastRepository
    {
        Task<NWSLocation> GetNWSOfficeAsync(string latitude, string longitude);
        Task<IEnumerable<NWSStation>> GetOfficeStations(string station, string gridX, string gridY);
        Task<IEnumerable<NWSPeriod>> GetForecast(string url);
        Task<IEnumerable<NWSPeriod>> GetForecast(string station, string gridX, string gridY);
        Task<NWSCurrentConditions> GetCurrentConditions(string station);

    }

    public class ForecastRepository :  IForecastRepository
    {
        private readonly IHttpClientFactory _factory;
        private readonly WeatherRepositoryConfig _config;

        public ForecastRepository(IHttpClientFactory client, WeatherRepositoryConfig config)
        {
            _factory = client;
            _config = config;
        }

        internal async Task<T> MakeThatHttpCall<T>(HttpRequestMessage message, string prop1, string prop2 = "", string prop3 = "")
        {
            var client = _factory.CreateClient();
            var response = await client.SendAsync(message);
            var data = await response.Content.ReadAsStringAsync();
            var objs = JObject.Parse(data);

            var vals = objs.ParseByIndexes(prop1, prop2, prop3);

            return vals.ToObject<T>();
        }

        public async Task<NWSLocation> GetNWSOfficeAsync(string latitude, string longitude)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, 
            $"{_config.BaseNWSURL}/points/{latitude},{longitude}");
            request.Headers.Add("User-Agent", _config.UserAgent);
            
            return await MakeThatHttpCall<NWSLocation>(request, "properties");
        }  

        public async Task<IEnumerable<NWSStation>> GetOfficeStations(string station, string gridX, string gridY)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, 
            $"{_config.BaseNWSURL}/gridpoints/{station}/{gridX},{gridY}/stations");
            request.Headers.Add("User-Agent", _config.UserAgent);

            return await MakeThatHttpCall<IEnumerable<NWSStation>>(request, "features");
        }         
        
        public async Task<IEnumerable<NWSPeriod>> GetForecast(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent", _config.UserAgent);

            return await MakeThatHttpCall<IEnumerable<NWSPeriod>>(request, "properties", "periods");

        }

        public async Task<IEnumerable<NWSPeriod>> GetForecast(string station, string gridX, string gridY)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, 
            $"{_config.BaseNWSURL}/gridpoints/{station}/{gridX},{gridY}/forecast");
            request.Headers.Add("User-Agent", _config.UserAgent);

            return await MakeThatHttpCall<IEnumerable<NWSPeriod>>(request, "properties", "periods");
        }

        public async Task<NWSCurrentConditions> GetCurrentConditions(string station)
        {
            
            var request = new HttpRequestMessage(HttpMethod.Get, 
            $"{_config.BaseNWSURL}/stations/{station}/observations/current");
            
            return await MakeThatHttpCall<NWSCurrentConditions>(request, "properties");
        }
    }
}