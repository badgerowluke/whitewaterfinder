using Xunit;

using System.Net.Http;

using System.Threading.Tasks;
using Moq;


using whitewaterfinder.BusinessObjects.Weather;
using FluentAssertions;
using System.Collections.Generic;

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
        [Fact]
        public async Task ReturnsArrayOfNWSStations()
        {
            var content = fac.Get("stations.json");
            FactoryMock.Setup(f => f.CreateClient(It.IsAny<string>()))
                        .Returns(GetHttpClient(content));
            
            var stuff = await repository.GetOfficeStations("ILN", "88", "76");
            stuff.Should().NotBeNull()
                    .And.HaveCount(c => c > 0);
        }
    }
}