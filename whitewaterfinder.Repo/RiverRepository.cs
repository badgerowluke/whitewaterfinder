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

using com.brgs.orm.Azure;
using Newtonsoft.Json.Linq;

namespace whitewaterfinder.Repo
{
    public interface IRiverRepository 
    {
        IEnumerable<River> GetAllUSRivers();
        IEnumerable<River> GetRivers();
        Task<IEnumerable<River>> GetRiversAsync(string stateCode);

    }
    public class RiverRepository : IRiverRepository
    {
        private readonly IAzureStorage folders;
        private readonly HttpClient _client;
        private const string RiverTable = "RiversUnitedStates";
        public RiverRepository(IAzureStorage _folder, HttpClient client)
        {
            folders = _folder;
            folders.CollectionName = RiverTable;
            _client = client;
        }
        public RiverRepository(IAzureStorage _folder, string table)
        {
            folders = _folder;
            folders.CollectionName = table;
        }
        public async Task<USGSRiverResponse> GetRiverData(string stateCode)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
            "https://waterservices.usgs.gov/nwis/iv/?format=json&indent=on&stateCd=" + stateCode);

            using (HttpResponseMessage response = await _client.SendAsync(request))
            {
                var vals = response.Content.ReadAsStringAsync().Result;
                USGSRiverResponse obj = JsonConvert.DeserializeObject<USGSRiverResponse>(vals);
                return obj;
            }
        }
        public IEnumerable<River> GetRivers()
        {
            folders.CollectionName = "data";
            return folders.Get<List<River>>("usRivers.json");
        }
        public async Task<IEnumerable<River>> GetRiversAsync(string partName)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
            "https://askwebster-asvs3oon36uy7ty.search.windows.net/indexes/azuretable-index/docs/suggest?suggesterName=RiverName&api-version=2019-05-06&fuzzy=false&$top=20&&$select=Name,RiverId&search=" + partName);
            request.Headers.Add("api-key", "");

            using(HttpResponseMessage response = await _client.SendAsync(request))
            {
                var data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var objs = JObject.Parse(data);
                var vals = objs["value"];
                return vals.ToObject<IEnumerable<River>>();
            }
        }
        public IEnumerable<River> GetAllUSRivers()
        {
            folders.CollectionName = RiverTable;
            //TODO NOTE.  the concept behind the partitionkey is the "folder" the rowkey is the "file"
            var stuff = new TableQuery();
            //  .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "search"));
            return folders.Get<List<River>>(stuff);

        }


        public void InsertRiverData(RiverEntity aRiver)
        {
            folders.Post(aRiver);
        }
    }
}