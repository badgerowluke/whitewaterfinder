using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using whitewaterfinder.Core;
using whitewaterfinder.Repo;
using whitewaterfinder.BusinessObjects.Rivers;
using com.brgs.orm.Azure;

using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;
using System.Collections.Generic;
using System.Net;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;

namespace whitewaterfinder.api
{
    public class Rivers
    {
        private readonly ICloudStorageAccount _account;
        private readonly IRiverService _service;
        private readonly string _searchKey;
        public Rivers(ICloudStorageAccount account, IRiverService service, IConfiguration settings)
        {
            _account = account;
            _service = service;
            _searchKey = settings["azuresearch-key"];
        }
        [FunctionName("Rivers")]
        [OpenApiOperation("Rivers")]
        [OpenApiParameter("name", In=ParameterLocation.Query, Required=true, Description="name of the river  you'd like to find", Type=typeof(string))]
        [OpenApiResponseBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<River>))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.NoContent, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.InternalServerError, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.BadRequest, "application/json", typeof(string))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            try 
            {
                string name = req.Query["name"];
                
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var rivers = _service.GetRivers(name);
                
                return rivers != null
                    ? (ActionResult)new OkObjectResult(rivers)
                    : new NoContentResult();
            }catch (Exception e )
            {
                log.LogError(new EventId(), e.StackTrace);
                throw new Exception();
            }

        }
    }
}
