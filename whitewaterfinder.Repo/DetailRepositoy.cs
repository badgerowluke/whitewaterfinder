using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.BusinessObjects.USGSResponses;
using whitewaterfinder.BusinessObjects.Enumerations;
using whitewaterfinder.BusinessObjects;
namespace whitewaterfinder.Repo
{
    public interface IRiverDetailRepository
    {
        Task<River> GetRiverDetailsAsync(string riverCode);
    }   
    public class RiverDetailRepository : IRiverDetailRepository
    {
        public RiverDetailRepository()
        {
            
        }
        public async Task<River> GetRiverDetailsAsync(string riverCode)
        {
            var river = new River();
            using(HttpClient client = new HttpClient()) 
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, 
                "https://waterservices.usgs.gov/nwis/iv/?format=json&indent=on&sites="
                + riverCode +"&period=P1D&parameterCd=00065,00060&siteStatus=all");

                
                using(HttpResponseMessage outstuff = await client.SendAsync(request)){
                    var vals = outstuff.Content.ReadAsStringAsync().Result;
                    USGSRiverResponse obj = JsonConvert.DeserializeObject<USGSRiverResponse>(vals);
                    
                    if(obj.Value.TimeSeries.Length > 0)
                    {
                        river = new River() 
                        {
                            RiverName = obj.Value.TimeSeries[0].SourceInfo.SiteName,
                            Latitude = obj.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.Latitude,
                            Longitude = obj.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.Longitude,
                            Srs = obj.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.SRS,
                            RiverId = obj.Value.TimeSeries[0].SourceInfo.SiteCode[0].Value
                        };

                        var riverData = new List<RiverData>();

                        river.Flow = obj.ParseTimeSeriesData(TimeSeriesTypes.CubicFeet);
                        river.Levels = obj.ParseTimeSeriesData(TimeSeriesTypes.GuageHeight);

                        river.RiverData = river.PopulateRiverData();

                    }

                    return river;

                }
            }
        }

    } 
}