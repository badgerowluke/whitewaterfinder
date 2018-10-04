using System;
using System.Collections.Generic;
using System.IO;


namespace whitewaterfinder.Repo.Factories
{
    public interface IFileFactory
    {

    }
    public class FileStorageFactory: IFileFactory
    {
        private readonly string folder;
        public FileStorageFactory(string _path)
        {
            folder = _path;
        }
        public IEnumerable<T> GetListOfThings<T>( string filename)
        {
            using (StreamReader reader = new StreamReader(folder +filename))
            {
                string json = reader.ReadToEnd();
            }
            return new List<T>();
        }
    }
}