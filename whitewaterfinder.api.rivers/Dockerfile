FROM mcr.microsoft.com/dotnet/sdk:5.0 AS installer-env
# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/dotnet:3.0-appservice
FROM mcr.microsoft.com/azure-functions/dotnet:3.0


RUN mkdir -p /home/site/wwwroot
ADD /publish/rivers /publish/rivers
COPY /publish/rivers /home/site/wwwroot


ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]