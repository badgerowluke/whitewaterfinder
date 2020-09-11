using System;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

using whitewaterfinder.Core.Rivers;
using whitewaterfinder.BusinessObjects.Rivers;


using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;
using System.Collections.Generic;
using System.Net;
using Microsoft.OpenApi.Models;


namespace whitewaterfinder.api
{
    public class Rivers
    {
        private readonly IRiverService _service;
        public Rivers( IRiverService service)
        {

            _service = service;


        }

        //TODO: update documentation, details here: https://github.com/aliencube/AzureFunctions.Extensions/blob/dev/docs/openapi-core.md
        [FunctionName("Rivers")]
        [OpenApiOperation("Rivers", "Rivers")]
        [OpenApiParameter("name", In=ParameterLocation.Query, Required=true, Description="name of the river  you'd like to find", Type=typeof(string))]
        [OpenApiResponseBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<River>))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.NoContent, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.InternalServerError, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.BadRequest, "application/json", typeof(string))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "rivers/")] HttpRequest req, ExecutionContext context)
        {
            try 
            {
                string name = req.Query["name"];
                
                
                var rivers = await _service.GetRivers(name);
                
                return rivers != null
                    ? (ActionResult)new OkObjectResult(rivers)
                    : new NoContentResult();
            } catch (Exception e )
            {

                throw e;
            }

        }
    }
}
