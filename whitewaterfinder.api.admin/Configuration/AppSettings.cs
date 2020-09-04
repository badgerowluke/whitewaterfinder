using Aliencube.AzureFunctions.Extensions.Configuration.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace whitewaterfinder.api.admin
{
    public interface IAppSettings
    {
        OpenApiInfo OpenApiInfo { get; }
        string SwaggerAuthKey { get; }

    }
    public class AppSettings : AppSettingsBase, IAppSettings
    {

        public AppSettings(IConfiguration config)
        {

            var openApiInfo = new OpenApiInfo();
            openApiInfo.Description = config["OpenApi_Info"];
            openApiInfo.Version =  config["OpenApi_Version"];
            openApiInfo.Title = config["OpenApi_Title"];
            OpenApiInfo = openApiInfo;
            SwaggerAuthKey = config["OpenApi_AuthKey"];
        }
        public OpenApiInfo OpenApiInfo { get; }
        public string SwaggerAuthKey { get; }
    }   
}