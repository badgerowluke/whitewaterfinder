param appName string
param searchServiceName string


resource riversConfig 'Microsoft.Web/sites/config@2021-01-15' = {
  name: '${appName}/web'

  properties: {
    appSettings: [
      {
        name: 'BASEUSGSURL'
        value: 'https://waterservices.usgs.gov/nwis/iv/?format=json&indent=on&'
      }
      {
        name: 'AZURESEARCHURL'
        value: 'https://${searchServiceName}.search.windows.net/indexes/riversearch-index/docs/suggest?suggesterName=RiverName&api-version=2019-05-06&fuzzy=false&$top=20&&$select=Name,RiverId,Latitude,Longitude&search="'
      }
      {
        name: 'SearchKey'
        value: '@Microsoft.KeyVault(VaultName=${appName};SecretName=searchKey)'
      }
      {
        name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
        value: '@Microsoft.KeyVault(VaultName=${appName};SecretName=instrumentKey)'
      }
      {
        name: 'AzureWebJobsStorage'
        value: '@Microsoft.KeyVault(VaultName=${appName};SecretName=storageConnection)'
      }
      {
        name: 'AzureWebJobsDashboard'
        value: '@Microsoft.KeyVault(VaultName=${appName};SecretName=storageConnection)'
      }
      {
        name: 'FUNCTIONS_EXTENSION_VERSION'
        value: '~4'
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
        value: '@Microsoft.KeyVault(VaultName=${appName};SecretName=storageConnection)'
      }
      {
        name: 'WEBSITE_NODE_DEFAULT_VERSION'
        value: '8.11.1'
      }
      {
        name: 'storageConnection'
        value: '@Microsoft.KeyVault(VaultName=${appName};SecretName=storageConnection)'
      }

      {
        name: 'APPINSIGHTS_CONNECTION_STRING'
        value: '@Microsoft.KeyVault(VaultName=${appName};SecretName=instrumentConnection)'
      }
      {
        name: 'ApplicationInsightsAgent_EXTENSION_VERSION'
        value: '~2'
      }
      {
        name: 'keyVaultName'
        value: 'https://${appName}.vault.azure.net'
      }
      {
        name: 'riverTable'
        value: 'USRivers'
      }
    ]
  }
}
