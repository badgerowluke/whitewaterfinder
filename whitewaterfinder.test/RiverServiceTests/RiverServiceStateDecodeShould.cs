using System.Collections.Generic;
using whitewaterfinder.BusinessObjects.Rivers;
using Xunit;
using Moq;
using System.Threading.Tasks;

namespace whitewaterfinder.Core.test.RiverServiceTests
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
        [Fact]
        public async void ReturnAnEnumerableOfRiverWithPartialName()
        {
            MockRiverRepo.Setup(m =>  m.GetRiversAsync(It.IsAny<string>())).ReturnsAsync(new List<River>());
            var vals = await service.GetRivers("gaul");
            Assert.IsType<List<River>>(vals);
        }
        [Fact] 
        public async void ReturnsAnEnumerableOfRiverWithStateCode()
        {
            MockRiverRepo.Setup(m =>  m.GetRiversByState(It.IsAny<string>())).ReturnsAsync(new List<River>());
            var vals = await service.GetRivers("MD");
            Assert.IsType<List<River>>(vals);

        }
        [Fact]
        public async void ReturnsAnEnumerableOfRiversWithEmptyString()
        {
            MockRiverRepo.Setup(m =>  m.GetRivers()).Returns(new List<River>());
            var vals = await service.GetRivers(string.Empty);
            Assert.IsType<List<River>>(vals);

        }
        [Fact]
        public async Task ReturnRiverDetails()
        {
            MockDetailRepo.Setup(m => m.GetRiverDetailsAsync(It.IsAny<string>())).ReturnsAsync(new River());
            var vals = await service.GetRiverDetails("4444444");
            Assert.IsType<River>(vals);
        }


    }

}