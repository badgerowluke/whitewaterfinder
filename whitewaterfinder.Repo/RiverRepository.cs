using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

using whitewaterfinder.BusinessObjects.Rivers;

namespace whitewaterfinder.Repo
{
    public interface IRiverRepository 
    {
        IEnumerable<River> GetAllUSRivers(string partName);
    }
    public class RiverRepository : IRiverRepository
    {
        public IEnumerable<River> GetAllUSRivers(string partName){
            var riverStream = new FileStream("Data/usRivers",FileMode.Open);
            var riverList = new List<River>();
            
            using(StreamReader reader = new StreamReader(riverStream)){
                string json = reader.ReadToEnd();
                var list = JsonConvert.DeserializeObject<IDictionary<string,string>>(json);
                if(string.IsNullOrEmpty(partName)){
                    return riverList;
                } else {
                    
                }
                var vals = list.Where(r => r.Key.ToUpper().Contains(partName.ToUpper())).Distinct().Take(40);
                foreach(var val in vals){
                    var river = new River() { Name = val.Key, RiverId = val.Value};
                    riverList.Add(river);
                }

                return riverList;
            }
        }
    }
}