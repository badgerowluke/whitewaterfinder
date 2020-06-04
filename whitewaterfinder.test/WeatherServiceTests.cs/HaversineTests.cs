using Xunit;
using FluentAssertions;
using whitewaterfinder.Core.Weather;

namespace whitewaterfinder.test.WeatherServiceTests
{
    public class HaversineValuesShould
    {
        [Fact]
        public void ReturnAppropriateDistanceBetweenPoints()
        {
            var have = new Haversine(39.198, -84.392, 41.782, -80.858);
            have.Distance.Should().Be(414501.90604456037);
        }
    }
}