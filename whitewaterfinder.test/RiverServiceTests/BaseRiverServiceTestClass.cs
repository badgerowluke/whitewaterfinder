using Moq;
using whitewaterfinder.Core;
using whitewaterfinder.Repo;

namespace whitewaterfinder.test.RiverServiceTests
{
    public abstract class BaseRiverServiceTests
    {
        public RiverService service  { get; private set; }
        public Mock<IRiverRepository> MockRiverRepo { get; private set; }
        public Mock<IRiverDetailRepository> MockDetailRepo { get; private set; }
        public BaseRiverServiceTests()
        {
            MockRiverRepo = new Mock<IRiverRepository>();
            MockDetailRepo = new Mock<IRiverDetailRepository>();
            
            service = new RiverService(MockRiverRepo.Object, MockDetailRepo.Object);
        }
    }
}