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
//using whitewaterfinder.Repo.Factories;
using com.brgs.orm;
using com.brgs.orm.Azure;
using Microsoft.Extensions.Configuration;
using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Collections.Generic;
using whitewaterfinder.BusinessObjects.Rivers;

namespace whitewaterfinder.api
{
    public  class RiverDetails
    {
        private readonly ICloudStorageAccount _account;
        public RiverDetails(ICloudStorageAccount account)
        {
            _account = account;
        }
        [FunctionName("RiverDetails")]
        [OpenApiOperation("Rivers")]
        [OpenApiParameter("riverCode", In=ParameterLocation.Query, Required=true, Description="The USGS code for the chosen river", Type=typeof(string))]
        [OpenApiResponseBody(HttpStatusCode.OK, "application/json", typeof(River))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.NoContent, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.InternalServerError, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.BadRequest, "application/json", typeof(string))]        
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        {

            string name = req.Query["riverCode"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            var factory = new AzureStorageFactory(_account);
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
