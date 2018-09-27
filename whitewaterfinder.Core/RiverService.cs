using System;
using System.Collections.Generic;
using System.Linq;

using whitewaterfinder.Repo;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.BusinessObjects;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace whitewaterfinder.Core
{
    public interface IRiverService 
    {
        IEnumerable<River> GetRivers(string partName);
        Task<River> GetRiverDetails(string riverCode);
    }
    public class RiverService : IRiverService
    {
        private readonly IRiverRepository repo;
        private readonly IRiverDetailRepository detail;
        public RiverService(IRiverRepository riverRep, IRiverDetailRepository _details)
        {
            repo = riverRep;
            detail = _details;
        }
        public IEnumerable<River> GetRivers(string partName)
        {
            return repo.GetAllUSRivers(partName);
        }
        public async Task<River> GetRiverDetails(string riverCode)
        {
            var river = detail.GetRiverDetailsAsync(riverCode).Result;
            using(HttpClient client = new HttpClient()) 
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, 
                "https://waterservices.usgs.gov/nwis/iv/?format=json&indent=on&sites="
                + riverCode +"&period=P1D&parameterCd=00065,00060&siteStatus=all");

                
                using(HttpResponseMessage outstuff = await client.SendAsync(request)){
                    var vals = outstuff.Content.ReadAsStringAsync().Result;
                    USGSRiverResponse obj = JsonConvert.DeserializeObject<USGSRiverResponse>(vals);
                    
                    river = new River() {
                        Name = obj.Value.TimeSeries[0].SourceInfo.SiteName,
                        Latitude = obj.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.Latitude,
                        Longitude = obj.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.Longitude,
                        Srs = obj.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.SRS,
                        RiverId = obj.Value.TimeSeries[0].SourceInfo.SiteCode[0].Value
                    };

                }

            }


            // var riverData = new List<RiverData>();

            // foreach (var dataSet in obj.Value.TimeSeries) {
            //     var units = dataSet.Variable.unit.UnitCode;
            //     var dataVals = dataSet.Values;

            //     switch (units) {
            //         case ("ft3/s"):
            //             river.Flow = ProcessRiverData(dataVals[0], units);
            //             break;
            //         case ("ft"):
            //             river.Levels = ProcessRiverData(dataVals[0], units);
            //             break;
            //     }
            // }
            // if((river.Flow != null && river.Flow.Count() > 0) && river.Levels != null){
            //     foreach(var point in river.Flow){
            //         point.Level = river.Levels.FirstOrDefault(x => x.DateTime == point.DateTime).Value.ToString();
            //         riverData.Add(point);
            //     }
            //     // river.Flow = null;
            //     // river.Levels = null;
            // } else if(river.Flow != null && river.Flow.Count() > 0){
            //     foreach (var point in river.Flow) {
            //         riverData.Add(point);
            //     }
            //     river.Flow = null;
            // } else if(river.Levels != null && river.Levels.Count() > 0){
            //     foreach (var point in river.Levels ) {
            //         riverData.Add(point);
            //     }
            //     river.Levels = null;
            // }

            // river.RiverData = riverData.ToArray();
            return river;
        }
        private RiverData[] ProcessRiverData(USGSRiverDataValueCollection dataSet, string units) {
            var dataList = new List<RiverData>();


            foreach (var val in dataSet.Value) {
                var data = new RiverData();
                if(units.Equals("ft")){
                    data = new RiverData() { DateTime = DateTime.Parse(val.DateTime), Value = val.Value, Level = val.Value, Flow = null };
					dataList.Add(data);
                } else {
					data = new RiverData() { DateTime = DateTime.Parse(val.DateTime), Flow = val.Value, Level = null };
					dataList.Add(data);
                }
            }
            return dataList.ToArray();
        }
    }
}