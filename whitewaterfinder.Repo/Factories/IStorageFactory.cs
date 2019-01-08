using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
namespace whitewaterfinder.Repo.Factories
{
    public interface IStorageFactory
    {
        string CollectionName { get; set; }
        IEnumerable<T> GetMultiple<T>(string filename);
        T Get<T>(string filename); 
        T Get<T>(TableQuery query, string tablename);
        TableResult Post<T>(T record, string tableName);
        T Post<T>(T record);
    }

    /*
        public interface IStorageFactory
    {
        ///
        ///<summary> 
        ///gets everything from the data store.
        ///</summary>
        ///
        T Get<T>();
        T Get<T>(string id);
        T Post<T>();
        T Post<T>(T record);
        T Put<T>();
        int Delete<T>();
    }
     */

}