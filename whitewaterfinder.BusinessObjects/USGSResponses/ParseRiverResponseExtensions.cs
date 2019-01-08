using System;
using System.Collections.Generic;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.BusinessObjects.Enumerations;

namespace whitewaterfinder.BusinessObjects.USGSResponses
{
    public static class RiverResponseExtensions
    {
        public static RiverData[] ParseTimeSeriesData(this USGSRiverResponse response, TimeSeriesTypes type)
        {
            foreach (var dataSet in response.Value.TimeSeries) {
                var units = dataSet.Variable.unit.UnitCode;
                var dataVals = dataSet.Values;

                switch (units) {
                    case ("ft3/s"):
                        if(type == TimeSeriesTypes.CubicFeet) {
                            return ProcessRiverData(dataVals[0], units);
                        } else {
                            break;
                        }
                    case ("ft"):
                        if(type == TimeSeriesTypes.GuageHeight) {
                            return ProcessRiverData(dataVals[0], units);
                        } else {
                            break;
                        }
                }
            }
            return new List<RiverData>().ToArray();
        }
        private static RiverData[] ProcessRiverData(USGSRiverDataValueCollection dataSet, string units) {
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
        public static River ParseTimeSeriesData(this USGSRiverResponse response)
        {
            return new River() 
            {
                Name = response.Value.TimeSeries[0].SourceInfo.SiteName,
                Latitude = response.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.Latitude,
                Longitude = response.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.Longitude,
                Srs = response.Value.TimeSeries[0].SourceInfo.Geolocation.GeogLocation.SRS,
                RiverId = response.Value.TimeSeries[0].SourceInfo.SiteCode[0].Value
            };
        }
    }
}