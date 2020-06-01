using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.BusinessObjects.USGSResponses;
using whitewaterfinder.BusinessObjects.Enumerations;
using whitewaterfinder.BusinessObjects.Configuration;

namespace whitewaterfinder.Repo.Rivers
{
    public interface IRiverDetailRepository
    {
        Task<River> GetRiverDetailsAsync(string riverCode);
        void Register(RiverRepositoryConfig configVals);
    }   
    public class RiverDetailRepository : IRiverDetailRepository
    {
        private readonly HttpClient _client;
        private string _usgsUrl;
        public RiverDetailRepository(HttpClient client)
        {
            _client = client;
        }
        public void Register(RiverRepositoryConfig configVals)
        {
            _usgsUrl = configVals.BaseUSGSURL + "sites=";
        }
        
        public async Task<River> GetRiverDetailsAsync(string riverCode)
        {
            var river = new River();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, 
            _usgsUrl
            + riverCode +"&period=P1D&parameterCd=00065,00060&siteStatus=all");

            
            using(HttpResponseMessage outstuff = await _client.SendAsync(request)){
                var vals = outstuff.Content.ReadAsStringAsync().Result;
                USGSRiverResponse obj = JsonConvert.DeserializeObject<USGSRiverResponse>(vals);
                
                if(obj.Value.TimeSeries.Length > 0)
                {
                    river = new River() 
                    {
                        Name = obj.Value.TimeSeries[0].SourceInfo.SiteName,
                        Latitude = obj.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.Latitude,
                        Longitude = obj.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.Longitude,
                        Srs = obj.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.SRS,
                        RiverId = obj.Value.TimeSeries[0].SourceInfo.SiteCode[0].Value
                    };



                    river.Flow = obj.ParseTimeSeriesData(TimeSeriesTypes.CubicFeet);
                    river.Levels = obj.ParseTimeSeriesData(TimeSeriesTypes.GuageHeight);

                    river.RiverData = river.PopulateRiverData();

                }

                return river;

            }

        }

    } 
}