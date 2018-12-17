using whitewaterfinder.Repo.Factories;
using whitewaterfinder.Repo;
using whitewaterfinder.Core;
using whitewaterfinder.BusinessObjects.Rivers;
using Newtonsoft.Json;
using System;

namespace whitewaterfinder.Daemon
{
    class Program
    {
        private const string connectionString = "DefaultEndpointsProtocol=https;AccountName=waterfinder;AccountKey=e0c3AhZdjwribEAHNNUfdcYtX3x4rAqYv0Xfy35z9Xt6Ve7woUG6aWmvAwDH1HY/Vu/2XsjXmHcpCdsr4cXvXg==;EndpointSuffix=core.windows.net";
        static void Main(string[] args)
        {
            var azureFactory = new AzureStorageFactory(connectionString, "data");
            var azureRepo = new RiverRepository(azureFactory);
            var rivers = azureRepo.GetAllUSRivers();

            var details = new RiverDetailRepository();
            var service = new RiverService(azureRepo, details);
            

            foreach(var river in rivers)
            {
                var entity = new RiverEntity(Guid.NewGuid())
                {
                    Date = DateTime.Now,
                    RiverName = river.Name,
                    RiverId = river.RiverId,
                    Timestamp = DateTime.Now,
                    RowKey = river.RiverId,
                    ETag = "river", 
                    PartitionKey = "1"
                };
                azureRepo.InsertRiverData(entity);
                Console.WriteLine(river.Name);
            }
        }
    }
}
