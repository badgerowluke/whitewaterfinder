using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using whitewaterfinder.Core.Rivers;

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

        private readonly IRiverService _service;
        public RiverDetails( IRiverService service, IConfiguration settings)
        {

            _service = service;


        }
        //TODO: remove this comment.  maybe by setting an env variable on the task?

        [FunctionName("RiverDetails")]
        [OpenApiOperation("Rivers")]
        [OpenApiParameter("riverCode", In=ParameterLocation.Path, Required=true, Description="The USGS code for the chosen river", Type=typeof(string))]
        [OpenApiResponseBody(HttpStatusCode.OK, "application/json", typeof(River))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.NoContent, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.InternalServerError, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.BadRequest, "application/json", typeof(string))]        
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "rivers/{riverCode}/details/")] HttpRequest req,
            string riverCode, ILogger log, ExecutionContext context)
        {
            try
            {

                var riverDetails = await _service.GetRiverDetails(riverCode);

                return !string.IsNullOrEmpty(riverCode)
                    ? (ActionResult)new OkObjectResult(riverDetails)
                    : new NoContentResult();

            } catch( Exception e) 
            {
                log.LogError(new EventId(), e.StackTrace);
                throw;
            }

        }
        private Dictionary<string, string> GetNeededConfig(IConfiguration config)
        {
            var outConfig = new Dictionary<string, string>();
            outConfig.Add("baseUSGSURL", config["baseUSGSUrl"]);
            return outConfig;
        }
    }
}
