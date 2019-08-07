using Xunit;
using Moq;
using whitewaterfinder.Repo.Factories;
using whitewaterfinder.Repo;
using Newtonsoft.Json;
using whitewaterfinder.BusinessObjects.USGSResponses;
using System.Net.Http;

namespace whitewaterfinder.test {

    public class RiverDetailRepositoryTests {
        [Fact]
        public void WeDoGetDetailRepository()
        {
            var http = new Mock<HttpClient>();
            var detail = new RiverDetailRepository(http.Object);
            Assert.NotNull(detail);
        }

    }

}