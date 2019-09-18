using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace whitewaterfinder.api.monitoring
{
    public static class UploadWatcher
    {
        [FunctionName("UploadWatcher")]
        public static void Run([BlobTrigger("data/{name}", Connection = "blob-store")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
