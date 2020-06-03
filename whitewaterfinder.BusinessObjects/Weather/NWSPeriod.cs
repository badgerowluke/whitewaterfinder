using System;
namespace whitewaterfinder.BusinessObjects.Weather
{
    public class NWSPeriod
    {
        public int Number { get; set; }

        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool isDaytime { get; set; }
        public int Temperature { get; set; }
        public string TempUnits { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string ShoreForecast { get; set; }
        public string DetailedForecast { get; set; }
    }
}