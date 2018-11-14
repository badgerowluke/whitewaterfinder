using Xunit;
using whitewaterfinder.Repo.Factories;
using whitewaterfinder.BusinessObjects.USGSResponses;
namespace whitewaterfinder.test.BusinessobjectsTests
{
    public class USGSParserTests 
    {
        [Fact]
        public void DoesParseTheUSGSResponse()
        {
            var fac = new FileStorageFactory("data");
            var response = fac.Get<USGSRiverResponse>("riverdata.json");
            var flows = response.PaseTimeSeriesData();
            Assert.Equal(0, flows.Length);
        }
        [Fact]
        public void DoesParse_USGSResponse_HasGaugeHeightData()
        {
            var fac = new FileStorageFactory("data");
            var response = fac.Get<USGSResponse>("riverdata.json");
            var levels = response.ParseTimeSeriesData();
            
        }
    }
}