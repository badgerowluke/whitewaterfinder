FROM mcr.microsoft.com/dotnet/sdk:5.0 AS installer-env


ARG USER
ARG TOKEN
ARG ENDPOINT

RUN mkdir -p /home/site/wwwroot
COPY . /src/dotnet-function-app
COPY /src/dotnet-function-app/publish/rivers /home/site/wwwroot




# RUN dotnet nuget add source --username ${USER} \
#                             --password ${TOKEN} \
#                             --store-password-in-clear-text \
#                             --name github "${ENDPOINT}"

# RUN cd /src/dotnet-function-app && \
#     dotnet restore && \ 
#     dotnet publish ./whitewaterfinder.api.rivers/whitewaterfinder.api.rivers.csproj --no-restore --output /home/site/wwwroot

# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/dotnet:3.0-appservice
FROM mcr.microsoft.com/azure-functions/dotnet:3.0
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]