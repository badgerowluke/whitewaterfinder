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
using whitewaterfinder.BusinessObjects.Messaging;


namespace whitewaterfinder.api.admin
{
    public class QueueNewMailMessage
    {
        private readonly IEmailService _emails;
        public QueueNewMailMessage(IEmailService emailService)
        {
            _emails = emailService;
        }
        [FunctionName("QueueNewMailMessage")]
        [OpenApiOperation("QueueNewMailMessage", "Queue New Email", Summary="POST up a new Mail message for Sendgrid", 
        Description="Via a POST call, submit a mail message to a queue that will be processed by SendGrid")]
        [OpenApiRequestBody("application/json", typeof(WaterfinderEmailMessage))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.NoContent, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.InternalServerError, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.BadRequest, "application/json", typeof(string))]   
        [OpenApiResponseBody(System.Net.HttpStatusCode.OK, "application/json", typeof(string))] 
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "pfadmin/email")] HttpRequest req,
            ILogger log)
        {


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var message = JsonConvert.DeserializeObject<WaterfinderEmailMessage>(requestBody);

            await _emails.WriteMessageToQueue(message);

            return new OkObjectResult("message is queued");
        }
    }
}
