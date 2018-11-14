using System;
using System.Linq;
using System.Collections.Generic;

namespace whitewaterfinder.BusinessObjects.Rivers
{
    public static class RiverExtensions
    {
        public static RiverData[] PopulateRiverData(this River river)
        {
            var riverData = new List<RiverData>();
            if((river.Flow != null && river.Flow.Count() > 0) && river.Levels != null){
                foreach(var point in river.Flow){
                    // point.Level = river.Levels.FirstOrDefault(x => x.DateTime == point.DateTime).Value.ToString();
                    riverData.Add(point);
                }
                // river.Flow = null;
                // river.Levels = null;
            } else if(river.Flow != null && river.Flow.Count() > 0){
                foreach (var point in river.Flow) {
                    riverData.Add(point);
                }
                // river.Flow = null;
            } else if(river.Levels != null && river.Levels.Count() > 0){
                foreach (var point in river.Levels ) {
                    riverData.Add(point);
                }
                // river.Levels = null;
            }
            return riverData.ToArray();
        }
    }
}