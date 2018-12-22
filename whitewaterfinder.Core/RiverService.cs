using System;
using System.Collections.Generic;
using System.Linq;

using whitewaterfinder.Repo;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.BusinessObjects;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace whitewaterfinder.Core
{
    public interface IRiverService 
    {
        IEnumerable<River> GetRivers(string partName);
        River GetRiverDetails(string riverCode);
    }
    public class RiverService : IRiverService
    {
        private readonly IRiverRepository repo;
        private readonly IRiverDetailRepository detail;
        public RiverService(IRiverRepository riverRep, 
            IRiverDetailRepository _details)
        {
            repo = riverRep;
            detail = _details;
        }
        public IEnumerable<River> GetRivers(string partName)
        {
            var riverList = repo.GetAllUSRivers();
            if(string.IsNullOrEmpty(partName)){
                return riverList;
            } else {
                var vals = riverList.Where(r => r.RiverName.ToUpper().Contains(partName.ToUpper())).Distinct().Take(40);
                return vals;
            }

        }
        
        public River GetRiverDetails(string riverCode)
        {
            return detail.GetRiverDetailsAsync(riverCode).Result;
        }

    }
}