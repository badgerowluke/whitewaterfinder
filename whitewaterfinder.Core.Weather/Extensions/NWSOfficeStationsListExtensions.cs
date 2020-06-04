using System;
using System.Linq;
using System.Collections.Generic;
using whitewaterfinder.BusinessObjects.Weather;

namespace whitewaterfinder.Core.Weather.Extensions
{
    public static class NWSOfficeStationsListExtensions
    {
        public static NWSStation NearestObservationStation(this IEnumerable<NWSStation> stations, string latitude, string longitude)
        {
            var station = string.Empty;
            var map = new SortedDictionary<double, string>();
            foreach(var site in stations)
            {
                var stationName = site.Properties.StationIdentifier;
                var coords = site.Geometry.Coordinates;
                var distance = new Haversine(Convert.ToDouble(latitude), 
                                            Convert.ToDouble(longitude), 
                                            coords[1], 
                                            coords[0]).Distance;
                map.Add(distance, stationName);
            }
            station = map.First().Value;

            return stations.FirstOrDefault(s => s.Properties.StationIdentifier.Equals(station));
        }
    }
}