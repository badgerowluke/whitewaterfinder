using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Collections.Generic;
using whitewaterfinder.BusinessObjects.Rivers;
using com.brgs.orm.Azure;
using whitewaterfinder.Core;
using Microsoft.Extensions.Configuration;
using System;

namespace whitewaterfinder.api
{
    public class RiversByState
    {

        private readonly IRiverService _service;

        public RiversByState(IRiverService service, IConfiguration settings)
        {
            _service = service;

        }


        [FunctionName("RiversByState")]
        [OpenApiOperation("RiversByState")]
        [OpenApiParameter("state", In=ParameterLocation.Query, Required=true, Description="The State you'd like to search within", Type=typeof(string))]
        [OpenApiResponseBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<River>))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.NoContent, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.InternalServerError, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.BadRequest, "application/json", typeof(string))]        
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string name = req.Query["name"];


                var rivers = await _service.GetRivers(name);

                return rivers != null
                    ? (ActionResult)new OkObjectResult(rivers)
                    : new NoContentResult();
            }
            catch (Exception e)
            {
                log.LogError(new EventId(), e.StackTrace);
                throw;
            }
        }
        private Dictionary<string, string> GetNeededConfig(IConfiguration config)
        {
            var outConfig = new Dictionary<string, string>();
            outConfig.Add("riverTable", "USRivers");
            outConfig.Add("searchKey", config["azuresearch-key"]);
            outConfig.Add("baseUSGSURL", config["baseUSGSUrl"]);
            outConfig.Add("searchUrl", config["searchUrl"]);
            return outConfig;
        }
    }
}
