FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS installer-env

#TODO: we need to make sure that we get configuration injected into the application
#TODO: we need to make sure that we get our configuration secured.

ARG USER
ARG TOKEN
ARG ENDPOINT

RUN mkdir -p /home/site/wwwroot
COPY ./publish/rivers /home/site/wwwroot

FROM mcr.microsoft.com/azure-functions/dotnet:3.0

ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true


ENV keyVaultUrl "https://paddle-finder.vault.azure.net"


ENV baseUSGSUrl https://waterservices.usgs.gov/nwis/iv/?format=json&indent=on&
ENV azureSearchUrl "https://waterfindersearch.search.windows.net/indexes/riversearch-index/docs/suggest?suggesterName=RiverName&api-version=2019-05-06&fuzzy=false&$top=20&&$select=Name,RiverId,Latitude,Longitude&search="
ENV WEBSITE_CONTENT_SHARE "paddle-finder"
ENV riverTable "USRivers"
ENV APPINSIGHTS_INSTRUMENTATIONKEY "07b9d01f-ba67-49aa-892f-c77ccdbefd73"


COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]