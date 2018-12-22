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
            var fac = new AzureStorageFactory(connectionString, "USRivers");
            Assert.NotNull(fac);

        }
        [Fact]
        public void AzureFactory_DoesReturnResults()
        {
            var fac = new AzureStorageFactory(connectionString, "USRivers");
            var query = new TableQuery();
            var stuff = fac.Get<List<DynamicTableEntity>>(query, "USRivers");
            Assert.NotEmpty(stuff);

        }
        [Fact]
        public void AzureFactory_ConvertDynamicEntityToMeaningfulEntity()
        {
            var fac = new AzureStorageFactory(connectionString, "USRivers");
            var query = new TableQuery();
            var stuff = fac.Get<List<DynamicTableEntity>>(query, "USRivers")[0];

            var outVal = (River)Activator.CreateInstance(typeof(River));
            foreach (var property in stuff.Properties)
            {
                
                var propInfo = outVal.GetType().GetProperty(property.Key);
                if (propInfo != null)
                {
                    switch(propInfo.PropertyType.ToString())
                    {
                        case ("System.String"):

                            outVal.GetType().GetProperty(property.Key)
                                  .SetValue(outVal, property.Value.StringValue);
                            break;
                        case ("System.DateTime"):
                            outVal.GetType().GetProperty(property.Key)
                                .SetValue(outVal, property.Value.DateTime);
                            break;
                    }

                }
            }
            Assert.IsType<River>(outVal);
            Assert.NotNull(outVal.RiverName);
        }
    }
}