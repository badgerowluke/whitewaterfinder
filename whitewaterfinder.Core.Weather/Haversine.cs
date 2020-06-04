namespace whitewaterfinder.Core.Weather
{
    using System;
    ///<summary>Calculate the Euclidian distance between two points</summary>
    public class Haversine
    {
        private const double R = 6371e3;

        private double _latitude1;
        private double _longitude1;
        private double _latitude2;
        private double _longitude2;

        ///<summary>The distance between the two points in</summary>
        public double Distance
        {
            get
            {
                return R * C;
            }
        } 

        public Haversine(double lat1, double long1, double lat2, double long2)
        {
            _latitude1 = lat1 * Math.PI/180;//to radians
            _latitude2 = lat2 * Math.PI/180;//to radians
            _longitude1 = long1;
            _longitude2 = long2;

        }


        private double DeltaLat 
        {
            get
            {
                return (_latitude2 - _latitude1);
            }
        }

        private double DeltaLong 
        {
            get
            {
                return (_longitude2 - _longitude1) * Math.PI/180;//to radians
            }
        }


        private double A
        {
            get
            {
            return (Math.Sin(DeltaLat/2) * Math.Sin(DeltaLat/2)) 
                    + Math.Cos(_latitude1) * Math.Cos(_latitude2)
                    * (Math.Sin(DeltaLong/2) * Math.Sin(DeltaLong/2));

            }
        
        }
        
        private double C
        {
            get
            {
                return 2 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1-A));
            }
        }
    }
}