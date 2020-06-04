
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using whitewaterfinder.BusinessObjects.Weather;
using whitewaterfinder.Repo.Weather;
using System.Web.Http;
using System.Net;
using whitewaterfinder.Repo.Factories;

namespace whitewaterfinder.test.ForecastRepositoryTests
{
    public abstract class BaseForecastRepositoryTests
    {
        protected WeatherRepositoryConfig config;
        protected ForecastRepository repository { get; private set;}

        protected Mock<IHttpClientFactory> FactoryMock { get; private set; }

        protected FileStorageFactory fac { get; private set; }

        public BaseForecastRepositoryTests()
        {
            FactoryMock = new Mock<IHttpClientFactory>();
            fac = new FileStorageFactory("data");

            config = new WeatherRepositoryConfig
            {
                BaseNWSURL = "https://api.weather.gov",
                UserAgent = "SomeAgentDescriptor"
            };

            repository = new ForecastRepository(FactoryMock.Object, config);
        }
        
        protected HttpClient GetHttpClient(string responseContent)
        {
            var handler = new DelegatingHandlerStub((request, cancellationToken) => {
                request.SetConfiguration(new HttpConfiguration());
                var response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(responseContent);

                return Task.FromResult(response);
            });
            return new HttpClient(handler);
        } 

    }    
}