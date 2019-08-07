using com.brgs.orm.Azure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using System;
using whitewaterfinder.Core;
using whitewaterfinder.Repo;

[assembly: FunctionsStartup(typeof(whitewaterfinder.api.Startup))]

namespace whitewaterfinder.api
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
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<ICloudStorageAccount>(new CloudStorageAccountBuilder(config.GetConnectionString("blob-store")));
            builder.Services.AddSingleton<IAzureStorage, AzureStorageFactory>();
            builder.Services.AddSingleton<IConfiguration>(config);
            // builder.Services.AddSingleton<IAppSettings>(new AppSettings(config));
            builder.Services.AddSingleton<IRiverRepository, RiverRepository>();
            builder.Services.AddSingleton<IRiverDetailRepository, RiverDetailRepository>();
            builder.Services.AddSingleton<IRiverService, RiverService>();
        }
    }
}
