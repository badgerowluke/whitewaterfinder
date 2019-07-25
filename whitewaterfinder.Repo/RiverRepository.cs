using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.BusinessObjects.USGSResponses;
//using whitewaterfinder.Repo.Factories;
//using whitewaterfinder.Repo.Helpers;
using com.brgs.orm;
using com.brgs.orm.Azure;


namespace whitewaterfinder.Repo
{
    public interface IRiverRepository 
    {
        IEnumerable<River> GetAllUSRivers();
        IEnumerable<River> GetRivers();
    }
    public class RiverRepository : IRiverRepository
    {
        private readonly IStorageFactory folders;
        private const string RiverTable = "RiversUnitedStates";
        public RiverRepository(IStorageFactory _folder)
        {
            folders = _folder;
            folders.CollectionName = RiverTable;
        }
        public RiverRepository(IStorageFactory _folder, string table)
        {
            folders = _folder;
            folders.CollectionName = table;
        }
        public async Task<USGSRiverResponse> GetRiverData(string stateCode)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                "https://waterservices.usgs.gov/nwis/iv/?format=json&indent=on&stateCd=" + stateCode);

                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    var vals = response.Content.ReadAsStringAsync().Result;
                    USGSRiverResponse obj = JsonConvert.DeserializeObject<USGSRiverResponse>(vals);
                    return obj;
                }
            }
        }
        public IEnumerable<River> GetRivers()
        {
            folders.CollectionName = "data";
            return folders.Get<List<River>>("usRivers.json");
        }
        public IEnumerable<River> GetAllUSRivers()
        {
            folders.CollectionName = RiverTable;
            //TODO NOTE.  the concept behind the partitionkey is the "folder" the rowkey is the "file"
            var stuff = new TableQuery();
            //  .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "search"));
            return folders.Get<List<River>>(stuff);

        }
        // public IEnumerable<River> GetAllUSRivers(string val)
        // {
        //     folders.CollectionName = RiverTable;
        //     //TODO NOTE.  the concept behind the partitionkey is the "folder" the rowkey is the "file"
        //     var stuff = new TableQuery();
        //     //  .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "search"));
        //     return folders.Get<List<River>>(stuff, r => r.Properties.ContainsKey("Name") && r.Properties["Name"].StringValue.Contains(val));            
        // }
        public void InsertRiverData(RiverEntity aRiver)
        {
            folders.Post(aRiver);
        }
    }
}