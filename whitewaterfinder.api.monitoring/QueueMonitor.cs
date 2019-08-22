using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;
using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;

namespace whitewaterfinder.api.monitoring
{
    public class QueueMonitor
    {
        public QueueMonitor()
        {
            
        }
        [FunctionName("QueueMonitor")]
        [OpenApiOperation("QueueMonitor")]
        public  void Run([TimerTrigger("0 */30 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
