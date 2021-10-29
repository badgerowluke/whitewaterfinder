FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS installer-env

#TODO: we need to make sure that we get configuration injected into the application
#TODO: we need to make sure that we get our configuration secured.

ARG USER
ARG TOKEN
ARG ENDPOINT

RUN mkdir -p /home/site/wwwroot
COPY ./publish/rivers /home/site/wwwroot

ENV BASEUSGSURL="https://waterservices.usgs.gov/nwis/iv/?format=json&indent=on&"
ENV FUNCTIONS_EXTENSION_VERSION="~3"
ENV FUNCTIONS_WORKER_RUNTIME="dotnet"
ENV WEBSITE_CONTENT_SHARE="paddle-finder"


FROM mcr.microsoft.com/azure-functions/dotnet:3.0

ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]