param location string
param appName string
param planId string
param storageAccountName string
param storageAccountId string
param azureSearchKey string
param baseUSGSUrl string
param searchUrl string

resource app 'Microsoft.Web/sites@2016-08-01' = {
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
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${listKeys(storageAccountId, '2015-05-01-preview').key1}'
        }
        {
          name: 'AzureWebJobsDashboard'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${listKeys(storageAccountId, '2015-05-01-preview').key1}'
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
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${listKeys(storageAccountId, '2015-05-01-preview').key1}'
        }
        {
          name: 'WEBSITE_NODE_DEFAULT_VERSION'
          value: '8.11.1'
        }
        {
          name: 'blobStore'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${listKeys(storageAccountId, '2015-05-01-preview').key1}'
        }
        {
          name: 'azureSearchKey'
          value: azureSearchKey
        }
        {
          name: 'baseUSGSUrl'
          value: baseUSGSUrl
        }
        {
          name: 'azureSearchUrl'
          value: searchUrl
        }
        {
          name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
          value: reference(resourceId('microsoft.insights/components/', appName), '2015-05-01').InstrumentationKey
        }
        {
          name: 'APPINSIGHTS_CONNECTION_STRING'
          value: 'InstrumentationKey=${reference(resourceId('microsoft.insights/components/', appName), '2015-05-01').InstrumentationKey}'
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
