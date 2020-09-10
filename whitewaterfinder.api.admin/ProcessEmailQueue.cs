using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using whitewaterfinder.Core.Admin;
using whitewaterfinder.BusinessObjects.Messaging;
using System.Threading.Tasks;

namespace whitewaterfinder.api.admin
{
    public class ProcessEmailQueue
    {
        private readonly IEmailService _emails;
        public ProcessEmailQueue(IEmailService email)
        {
            _emails = email;
        }
        [FunctionName("ProcessEmailQueue")]
        public async Task Run([QueueTrigger("pf-email-messages", Connection = "")]string myQueueItem, ILogger log)
        {
            var message = JsonConvert.DeserializeObject<WaterfinderEmailMessage>(myQueueItem);
            var sendGridMessage = _emails.CreateMessage(message);
            await _emails.SendMessageAsync(sendGridMessage);  
        }
    }
}
