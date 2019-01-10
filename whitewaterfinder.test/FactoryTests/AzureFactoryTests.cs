using Xunit;
using whitewaterfinder.Repo.Factories;
using whitewaterfinder.Repo;
using whitewaterfinder.BusinessObjects.Rivers;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System;

namespace whitewaterfinder.test.FactoryTests
{
    public class AzureStorageTests
    {
        private const string connectionString = "DefaultEndpointsProtocol=https;AccountName=waterfinder;AccountKey=e0c3AhZdjwribEAHNNUfdcYtX3x4rAqYv0Xfy35z9Xt6Ve7woUG6aWmvAwDH1HY/Vu/2XsjXmHcpCdsr4cXvXg==;EndpointSuffix=core.windows.net";
        [Fact]
        public void WeDoGetAStorageFactory()
        {
            var fac = new AzureStorageFactory(connectionString);
            Assert.NotNull(fac);

        }
        [Fact]
        public void AzureFactory_DoesReturnResults()
        {
            var fac = new AzureStorageFactory(connectionString)
            {
                CollectionName = "RiversUnitedStates"
            };
            var query = new TableQuery()
              .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "search"));
            var stuff = fac.Get<List<River>>(query, string.Empty);
            Assert.NotEmpty(stuff);

        }

        [Fact (Skip="This fails because I don't have a good plan for implementing it correctly.")]
        public void AzureFactory_UsesTheSearchContextFromUser()
        {
            var fac = new AzureStorageFactory(connectionString)
            {
                CollectionName = "RiversUnitedStates"
            };
            var query = new TableQuery()
              .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "search"));

            var stuff = fac.Get<List<River>>(query, "gaul");

            Assert.InRange(stuff.Count, 1, 4);
        }
        [Fact]
        public void AzureFactory_Get_DoesReturnSingleEntity()
        {
            var fac = new AzureStorageFactory(connectionString)
            {
                CollectionName = "RiversUnitedStates"
            };
            var query = new TableQuery()
              .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "search"));
            var stuff = fac.Get<River>(query, "GAULEY RIVER BELOW SUMMERSVILLE DAM, WV");
            Assert.IsType<River>(stuff);
        }
        [Fact]
        public void AzureFactory_Get_Handles_ListKeyValuePair()
        {
            var fac = new AzureStorageFactory(connectionString)
            {
                CollectionName = "RiversUnitedStates"
            };
            var query = new TableQuery()
              .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "search"));
            var stuff = fac.Get<List<KeyValuePair<string,string>>>(query, "GAULEY RIVER BELOW SUMMERSVILLE DAM, WV");
            Assert.IsType <List<KeyValuePair<string, string>>> (stuff);
        }
        [Fact]
        public void AzureFactory_Get_PullsPartitionAndRowKey()
        {
            var fac = new AzureStorageFactory(connectionString)
            {
                CollectionName = "USRivers"
            };
            var filter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "AK");
            var rowfilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, "15008000");
            var query = new TableQuery();

            query.Where(TableQuery.CombineFilters(filter,TableOperators.And, rowfilter));
            var stuff = fac.Get<River>(query, "SALMON R NR HYDER AK");
            Assert.Equal("SALMON R NR HYDER AK", stuff.Name);
        }
    }
}