param adminName string
resource adminConfig 'Microsoft.Web/sites/config@2021-01-15' = {
  name: '${adminName}/web'
  properties: {
    appSettings: [
      {
        name: 'blobStore'
        value: '@Microsoft.KeyVault(VaultName=paddle-finder;SecretName=storageConnection)'
      }
      {
        name: 'AzureWebJobsStorage'
        value: '@Microsoft.KeyVault(VaultName=paddle-finder;SecretName=storageConnection)'
      }
      {
        name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
        value: '@Microsoft.KeyVault(VaultName=paddle-finder;SecretName=storageConnection)'
      }
      {
        name: 'WEBSITE_CONTENTSHARE'
        value: toLower(adminName)
      }
      {
        name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
        value: '@Microsoft.KeyVault(VaultName=paddle-finder;SecretName=instrumentKey)'
      }
      {
        name: 'FUNCTIONS_EXTENSION_VERSION'
        value: '~4'
      }
      {
        name: 'FUNCTIONS_WORKER_RUNTIME'
        value: 'dotnet'
      }      
    ]
  }
}
