using Xunit;

using System.Net.Http;

using System.Threading.Tasks;
using Moq;


using whitewaterfinder.BusinessObjects.Weather;
using FluentAssertions;

namespace whitewaterfinder.test.ForecastRepositoryTests
{

    public class ForecastRepositoryShould: BaseForecastRepositoryTests
    {
        [Fact]
        public async Task ReturnsNWSOffice()
        {
            var content = fac.Get("weatherdata.json");

            FactoryMock.Setup(f => f.CreateClient(It.IsAny<string>()))
                        .Returns(GetHttpClient(content));

            var stuff = await repository.GetNWSOfficeAsync("41.782", "-80.858");

            stuff.Should().NotBeNull().And
                            .BeOfType(typeof(NWSLocation));

        }
    }
}