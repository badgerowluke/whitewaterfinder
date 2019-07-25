using Xunit;
//using whitewaterfinder.Repo.Factories;
using whitewaterfinder.Repo;
using whitewaterfinder.BusinessObjects.Rivers;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using com.brgs.orm.Azure;

using System.Collections.Generic;
using System;
namespace whitewaterfinder.test.HelperTests
{
    public class AzureStorageHelperTests
    {
        private const string connectionString = "DefaultEndpointsProtocol=https;AccountName=waterfinder;AccountKey=e0c3AhZdjwribEAHNNUfdcYtX3x4rAqYv0Xfy35z9Xt6Ve7woUG6aWmvAwDH1HY/Vu/2XsjXmHcpCdsr4cXvXg==;EndpointSuffix=core.windows.net";
        [Fact]
        public void FormatHelperReturnsList()
        {
            var account = new CloudStorageAccountBuilder(connectionString);

            var fac = new AzureStorageFactory(account);

            var repo = new RiverRepository(fac);
            // var query = new TableQuery();
            var stuff = repo.GetAllUSRivers();
            Assert.IsType<List<River>>(stuff);

        }
    }

}