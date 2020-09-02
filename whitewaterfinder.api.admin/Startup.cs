
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using System;

using whitewaterfinder.Core.Admin;
using whitewaterfinder.BusinessObjects.Configuration;


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
                builder.Services.AddSingleton<IFunctionKeyManagementUtility, FunctionKeyManagementUtility>();
        }
    }


}
