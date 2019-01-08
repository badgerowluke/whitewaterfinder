using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.BusinessObjects.USGSResponses;
using whitewaterfinder.Repo.Factories;
using whitewaterfinder.Repo.Helpers;
namespace whitewaterfinder.Repo
{
    public interface IRiverRepository 
    {
        IEnumerable<River> GetAllUSRivers();
    }
    public class RiverRepository : IRiverRepository
    {
        private readonly IStorageFactory folders;
        private const string RiverTable = "USRivers";
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
            using(HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                "https://waterservices.usgs.gov/nwis/iv/?format=json&indent=on&stateCd=" + stateCode);

                using(HttpResponseMessage response = await client.SendAsync(request))
                {
                    var vals = response.Content.ReadAsStringAsync().Result;
                    USGSRiverResponse obj = JsonConvert.DeserializeObject<USGSRiverResponse>(vals);
                    return obj;
                }
            }
        }
        public IEnumerable<River> GetAllUSRivers()
        {
             TableQuery stuff = new TableQuery();
             stuff.Take(40);
             
             var riverEntities = folders.Get<List<DynamicTableEntity>>(stuff, "USRivers");
             return AzureFormatHelpers.RecastEntities<List<River>>(riverEntities);
        }
        public void InsertRiverData(RiverEntity aRiver)
        {
            folders.Post(aRiver);
        }
    }
}