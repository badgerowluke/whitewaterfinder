using System;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using whitewaterfinder.BusinessObjects.Weather;
using System.Collections.Generic;

namespace whitewaterfinder.Repo.Weather
{
    public interface IForecastRepository
    {
        Task<NWSLocation> GetNWSOfficeAsync(string latitude, string longitude);
        Task<IEnumerable<NWSPeriod>> GetForecast(string url);
        Task<IEnumerable<NWSPeriod>> GetForecast(string station, string gridX, string gridY);
    }

    public class ForecastRepository :  IForecastRepository
    {
        private readonly IHttpClientFactory _factory;
        private readonly WeatherRepositoryConfig _config;

        public ForecastRepository(IHttpClientFactory client, WeatherRepositoryConfig config)
        {
            _factory = client;
        }

        public async Task<NWSLocation> GetNWSOfficeAsync(string latitude, string longitude)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, 
            $"{_config.BaseNWSURL}/points/{latitude},{longitude}");
            request.Headers.Add("User-Agent", "(paddle-finder.com, badgerow.luke@outlook.com)");
            var client = _factory.CreateClient();
            var response = await client.SendAsync(request);

            var data = await response.Content.ReadAsStringAsync();
            var objs = JObject.Parse(data);
            var vals = objs["properties"];

            return vals.ToObject<NWSLocation>();

        }   
        
        public async Task<IEnumerable<NWSPeriod>> GetForecast(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent", "(paddle-finder.com, badgerow.luke@outlook.com)");
            var client = _factory.CreateClient();
            var response = await client.SendAsync(request);
            
            return await ProcessForecastResponse<IEnumerable<NWSPeriod>>(response);

        }

        public async Task<IEnumerable<NWSPeriod>> GetForecast(string station, string gridX, string gridY)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, 
            $"{_config.BaseNWSURL}/gridpoints/{station}/{gridX},{gridY}/forecast");
            request.Headers.Add("User-Agent", "(paddle-finder.com, badgerow.luke@outlook.com)");
            var client = _factory.CreateClient();
            var response = await client.SendAsync(request);

            return await ProcessForecastResponse<IEnumerable<NWSPeriod>>(response);
        }

        private async Task<T> ProcessForecastResponse<T>(HttpResponseMessage message)
        {
            var data = await message.Content.ReadAsStringAsync();
            var objs = JObject.Parse(data);
            var vals = objs["properties"]["periods"];

            return vals.ToObject<T>();
        }

        public async Task<NWSCurrentConditions> GetCurrentConditions(string station)
        {
            
            var request = new HttpRequestMessage(HttpMethod.Get, 
            $"{_config.BaseNWSURL}/stations/{station}/observations/current");

            var client = _factory.CreateClient();

            var response = await client.SendAsync(request);
            
            return null;
        }

    }
}