using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using whitewaterfinder.Core;
using whitewaterfinder.Repo;
using whitewaterfinder.Repo.Factories;

namespace whitewaterfinder.api
{
    public static class Rivers
    {
        [FunctionName("Rivers")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            try 
            {

                var config = new ConfigurationBuilder()
                    .SetBasePath(context.FunctionAppDirectory)
                    .AddEnvironmentVariables()
                    .Build();

                string name = req.Query["name"];
                
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var factory = new AzureStorageFactory(config.GetConnectionString("blob-store"));
                
                var repo = new RiverRepository(factory, "RiversUnitedStates");
                var details = new RiverDetailRepository();
                var service = new RiverService(repo, details);
                var rivers = service.GetRivers(name);
                
                return rivers != null
                    ? (ActionResult)new OkObjectResult(rivers)
                    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }catch (Exception e )
            {
                log.LogError(new EventId(), e.StackTrace);
                throw new Exception();
            }

        }
    }
}
