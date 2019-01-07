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
             stuff.Take(40);
             
            
             var riverEntities = folders.Get<List<DynamicTableEntity>>(stuff, "USRivers");
             return AzureFormatHelpers.RecastEntities<List<River>>(riverEntities);
            //return folders.Get<List<River>>( "usRivers.json");
        }

        public void InsertRiverData(RiverEntity aRiver)
        {
            folders.Post(aRiver, "USRivers2");
        }
    }
}