using Xunit;
namespace whitewaterfinder.test.RiverServiceTests
{
    public class RiverServiceStateDecodeShould : BaseRiverServiceTests
    {
        [Fact]
        public void ReturnAString()
        {
            var val = service.GetStateCode("OH");
            Assert.IsType<string>(val);
        }
        [Fact]
        public void ReturnEmptyWhenNoMatch()
        {
            var val = service.GetStateCode("XX");
            Assert.Equal(string.Empty, val);
        }
        [Fact]
        public void CheckThatUserDidnotTypeStateName()
        {
            var val = service.GetStateCode("West Virginia");
            Assert.Equal("WV", val);
        }

    }

}