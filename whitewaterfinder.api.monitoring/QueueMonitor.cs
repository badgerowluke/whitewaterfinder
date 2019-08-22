using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;

namespace whitewaterfinder.api.monitoring
{
    public class QueueMonitor
    {
        public QueueMonitor()
        {
            
        }
        private static readonly TelemetryClient tc = new TelemetryClient();
        [FunctionName("QueueMonitor")]
        public static void Run([TimerTrigger("0 */30 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
