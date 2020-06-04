using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;
using whitewaterfinder.BusinessObjects.Weather;
using System.Collections.Generic;

namespace whitewaterfinder.test.WeatherServiceTests
{

    public class GetCurrentConditionsShould : BaseWeatherServiceTest
    {
        [Fact]
        public async Task DoStuff()
        {
            string passedVal = string.Empty;

            Repo.Setup(c => c.GetNWSOfficeAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new NWSLocation
                {
                    CWA = "ILN",
                    GridX = "88", 
                    GridY = "76"
                });

            Repo.Setup(c => c.GetOfficeStations(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new List<NWSStation>
                {
                    new NWSStation
                    {
                        Geometry = new NWSGeometry
                        {
                            Coordinates =  new double[]{ -82.9333, 39.81667 }
                        },
                        Properties = new NWSStationProperties 
                        {
                            StationIdentifier = "KLCK"
                        }
                    },
                    new NWSStation
                    {
                        Geometry = new NWSGeometry
                        {
                            Coordinates = new double[]{ -84.41583, 39.105829}
                        },
                        Properties = new NWSStationProperties
                        {
                            StationIdentifier = "KLUK"
                        }
                    }
                });
            Repo.Setup(c => c.GetCurrentConditions(It.IsAny<string>()))
                .Callback<string>((val) => passedVal = val);


            var conditions = await sut.GetCurrentConditions("39.198", "-84.392");
            passedVal.Should().Be("KLUK");

        }
    }
}