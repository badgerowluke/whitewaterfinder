param name string
resource usersConfig 'Microsoft.Web/sites/config@2021-01-15' = {
  name: '${name}/web'
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
        value: toLower(name)
      }
      {
        name: 'FUNCTIONS_EXTENSION_VERSION'
        value: '~2'
      }
      {
        name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
        value: '@Microsoft.KeyVault(VaultName=paddle-finder;SecretName=instrumentKey)'
      }
      {
        name: 'WEBSITE_NODE_DEFAULT_VERSION'
        value: '10.22.0'
      }      
    ]
  }
}
