
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using System;

using whitewaterfinder.Core.Admin;
using whitewaterfinder.Repo.Admin;
using whitewaterfinder.BusinessObjects.Configuration;
using com.brgs.orm.Azure;
using SendGrid.Extensions.DependencyInjection;


[assembly: FunctionsStartup(typeof(whitewaterfinder.api.admin.Startup))]

namespace whitewaterfinder.api.admin
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var myConfig = config.Get<AdminFunctionsConfig>();

            builder.Services.AddSingleton<AdminFunctionsConfig>(sp => myConfig);
                
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IFunctionKeyManagementService, FunctionKeyManagementService>();
            builder.Services.AddSingleton<IAppSettings>(new AppSettings(config));
            builder.Services.AddSingleton<ICloudStorageAccount>(new CloudStorageAccountBuilder(config.GetConnectionString("blobStore")));
            builder.Services.AddSingleton<EmailRepositoryConfig>(sp => config.Get<EmailRepositoryConfig>());


            builder.Services.AddSendGrid(options => options.ApiKey = config["sendGridApiKey"]);
            builder.Services.AddScoped<IAzureStorage, AzureStorageFactory>();
            builder.Services.AddScoped<IEmailRepository, EmailRepository>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddApplicationInsightsTelemetry(config["APPINSIGHTS_INSTRUMENTATIONKEY"]);
        }
    }


}
