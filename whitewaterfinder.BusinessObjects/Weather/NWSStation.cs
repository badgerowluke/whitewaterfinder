namespace whitewaterfinder.BusinessObjects.Weather
{
    public class NWSStation
    {
        public string Id { get; set; }

        public string Name 
        {
            get
            {
                return Id.Split('/')[Id.Split('/').Length];
            }
        }
        public string Type { get; set; }
        public NWSGeometry Geometry { get; set; }
        public NWSStationProperties Properties { get; set; }
        
    }

    public class NWSStationProperties 
    {
        public string StationIdentifier { get; set; }
        public string Name { get; set; }
        public string Timezone { get; set; }
        public NWSObservation Elevation { get; set; }

    }

    public class NWSGeometry
    {
        public string Type { get; set; }

        public double[] Coordinates{ get; set; }
    }
}