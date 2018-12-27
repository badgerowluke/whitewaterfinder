using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

using whitewaterfinder.BusinessObjects.Rivers;
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
        public RiverRepository(IStorageFactory _folder)
        {
            folders = _folder;
        }
        public IEnumerable<River> GetAllUSRivers()
        {
            TableQuery stuff = new TableQuery();
            
            var riverEntities = folders.Get<List<DynamicTableEntity>>(stuff, "USRivers");
            return AzureFormatHelpers.RecastEntities<List<River>>(riverEntities);
            
        }

        public void InsertRiverData(RiverEntity aRiver)
        {
            folders.Post<RiverEntity>(aRiver, "USRivers");
        }
    }
}