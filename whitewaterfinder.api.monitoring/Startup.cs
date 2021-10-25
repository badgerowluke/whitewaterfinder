using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using System;
using com.brgs.orm.Azure;

[assembly: FunctionsStartup(typeof(whitewaterfinder.api.monitoring.Startup))]

namespace whitewaterfinder.api.monitoring
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<IAppSettings>(new AppSettings(config));    
            builder.Services.AddSingleton<ICloudStorageAccount>(new CloudStorageAccountBuilder(config.GetConnectionString("blob-store")));                
            builder.Services.AddSingleton<IAzureStorage,AzureQueueBuilder>();
            builder.Services.AddApplicationInsightsTelemetry(config["APPINSIGHTS_INSTRUMENTATIONKEY"]);
        }
    }
}