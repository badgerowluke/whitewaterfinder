using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
namespace whitewaterfinder.Repo.Factories
{
    public interface IStorageFactory
    {
        IEnumerable<T> GetMultiple<T>(string filename);
        T Get<T>(string filename); 
        T Get<T>(TableQuery query, string tablename);
        TableResult Post<T>(T record, string tableName);
    }

}