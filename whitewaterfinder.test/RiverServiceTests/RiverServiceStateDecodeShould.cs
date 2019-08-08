using System.Collections.Generic;
using whitewaterfinder.BusinessObjects.Rivers;
using Xunit;
using Moq;
using System.Threading.Tasks;

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
        [Fact]
        public  void ReturnAnEnumerableOfRiverWithPartialName()
        {
            MockRiverRepo.Setup(m =>  m.GetRiversAsync(It.IsAny<string>())).ReturnsAsync(new List<River>());
            var vals = service.GetRivers("gaul");
            Assert.IsType<List<River>>(vals);
        }
        [Fact] 
        public void ReturnsAnEnumerableOfRiverWithStateCode()
        {
            MockRiverRepo.Setup(m =>  m.GetRiversByState(It.IsAny<string>())).Returns(new List<River>());
            var vals = service.GetRivers("MD");
            Assert.IsType<List<River>>(vals);

        }
        [Fact]
        public void ReturnsAnEnumerableOfRiversWithEmptyString()
        {
            MockRiverRepo.Setup(m =>  m.GetRivers()).Returns(new List<River>());
            var vals = service.GetRivers(string.Empty);
            Assert.IsType<List<River>>(vals);

        }
        [Fact]
        public void ReturnRiverDetails()
        {
            MockDetailRepo.Setup(m => m.GetRiverDetailsAsync(It.IsAny<string>())).ReturnsAsync(new River());
            var vals = service.GetRiverDetails("4444444");
            Assert.IsType<River>(vals);
        }


    }

}