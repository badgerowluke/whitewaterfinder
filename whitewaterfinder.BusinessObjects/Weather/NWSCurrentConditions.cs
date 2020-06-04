using System;

namespace whitewaterfinder.BusinessObjects.Weather
{
    public class NWSCurrentConditions
    {
        public DateTime Timestamp { get; set; }

        public string TextDescription { get; set; }
        public NWSObservation HeatIndex { get; set; }
        public NWSObservation WindChill { get; set; }
        public NWSObservation RelativeHumidity { get; set; }
        public NWSObservation PrecipationLast6Hours { get; set; }
        public NWSObservation PrecipationLast3Hours { get; set; }
        public NWSObservation PrecipitationLastHour { get; set; }
        public NWSObservation MinTemperatureLast24Hours { get; set; }
        public NWSObservation MaxTemperatureLast24Hours { get; set; }
        public NWSObservation Visibility { get; set; }
        public NWSObservation SeaLevelPressure { get; set; }
        public NWSObservation BarometricPressure { get; set; }
        public NWSObservation WindGust { get; set; }
        public NWSObservation WindSpeed { get; set; }
        public NWSObservation WindDirection { get; set; }
        public NWSObservation Dewpoint { get; set; }
        public NWSObservation Temperature { get; set; }

    }
    
    public class NWSObservation
    {
        public decimal? Value { get; set; }
        public string UnitCode { get; set; }
        public string QualityControl { get; set; }
    }
}