
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Reflection;
using System.Runtime.CompilerServices;
using whitewaterfinder.Repo.Helpers;

namespace whitewaterfinder.Repo.Factories
{
    public class AzureStorageFactory: IStorageFactory
    {
        private CloudStorageAccount account;
        private readonly string containername;
        public AzureStorageFactory(string connectionString, string blobContainer)
        {
            containername = blobContainer;
            account = CloudStorageAccount.Parse(connectionString);
        }
        public T Get<T>( string blobName)
        {
            return GetAsync<T>(containername, blobName).Result;
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
        public T Get<T>(TableQuery query, string table) 
        {
            return GetAsync<T>(query, table).Result;
        }
        private async Task<T> GetAsync<T>(TableQuery query, string tableName)
        {
            var tableClient = account.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);
            var outVal = (T)Activator.CreateInstance(typeof(T));

            TableContinuationToken token = null;
            do
            {
                var results = await table.ExecuteQuerySegmentedAsync(query, token);
                token = results.ContinuationToken;
                foreach(var entity in results.Results)
                {
                    var stuff = outVal.GetType().GetGenericArguments()[0];

                    outVal.GetType().GetMethod("Add").Invoke(outVal, new[] { entity });
                }

            } while (token != null);
            return outVal;
        }
        public TableResult Post<T>(T record, string tableName)
        {
            if(record is ITableEntity)
            {
                return PostAsync<T>(record, tableName).Result;
            }
            else
            {
                var thing = new TableEntity();
                return default(TableResult);
            }
        }
        private async Task<TableResult> PostAsync<T>(T record, string tableName)
        {
            try 
            {                
                var tableClient = account.CreateCloudTableClient();
                var table = tableClient.GetTableReference(tableName);
                bool complete = table.CreateIfNotExistsAsync().Result;
                var insert = TableOperation.InsertOrReplace((ITableEntity) record);
                var val =  await table.ExecuteAsync(insert);
                return val;
            } catch (StorageException e )
            {
                
                throw new Exception(e.RequestInformation.ExtendedErrorInformation.ToString());
            }

        }
        public IEnumerable<T> GetMultiple<T>(string name)
        {
            return GetEnumerableAsync<T>(containername, name).Result;
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