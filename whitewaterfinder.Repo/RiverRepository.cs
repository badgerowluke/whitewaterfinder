using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.BusinessObjects.USGSResponses;

using com.brgs.orm.Azure;
using Newtonsoft.Json.Linq;

namespace whitewaterfinder.Repo
{
    public interface IRiverRepository 
    {
        IEnumerable<River> GetRivers();
        Task<IEnumerable<River>> GetRiversAsync(string partName);
        IEnumerable<River> GetRiversByState(string stateCode);
        void Register(IDictionary<string, string> configVals);

    }
    public class RiverRepository : IRiverRepository
    {
        private readonly IAzureStorage folders;
        private readonly HttpClient _client;
        private string _riverTable;
        private string _baseUSGSUrl;
        private string _azureSearchUrl;
        private string _azureSearchKey;
        public RiverRepository(IAzureStorage _folder, HttpClient client)
        {
            folders = _folder;
            folders.CollectionName = _riverTable;
            _client = client;
        }
        [Obsolete("moving away from thie pattern")]
        public RiverRepository(IAzureStorage _folder, string table)
        {
            folders = _folder;
            folders.CollectionName = table;
        }
        public void Register(IDictionary<string, string> configVals)
        {
            _riverTable = configVals["riverTable"];
            _baseUSGSUrl = configVals["baseUSGSURL"] + "stateCd=";

            /*TODO: look into parameterizing the search */
            _azureSearchUrl = configVals["searchUrl"];
            _azureSearchKey = configVals["searchKey"];
        }
        public async Task<USGSRiverResponse> GetRiverData(string stateCode)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
            _baseUSGSUrl + stateCode);

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
            _azureSearchUrl + partName);
            request.Headers.Add("api-key", _azureSearchKey);

            using(HttpResponseMessage response = await _client.SendAsync(request))
            {
                var data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var objs = JObject.Parse(data);
                var vals = objs["value"];
                return vals.ToObject<IEnumerable<River>>();
            }
        }
        public IEnumerable<River> GetRiversByState(string stateCode)
        {
            folders.CollectionName = _riverTable;
            var entities = folders.Get<RiverEntity>(r => r.PartitionKey.Equals(stateCode));
            var outList = new List<River>();
            foreach(var entity in entities)
            {
                var river = entity.ToRiver();
                outList.Add(river);
            }

            return outList;
        }

        public void InsertRiverData(RiverEntity aRiver)
        {
            folders.Post(aRiver);
        }
    }
}