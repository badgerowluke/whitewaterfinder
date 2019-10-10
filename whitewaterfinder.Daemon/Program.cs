//using whitewaterfinder.Repo.Factories;
using whitewaterfinder.Repo;
using whitewaterfinder.Core;
using whitewaterfinder.BusinessObjects.Rivers;
using com.brgs.orm;
using com.brgs.orm.Azure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

using System.IO;
using Newtonsoft.Json;
using System.Linq;
using whitewaterfinder.BusinessObjects.Configuration;
using System.Threading.Tasks;

namespace whitewaterfinder.Daemon
{
    class Program
    {
        private const string connectionString = "";
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build()
                .Get<RiverRepositoryConfig>();
            


            var account = new CloudStorageAccountBuilder(config.BlobStore);            
            var azureFactory = new AzureTableBuilder(account);
            azureFactory.CollectionName = config.RiverTable;
            var client = new HttpClient();
            var repo = new RiverRepository(azureFactory, client);
            repo.Register(config);

            var stuff = repo.GetRiversByState("WV").Result;

            // var rivers = new List<River>();
            // using(var file = new FileStream(config.RiverFile, FileMode.Open))
            // using(var reader = new StreamReader(file))
            // {
            //     var json = reader.ReadToEnd();
            //     rivers = JsonConvert.DeserializeObject<List<River>>(json);
            // }



        }
        static void LoadTableStore(AzureTableBuilder azureFactory, List<River> rivers)
        {
            var states = rivers.Select((r, code) => r.StateCode).Distinct();

            foreach(var state in states)
            {
                var stateRivers = rivers.Where(x => x.StateCode.Equals(state));
                azureFactory.PartitionKey =  state;
                var count = azureFactory.PostBatchAsync(stateRivers).GetAwaiter().GetResult();
            }
        }
        
        
        static async Task LoadStates(RiverRepository azureRepo)
        {
            var states = GetStateCodes();
            
            foreach(var state in states)
            {
                IDictionary<string, RiverEntity> stateRivers = new Dictionary<string, RiverEntity>();
                var data = azureRepo.GetRiverData(state.Value).Result;
                foreach(var ts in data.Value.TimeSeries){
                    var river = new RiverEntity()
                    {
                        Name = ts.SourceInfo.SiteName,
                        Latitude = ts.SourceInfo.Geolocation.GeogLocation.Latitude,
                        Longitude = ts.SourceInfo.Geolocation.GeogLocation.Longitude,
                        Srs = ts.SourceInfo.Geolocation.GeogLocation.SRS,
                        RiverId = ts.SourceInfo.SiteCode[0].Value,
                        State = state.Key,
                        StateCode = state.Value,
                        PartitionKey = "search",
                        ETag = "river_Insert",
                        RowKey = ts.SourceInfo.SiteCode[0].Value,
                        Date = DateTime.Now
                    };
                    if(!stateRivers.ContainsKey(river.RiverId)){
                        stateRivers.Add(river.RiverId, river);
                        await azureRepo.InsertRiverData(river);
                        Console.WriteLine($"{river.Name}, {river.RiverId} {river.State}");
                    }
                }
                // Console.WriteLine(state.Value);
            }
        }
        public static IDictionary<string, string> GetStateCodes() {
           IDictionary<string,string> codePair = new Dictionary<string, string>();

            codePair.Add(new KeyValuePair<string, string>("Alabama","AL"));
            codePair.Add(new KeyValuePair<string, string>("Alaska","AK"));
            codePair.Add(new KeyValuePair<string, string>("Arizona","AZ"));
            codePair.Add(new KeyValuePair<string, string>("Arkansas","AR"));
            codePair.Add(new KeyValuePair<string, string>("California","CA"));
            codePair.Add(new KeyValuePair<string, string>("Colorado","CO"));
            codePair.Add(new KeyValuePair<string, string>("Connecticut","CT"));
            codePair.Add(new KeyValuePair<string, string>("Delaware","DE"));
            codePair.Add(new KeyValuePair<string, string>("Florida","FL"));
            codePair.Add(new KeyValuePair<string, string>("Georgia","GA"));
            codePair.Add(new KeyValuePair<string, string>("Hawaii","HI"));
            codePair.Add(new KeyValuePair<string, string>("Idhao","ID"));
            codePair.Add(new KeyValuePair<string, string>("Illinois","IL"));
            codePair.Add(new KeyValuePair<string, string>("Indiana","IN"));
            codePair.Add(new KeyValuePair<string, string>("Iowa", "IA"));
            codePair.Add(new KeyValuePair<string, string>("Kansas", "KS"));
            codePair.Add(new KeyValuePair<string, string>("Kentucky", "KY"));
            codePair.Add(new KeyValuePair<string, string>("Louisiana", "LA"));
            codePair.Add(new KeyValuePair<string, string>("Maine", "ME"));
            codePair.Add(new KeyValuePair<string, string>("Maryland", "MD"));
            codePair.Add(new KeyValuePair<string, string>("Massachusets", "MA"));
            codePair.Add(new KeyValuePair<string, string>("Michigan", "MI"));
            codePair.Add(new KeyValuePair<string, string>("Minnesota", "MN"));
            codePair.Add(new KeyValuePair<string, string>("Mississippi", "MS"));
            codePair.Add(new KeyValuePair<string, string>("Missouri", "MO"));
            codePair.Add(new KeyValuePair<string, string>("Montana", "MT"));
            codePair.Add(new KeyValuePair<string, string>("Nebraska", "NE"));
            codePair.Add(new KeyValuePair<string, string>("Nevada", "NV"));
            codePair.Add(new KeyValuePair<string, string>("New Hampshire", "NH"));
            codePair.Add(new KeyValuePair<string, string>("New Jersey", "NJ"));
            codePair.Add(new KeyValuePair<string, string>("New Mexico", "NM"));
            codePair.Add(new KeyValuePair<string, string>("New York", "NY"));
            codePair.Add(new KeyValuePair<string, string>("North Carolina", "NC"));
            codePair.Add(new KeyValuePair<string, string>("North Dakota", "ND")); 
            codePair.Add(new KeyValuePair<string, string>("Ohio", "OH"));
            codePair.Add(new KeyValuePair<string, string>("Oklahoma", "OK"));
            codePair.Add(new KeyValuePair<string, string>("Oregon", "OR"));
            codePair.Add(new KeyValuePair<string, string>("Pennsylvania", "PA"));
            codePair.Add(new KeyValuePair<string, string>("Rhode Island", "RI"));
            codePair.Add(new KeyValuePair<string, string>("South Carolina", "SC"));
            codePair.Add(new KeyValuePair<string, string>("South Dakota", "SD"));
            codePair.Add(new KeyValuePair<string, string>("Tennessee", "TN"));
            codePair.Add(new KeyValuePair<string, string>("Texas", "TX"));
            codePair.Add(new KeyValuePair<string, string>("Utah", "UT"));
            codePair.Add(new KeyValuePair<string, string>("Vermont", "VT"));
            codePair.Add(new KeyValuePair<string, string>("Virginia", "VA"));
            codePair.Add(new KeyValuePair<string, string>("Washington", "WA"));
            codePair.Add(new KeyValuePair<string, string>("West Virginia", "WV"));
            codePair.Add(new KeyValuePair<string, string>("Wisconsin", "WI"));
            codePair.Add(new KeyValuePair<string, string>("Wyoming", "WY"));

            // string code = codePair[state];
            return codePair;

        }
    }
}
