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
        public async Task DetermineTheAppropriateObservationStationForGivenCoordinates()
        {
            string passedVal = string.Empty;

            Repo.Setup(c => c.GetNWSOfficeAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(NWSOffice);

            Repo.Setup(c => c.GetOfficeStations(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(ObservationStations);


            Repo.Setup(c => c.GetCurrentConditions(It.IsAny<string>()))
                .Callback<string>((val) => passedVal = val);


            var conditions = await sut.GetCurrentConditions("39.198", "-84.392");
            passedVal.Should().Be("KLUK");

        }
    }
}