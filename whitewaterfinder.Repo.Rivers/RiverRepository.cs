using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.BusinessObjects.USGSResponses;
using whitewaterfinder.BusinessObjects.Configuration;
using com.brgs.orm.Azure;
using Newtonsoft.Json.Linq;
using whitewaterfinder.Repo.Extensions;


namespace whitewaterfinder.Repo.Rivers
{
    public interface IRiverRepository 
    {
        IEnumerable<River> GetRivers();
        Task<IEnumerable<River>> GetRiversAsync(string partName);
        Task<IEnumerable<River>> GetRiversByState(string stateCode);
        void Register(RiverRepositoryConfig configVals);
        Task<int> InsertBatchData(IEnumerable<River> rivers, string partition);

    }
    public class RiverRepository : IRiverRepository
    {
        private readonly IAzureTableBuilder folders;
        private readonly HttpClient _client;
        private string _riverTable;
        private string _baseUSGSUrl;
        private string _azureSearchUrl;
        private string _azureSearchKey;
        public RiverRepository(IAzureTableBuilder _folder, HttpClient client)
        {
            folders = _folder;
            _client = client;
        }
        public void Register(RiverRepositoryConfig configVals)
        {
            _riverTable = configVals.RiverTable;
            folders.CollectionName = _riverTable;
            _baseUSGSUrl = configVals.BaseUSGSURL + "stateCd=";

            /*TODO: look into parameterizing the search */
            _azureSearchUrl = configVals.AzureSearchUrl;
            _azureSearchKey = configVals.AzureSearchKey;
        }
        public async Task<USGSRiverResponse> GetRiverData(string stateCode)
        {
            if(string.IsNullOrEmpty(stateCode)) { throw new ArgumentException("we need to know where you'd like to search" ); }
            
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
            _baseUSGSUrl + stateCode);

            using (HttpResponseMessage response = await _client.SendAsync(request))
            {
                var vals = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<USGSRiverResponse>(vals);
            }
        }
        public IEnumerable<River> GetRivers()
        {
            // folders.CollectionName = "data";
            // return folders.Get<List<River>>("usRivers.json");
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<River>> GetRiversAsync(string partName)
        {
            if(string.IsNullOrEmpty(partName)) { throw new ArgumentException("we need to know where you'd like to search" ); }
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
            _azureSearchUrl + partName);
            request.Headers.Add("api-key", _azureSearchKey);

            using(HttpResponseMessage response = await _client.SendAsync(request))
            {
                var data = await response.Content.ReadAsStringAsync();
                var objs = JObject.Parse(data);
                var vals = objs.ParseByIndexes("value");
                return vals.ToObject<IEnumerable<River>>();
            }
        }
        public async Task<IEnumerable<River>> GetRiversByState(string stateCode)
        {
            if(string.IsNullOrEmpty(_riverTable)) { throw new ArgumentNullException("Table name cannot be null"); }
            if(string.IsNullOrEmpty(stateCode)) { throw new ArgumentNullException("State you're searching for cannot be null"); }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
            _azureSearchUrl + stateCode);
            request.Headers.Add("api-key", _azureSearchKey);

            using(HttpResponseMessage response = await _client.SendAsync(request))
            {
                var data = await response.Content.ReadAsStringAsync();
                var objs = JObject.Parse(data);
                var vals = objs["value"];
                return vals.ToObject<IEnumerable<River>>();
            }
        }

        public async Task InsertRiverData(RiverEntity aRiver)
        {
            await folders.PostStorageTableAsync(aRiver);
        }
        public async Task<int> InsertBatchData(IEnumerable<River> rivers, string partition)
        {
            folders.PartitionKey = partition;
            return await folders.PostBatchAsync(rivers);
        }
    }
}