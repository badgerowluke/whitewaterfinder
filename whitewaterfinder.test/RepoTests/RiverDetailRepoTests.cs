using Xunit;
using whitewaterfinder.Repo.Factories;
using whitewaterfinder.Repo;
using Newtonsoft.Json;
using whitewaterfinder.BusinessObjects.USGSResponses;

namespace whitewaterfinder.test {

    public class RiverDetailRepositoryTests {
        [Fact]
        public void WeDoGetDetailRepository()
        {
            var detail = new RiverDetailRepository();
            Assert.NotNull(detail);
        }

    }

}