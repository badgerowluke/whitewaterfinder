using com.brgs.orm.Azure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;

using Microsoft.Extensions.DependencyInjection;

using Azure.Identity;


using System;
using System.Reflection;
using whitewaterfinder.Core.Rivers;
using whitewaterfinder.Repo.Rivers;
using whitewaterfinder.BusinessObjects.Configuration;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Configuration.AzureKeyVault;

[assembly: FunctionsStartup(typeof(whitewaterfinder.api.rivers.Startup))]
namespace whitewaterfinder.api.rivers
{
    public class Startup : FunctionsStartup
    {
        IConfigurationRoot BuiltConfig { get; set; }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var myConfig = BuiltConfig.Get<RiverRepositoryConfig>();
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<ICloudStorageAccount>(new CloudStorageAccountBuilder(myConfig.StorageConnection));
            builder.Services.AddSingleton<IAzureTableBuilder, AzureStorageFactory>();
            builder.Services.AddSingleton<IConfiguration>(BuiltConfig);
            builder.Services.AddSingleton<IAppSettings>(new AppSettings(BuiltConfig));
            builder.Services.AddSingleton<RiverRepositoryConfig>(sp => myConfig);
            builder.Services.AddSingleton<IRiverRepository, RiverRepository>();
            builder.Services.AddSingleton<IRiverDetailRepository, RiverDetailRepository>();
            builder.Services.AddSingleton<IRiverService, RiverService>();

            builder.Services.AddApplicationInsightsTelemetry(BuiltConfig["APPINSIGHTS_INSTRUMENTATIONKEY"]);

        }
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var builtConfig = builder.ConfigurationBuilder
            .AddEnvironmentVariables()
            .Build();

            var context = builder.GetContext();

            if(!string.IsNullOrEmpty(context.EnvironmentName) 
                && context.EnvironmentName.ToLower() == "development")
            {

                BuiltConfig = builder.ConfigurationBuilder
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                    .AddEnvironmentVariables()
                    .Build();

            } else {

                try 
                {

                    var tokenProvider = new AzureServiceTokenProvider();
                    var kvClient = new KeyVaultClient(
                        new KeyVaultClient.AuthenticationCallback(
                            tokenProvider.KeyVaultTokenCallback)
                    );
                    BuiltConfig = builder.ConfigurationBuilder
                        .SetBasePath(Environment.CurrentDirectory)
                        // .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables()
                        .AddAzureKeyVault(builtConfig["keyVaultUrl"])
                        .Build();

                } catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }


            }
        }
    }
}
