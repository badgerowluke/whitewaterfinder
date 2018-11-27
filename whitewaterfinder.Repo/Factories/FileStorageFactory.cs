using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace whitewaterfinder.Repo.Factories
{
    public interface IStorageFactory
    {
        IEnumerable<T> GetMultiple<T>(string filename);
        T Get<T>(string filename); 
    }
    public class FileStorageFactory: IStorageFactory
    {
        private readonly string folder;
        public FileStorageFactory(string _path)
        {
            folder = _path;
        }
        public IEnumerable<T> GetMultiple<T>( string filename)
        {
            var stream = new FileStream(Path.Combine(folder, filename), FileMode.Open);
            var listOut = new List<T>();
            
            using(StreamReader reader = new StreamReader(stream)){
                string json = reader.ReadToEnd();
                var list = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                listOut = list.ToList();
            }

            return listOut;
        }
        public T Get<T>(string filename)
        {
            var stream = new FileStream(Path.Combine(folder, filename), FileMode.Open);
            using(StreamReader reader = new StreamReader(stream)){
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
                
            }
        }
    }
}