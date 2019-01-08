using Xunit;
using whitewaterfinder.Repo.Factories;
using whitewaterfinder.Repo;
using whitewaterfinder.Core;
using Newtonsoft.Json;
using System;


namespace whitewaterfinder.test
{
    public class TableMigrationJobs
    {
        private const string connectionString = "DefaultEndpointsProtocol=https;AccountName=waterfinder;AccountKey=e0c3AhZdjwribEAHNNUfdcYtX3x4rAqYv0Xfy35z9Xt6Ve7woUG6aWmvAwDH1HY/Vu/2XsjXmHcpCdsr4cXvXg==;BlobEndpoint=https://waterfinder.blob.core.windows.net/;QueueEndpoint=https://waterfinder.queue.core.windows.net/;TableEndpoint=https://waterfinder.table.core.windows.net/;FileEndpoint=https://waterfinder.file.core.windows.net/;";

        [Fact(Skip="didn't really end up doing it this way")]
        public void ThisMigratesData()
        {
            var fileFactory = new FileStorageFactory("data");
            var fileRepo = new RiverRepository(fileFactory);
            var details = new RiverDetailRepository();
            var service = new RiverService(fileRepo, details);
            var rivers = fileRepo.GetAllUSRivers();
            var azureFactory = new AzureStorageFactory(connectionString);
            var azureRepo = new RiverRepository(azureFactory);
            

            foreach(var river in rivers)
            {
                Console.WriteLine(river.Name);
            }
            
        }
    }
}