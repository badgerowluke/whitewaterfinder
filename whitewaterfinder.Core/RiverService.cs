
using System.Collections.Generic;

using whitewaterfinder.Core.Data;
using whitewaterfinder.Repo;
using whitewaterfinder.BusinessObjects.Rivers;



namespace whitewaterfinder.Core
{
    public interface IRiverService 
    {
        IEnumerable<River> GetRivers(string partName);
        River GetRiverDetails(string riverCode);
        void Register(Dictionary<string,string> config);
    }
    public class RiverService : StateData, IRiverService
    {
        private readonly IRiverRepository repo;
        private readonly IRiverDetailRepository detail;
        private IDictionary<string, string> _config;
        public RiverService(IRiverRepository riverRep, 
            IRiverDetailRepository _details)
        {
            repo = riverRep;
            detail = _details;
        }
        public void Register(Dictionary<string, string> config)
        {
            _config = config;
        }
        public IEnumerable<River> GetRivers(string partName)
        {
            repo.Register(_config);
            if(string.IsNullOrEmpty(partName)){
                return repo.GetRivers();
            } else {
                return repo.GetRiversAsync(partName).GetAwaiter().GetResult();
            }
        }
        
        public River GetRiverDetails(string riverCode)
        {
            detail.Register(_config);
            return detail.GetRiverDetailsAsync(riverCode).Result;
        }

    }
}