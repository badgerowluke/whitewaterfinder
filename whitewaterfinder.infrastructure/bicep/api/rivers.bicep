param location string
param appName string
param planId string
param storageAccountName string

param azureSearchKey string
param instrumentKey string

@secure()
param storageKey string

resource app 'Microsoft.Web/sites@2020-10-01' = {
  name: appName
  location: location
  kind: 'functionapp'
  properties: {
    enabled: true
    hostNameSslStates: [
      {
        name: '${appName}.azurewebsites.net'
        sslState: 'Disabled'
        hostType: 'Standard'
      }
      {
        name: '${appName}.scm.azurewebsites.net'
        sslState: 'Disabled'
        hostType: 'Repository'
      }
    ]
    serverFarmId: planId
    reserved: false
    scmSiteAlsoStopped: false
    clientAffinityEnabled: false
    clientCertEnabled: false
    hostNamesDisabled: false
    containerSize: 1536
    dailyMemoryTimeQuota: 0
    httpsOnly: true
    siteConfig: {
      appSettings: [
        {
          name: 'AzureWebJobsStorage'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${storageKey}'
        }
        {
          name: 'AzureWebJobsDashboard'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${storageKey}'
        }
        {
          name: 'FUNCTIONS_EXTENSION_VERSION'
          value: '~3'
        }
        {
          name: 'FUNCTIONS_WORKER_RUNTIME'
          value: 'dotnet'
        }
        {
          name: 'WEBSITE_CONTENTSHARE'
          value: toLower(appName)
        }
        {
          name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${storageKey}'
        }
        {
          name: 'WEBSITE_NODE_DEFAULT_VERSION'
          value: '8.11.1'
        }
        {
          name: 'blobStore'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${storageKey}'
        }
        {
          name: 'azureSearchKey'
          value: azureSearchKey
        }
        {
          name: 'baseUSGSUrl'
          value: 'https://waterservices.usgs.gov/nwis/iv/?format=json&indent=on&'
        }
        {
          name: 'azureSearchUrl'
          value: 'https://waterfindersearch.search.windows.net/indexes/riversearch-index/docs/suggest?suggesterName=RiverName&api-version=2019-05-06&fuzzy=false&$top=20&&$select=Name,RiverId,Latitude,Longitude&search="'
        }
        {
          name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
          value: instrumentKey
        }
        {
          name: 'APPINSIGHTS_CONNECTION_STRING'
          value: 'InstrumentationKey=${instrumentKey}'
        }
        {
          name: 'ApplicationInsightsAgent_EXTENSION_VERSION'
          value: '~2'
        }
      ]
    }
  }
}

output riversKey string = listkeys('${app.id}/host/default', '2018-11-01').functionKeys.default
