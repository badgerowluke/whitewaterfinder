using System;
using System.Collections.Generic;
using whitewaterfinder.BusinessObjects.Rivers;

namespace whitewaterfinder.BusinessObjects.USGSResponses
{
    public static class RiverResponseExtensions
    {
        public static RiverData[] DoStuff(this USGSRiverResponse response)
        {
            foreach (var dataSet in response.Value.TimeSeries) {
                var units = dataSet.Variable.unit.UnitCode;
                var dataVals = dataSet.Values;

                switch (units) {
                    case ("ft3/s"):
                        return ProcessRiverData(dataVals[0], units);
                    case ("ft"):
                        return ProcessRiverData(dataVals[0], units);
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
    }
}