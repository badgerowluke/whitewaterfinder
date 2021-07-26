param location string
param preferencesApp string

param planId string
param storageAccountName string
param instrumentKey string

@secure()
param storageKey string


resource app 'Microsoft.Web/sites@2016-08-01' = {
  name: preferencesApp
  location: location
  kind: 'functionapp'
  properties: {
    enabled: true
    hostNameSslStates: [
      {
        name: '${preferencesApp}.azurewebsites.net'
        sslState: 'Disabled'
        hostType: 'Standard'
      }
      {
        name: '${preferencesApp}.scm.azurewebsites.net'
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
    httpsOnly: false
    siteConfig: {
      appSettings: [
        {
          name: 'blobStore'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${storageKey}'
        }
        {
          name: 'AzureWebJobsStorage'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${storageKey}'
        }
        {
          name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${storageKey}'
        }
        {
          name: 'WEBSITE_CONTENTSHARE'
          value: toLower(preferencesApp)
        }
        {
          name: 'FUNCTIONS_EXTENSION_VERSION'
          value: '~2'
        }
        {
          name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
          value: instrumentKey
        }
        {
          name: 'WEBSITE_NODE_DEFAULT_VERSION'
          value: '10.22.0'
        }
      ]
    }
  }
}

output prefsKey string = listkeys('${app.id}/host/default', '2018-11-01').functionKeys.default
