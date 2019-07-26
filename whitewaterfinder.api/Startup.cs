using com.brgs.orm.Azure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            builder.Services.AddSingleton<ICloudStorageAccount>(new CloudStorageAccountBuilder(config.GetConnectionString("blob-store")));
            builder.Services.AddSingleton<IAppSettings>(new AppSettings(config));
        }
    }
}
