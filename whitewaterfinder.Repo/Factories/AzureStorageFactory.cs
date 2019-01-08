
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
        public string CollectionName { get; set; }
        public AzureStorageFactory(string connectionString)
        {
            account = CloudStorageAccount.Parse(connectionString);
        }
        public T Get<T>( string blobName)
        {
            return GetAsync<T>(CollectionName, blobName).Result;
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

                    outVal.GetType().GetMethod("Add").Invoke(outVal, new[] { entity });
                }

            } while (token != null);

            return outVal;
        }
        public TableResult Post<T>(T record, string table)
        {
            throw new NotImplementedException("Not coming");
        }
        public T Post<T>(T record)
        {
            if(record is ITableEntity)
            {
                //just send the object in
                var table = PostAsync(record).Result;
            }
            else
            {
                //work it into the correct format.
                var recordProps = record.GetType().GetProperties();
                var obj = BuildTableEntity(recordProps, record);
                
                TableResult table = PostAsync((ITableEntity) obj).Result;
            }
            return record;
        }
        private DynamicTableEntity BuildTableEntity<T>(PropertyInfo[] recordProps, T record)
        {
            var props = new Dictionary<string, EntityProperty>();
            var partitionKey = "1";
            foreach(var prop in recordProps)
            {
                // if(prop.Name.ToUpper().Equals("ID"))
                // {
                //     partitionKey = prop.GetValue(record).ToString();
                // }
                switch(prop.PropertyType.ToString())
                {
                    case("System.String"):
                        props.Add(prop.Name, new EntityProperty( prop.GetValue(record).ToString()));
                        break;
                    case("System.Boolean"):
                        props.Add(prop.Name, new EntityProperty((bool?) prop.GetValue(record)));
                        break;
                    case("System.Double"):
                        props.Add(prop.Name, new EntityProperty((double?) prop.GetValue(record)));
                        break;
                    case("System.Int32"):
                        props.Add(prop.Name, new EntityProperty((Int32?) prop.GetValue(record)));
                        break;
                    case("System.Int64"):
                        props.Add(prop.Name, new EntityProperty((Int64?) prop.GetValue(record)));
                        break;
                }
            }
            return new DynamicTableEntity(partitionKey, record.GetType().Name, "*", props); 
        }
        private async Task<TableResult> PostAsync<T>(T record)
        {
            try 
            {                
                var tableClient = account.CreateCloudTableClient();
                var table = tableClient.GetTableReference(CollectionName);
                bool complete = table.CreateIfNotExistsAsync().Result;
                var insert = TableOperation.InsertOrMerge((ITableEntity) record);
                // var insert = TableOperation.InsertOrReplace((ITableEntity) record);
                var val =  await table.ExecuteAsync(insert);
                return val;

            } catch (StorageException e )
            {
                throw new Exception(e.RequestInformation.ExtendedErrorInformation.ToString());
            }
        }
        public IEnumerable<T> GetMultiple<T>(string name)
        {
            return GetEnumerableAsync<T>(CollectionName, name).Result;
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