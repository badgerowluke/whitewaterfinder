namespace whitewaterfinder.BusinessObjects.Weather
{
    public class NWSStation
    {
        public string Id { get; set;}
        public string Type { get; set; }
        public NWSGeometry Geometry { get; set; }
    }

    public class NWSGeometry
    {
        public string Type { get; set; }

        public decimal[] Coordinates{ get; set; }
    }
}