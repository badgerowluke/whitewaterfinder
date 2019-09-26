using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;
using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;
using Microsoft.Extensions.Configuration;
using com.brgs.orm.Azure;

namespace whitewaterfinder.api.monitoring
{
    public class QueueMonitor
    {
        private readonly IAzureStorage _storage;

        public QueueMonitor(IAzureStorage storage   )
        {
            _storage = storage;
        }
        [FunctionName("QueueMonitor")]
        [OpenApiOperation("QueueMonitor")]
        public  void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Queue ran");            

        }
    }
}
