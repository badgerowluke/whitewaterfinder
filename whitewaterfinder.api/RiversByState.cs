
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;
using whitewaterfinder.BusinessObjects.Rivers;
using whitewaterfinder.Core.Rivers;

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
        [OpenApiOperation("ByState")]
        [OpenApiParameter("state", In=ParameterLocation.Query, Required=true, Description="The State you'd like to search within", Type=typeof(string))]
        [OpenApiResponseBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<River>))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.NoContent, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.InternalServerError, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.BadRequest, "application/json", typeof(string))]        
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "rivers/{state}")] HttpRequest req,
            string state, ILogger log)
        {
            try
            {
                string name = req.Query["state"];


                var rivers = await _service.GetRivers(state);

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
    }
}