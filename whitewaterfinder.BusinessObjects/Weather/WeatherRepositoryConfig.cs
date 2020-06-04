namespace whitewaterfinder.BusinessObjects.Weather
{
    public class WeatherRepositoryConfig
    {
        public string BaseNWSURL { get; set; }
        public string UserAgent { get; set; }
        public string JsonDecodeProperty { get; set; }
        public string JsonDecodeProperty2 { get; set; }
    }
}