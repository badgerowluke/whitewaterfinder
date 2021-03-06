
using System.Collections.Generic;

using whitewaterfinder.Core.Rivers.Data;
using whitewaterfinder.Repo.Rivers;
using whitewaterfinder.BusinessObjects.Rivers;
using System.Threading.Tasks;
using whitewaterfinder.BusinessObjects.Configuration;

namespace whitewaterfinder.Core.Rivers
{
    public interface IRiverService 
    {
        Task<IEnumerable<River>> GetRivers(string partName);
        Task<River> GetRiverDetails(string riverCode);
    }
    public class RiverService : StateData, IRiverService
    {
        private readonly IRiverRepository repo;
        private readonly IRiverDetailRepository detail;
        private readonly RiverRepositoryConfig _config;
        public RiverService(IRiverRepository riverRep, 
            IRiverDetailRepository _details,
            RiverRepositoryConfig config)
        {
            repo = riverRep;
            detail = _details;
            _config = config;
        }

        public async Task<IEnumerable<River>> GetRivers(string partName)
        {
            repo.Register(_config);
            if(string.IsNullOrEmpty(partName)){
                return repo.GetRivers();
            } else {
                if(!string.IsNullOrEmpty(GetStateCode(partName)))
                {
                    return await repo.GetRiversByState(partName);
                }
                return await repo.GetRiversAsync(partName);
            }
        }
        
        public async Task<River> GetRiverDetails(string riverCode)
        {
            detail.Register(_config);
            return await detail.GetRiverDetailsAsync(riverCode);
        }

    }
}