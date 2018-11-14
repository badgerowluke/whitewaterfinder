using Xunit;
using whitewaterfinder.Repo.Factories;
using whitewaterfinder.BusinessObjects.USGSResponses;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.BusinessObjects.Enumerations;
namespace whitewaterfinder.test.BusinessobjectsTests
{
    public class USGSParserTests 
    {
        [Fact]
        public void DoesParseTheUSGSResponse()
        {
            var fac = new FileStorageFactory("data");
            var response = fac.Get<USGSRiverResponse>("riverdata.json");
            
            var flows = response.ParseTimeSeriesData(TimeSeriesTypes.CubicFeet);
            
            Assert.Empty(flows);
        }
        [Fact]
        public void DoesParse_USGSResponse_HasGaugeHeightData()
        {
            var fac = new FileStorageFactory("data");
            var response = fac.Get<USGSRiverResponse>("riverdata.json");

            var levels = response.ParseTimeSeriesData(TimeSeriesTypes.GuageHeight);
            Assert.NotEmpty(levels);
        }

    }
}