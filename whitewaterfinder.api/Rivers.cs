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
            if (req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            if (log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            try 
            {
                log.LogInformation("I am here");
                var config = new ConfigurationBuilder()
                    .SetBasePath(context.FunctionAppDirectory)
                    // .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                log.LogInformation("we have the config");

                string name = req.Query["name"];
                
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                // dynamic data = JsonConvert.DeserializeObject(requestBody);
                // name = name ?? data?.name;
                var factory = new AzureStorageFactory(config.GetConnectionString("blob-store"),"data");
                var repo = new RiverRepository(factory);
                var details = new RiverDetailRepository();
                var service = new RiverService(repo, details);
                var rivers = service.GetRivers(name);
                
                return rivers != null
                    ? (ActionResult)new OkObjectResult("rivers")
                    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }catch (Exception e )
            {
                log.LogError(new EventId(), e.StackTrace);
                throw new Exception();
            }

        }
    }
}
