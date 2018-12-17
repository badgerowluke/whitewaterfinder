
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

// using whitewaterfinder.BusinessObjects.Rivers;


namespace whitewaterfinder.Repo.Factories
{
    public class AzureStorageFactory: IStorageFactory
    {
        private CloudStorageAccount account;
        private readonly string container;
        public AzureStorageFactory(string connectionString, string blobContainer)
        {
            container = blobContainer;
            account = CloudStorageAccount.Parse(connectionString);
        }
        public T Get<T>( string blobName)
        {
            return GetAsync<T>(container, blobName).Result;
        }
        private async Task<T> GetAsync<T>(string containerName, string blobName)
        {
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            var blob = container.GetBlobReference(blobName);
            var blobStream = await blob.OpenReadAsync();
            using(StreamReader reader = new StreamReader(blobStream))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
        public TableResult Post<T>(T record, string tableName)
        {
            return PostAsync<T>(record, tableName).Result;
        }
        private async Task<TableResult> PostAsync<T>(T record, string tableName)
        {
            try 
            {                
                var tableClient = account.CreateCloudTableClient();
                var table = tableClient.GetTableReference(tableName);
                bool complete = table.CreateIfNotExistsAsync().Result;
                var insert = TableOperation.Insert((ITableEntity) record);
                var val =  await table.ExecuteAsync(insert);
                return val;
            } catch (StorageException e )
            {
                
                throw new Exception(e.RequestInformation.ExtendedErrorInformation.ToString());
            }

        }
        public IEnumerable<T> GetMultiple<T>(string name)
        {
            return GetEnumerableAsync<T>(container, name).Result;
        }        
        private async Task<IEnumerable<T>> GetEnumerableAsync<T>(string containerName, string blobName)
        {
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            var blob = container.GetBlobReference(blobName);

            var riverStream = await blob.OpenReadAsync();
            using(StreamReader reader = new StreamReader(riverStream)){
                string json = reader.ReadToEnd();
                var list = JsonConvert.DeserializeObject<IEnumerable<T>>(json);


                return list;
            }            
        }


    }

}