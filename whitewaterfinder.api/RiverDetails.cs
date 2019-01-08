using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using whitewaterfinder.Core;
using whitewaterfinder.Repo;
using whitewaterfinder.Repo.Factories;
using Microsoft.Extensions.Configuration;

namespace whitewaterfinder.api
{
    public static class RiverDetails
    {
        [FunctionName("RiverDetails")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
                var config = new ConfigurationBuilder()
                    .SetBasePath(context.FunctionAppDirectory)
                    // .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
            string name = req.Query["riverCode"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            var factory = new AzureStorageFactory(config.GetConnectionString("blob-store"));
            var repo = new RiverRepository(factory);
            var details = new RiverDetailRepository();
            var service = new RiverService(repo, details);
            var riverDetails = service.GetRiverDetails(name);

            return name != null
                ? (ActionResult)new OkObjectResult(riverDetails)
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
