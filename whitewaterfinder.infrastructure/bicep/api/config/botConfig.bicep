param botName string
param location string

resource botConfig 'Microsoft.Web/sites/config@2021-01-15' = {
  name: '${botName}/web'

  properties: {
    appSettings: [
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
        value: toLower(botName)
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
        name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
        value: '@Microsoft.KeyVault(VaultName=paddle-finder;SecretName=instrumentKey)'
      } 
      {
        name: 'MicrosoftAppId'
        value: '@Microsoft.KeyVault(VaultName=paddle-finder;SecretName=botAppId)'
      }
      {
        name: 'MicrosoftAppPassword'
        value: '@Microsoft.KeyVault(VaultName=paddle-finder;SecretName=botPassword)'
      }     
      {
        //so the app id legitimately is tightly coupled ot "apps" hosted at https://luis.ai
        //TODO: determine the best way to get the app id from luis and into this config item
        //current solution was to manually create the app in the LUIS portal and drop it as an input param
        //TODO: investifart if I can do it as part of a deployment script block here in the bicep
        name: 'LuisAppId'
        value: '@Microsoft.KeyVault(VaultName=paddle-finder;SecretName=luisAppId)'
      }
      {
        name: 'LuisAPIKey'
        value: '@Microsoft.KeyVault(VaultName=paddle-finder;SecretName=luisApiKey)'
      }
      {
        name: 'LuisAPIHostName'
        value: location
      }
      {
        name: 'ConectionName'
        value: 'WhiteWaterWebster'
      }
    ]    
  }
}
