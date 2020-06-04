using Moq;
using whitewaterfinder.Repo.Weather;
using whitewaterfinder.Core.Weather;

namespace whitewaterfinder.test.WeatherServiceTests
{
    public abstract class BaseWeatherServiceTest
    {
        protected Mock<IForecastRepository> Repo;

        protected WeatherService sut;
        public BaseWeatherServiceTest()
        {
            Repo = new Mock<IForecastRepository>();

            sut = new WeatherService(Repo.Object);
        }
    }    
}