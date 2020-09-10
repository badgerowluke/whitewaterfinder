using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;

using whitewaterfinder.Core.Admin;

namespace whitewaterfinder.api.admin
{
    public class CreateFunctionKey
    {
        private readonly IFunctionKeyManagementService _util;
        public CreateFunctionKey(IFunctionKeyManagementService util)
        {
            _util = util;
        }
        
        [FunctionName("CreateFunctionKey")]
        [OpenApiOperation("FunctionKeys", "Function Keys", Summary="Generates an Azure Function Access Key", Description= "Generates an Azure Function Access Key")]
        [OpenApiParameter("appName", In=ParameterLocation.Path, Required=true, Type=typeof(string))]
        [OpenApiParameter("keyName", In=ParameterLocation.Path, Required=true, Type=typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.NoContent, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.InternalServerError, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.BadRequest, "application/json", typeof(string))]    
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "pfadmin/accesskeys/functions/{appName}/{keyName}")] HttpRequest req,
            string appName,

            string keyName,
            ILogger log)
        {
            var funcName = req.Query["function"];
            
            var token = await _util.GetAADAccessToken();
            var funcToken = await _util.GetFunctionAdminToken(appName, token);

            var funcKey = await _util.GetNewFunctionKey(keyName, funcToken, appName, funcName);



            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            return new OkObjectResult(funcKey);
        }
    }
}
