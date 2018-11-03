using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace whitewaterfinder.Repo.Factories
{
    public interface IFileFactory
    {
        IEnumerable<T> GetEnumerable<T>(string filename);
    }
    public class FileStorageFactory: IFileFactory
    {
        private readonly string folder;
        public FileStorageFactory(string _path)
        {
            folder = _path;
        }
        public IEnumerable<T> GetEnumerable<T>( string filename)
        {
            var riverStream = new FileStream("Data/usRivers",FileMode.Open);
            var riverList = new List<T>();
            
            using(StreamReader reader = new StreamReader(riverStream)){
                string json = reader.ReadToEnd();
                var list = JsonConvert.DeserializeObject<IDictionary<string,string>>(json);
            }

            return riverList;
        }
    }
}