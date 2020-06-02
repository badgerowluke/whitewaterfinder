using System;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using whitewaterfinder.BusinessObjects.Weather;

namespace whitewaterfinder.Repo.Weather
{
    public interface IWeatherRepository
    {
        Task<NWSLocation> GetNWSLocationAsync(string latitude, string longitude);
    }

    public class WeatherRepository : IWeatherRepository
    {
        private readonly HttpClient _client;
        public WeatherRepository(HttpClient client)
        {
            _client = client;
        }
        
        public async Task<NWSLocation> GetNWSLocationAsync(string latitude, string longitude)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, 
            $"https://api.weather.gov/points/{latitude},{longitude}");
            request.Headers.Add("User-Agent", "(paddle-finder.com, badgerow.luke@outlook.com)");
            using(var response = await _client.SendAsync(request))
            {
                var data = await response.Content.ReadAsStringAsync();
                var objs = JObject.Parse(data);
                var vals = objs["properties"];

                return vals.ToObject<NWSLocation>();

            }
        }

    }
}