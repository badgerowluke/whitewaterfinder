param botName string
param location string
param appName string
param planId string
param storageAccountName string
param storageAccountId string
param msftAppId string
@secure()
param botPassword string
@secure()
param luisApiKey string
param luisAppId string


resource app 'Microsoft.Web/sites@2016-08-01' = {
  name: botName
  location: location
  kind: 'functionapp'
  properties: {
    enabled: true
    hostNameSslStates: [
      {
        name: '${botName}.azurewebsites.net'
        sslState: 'Disabled'
        hostType: 'Standard'
      }
      {
        name: '${botName}.scm.azurewebsites.net'
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
          name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${listKeys(storageAccountId, '2015-05-01-preview').key1}'
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
          value: reference(resourceId('microsoft.insights/components/', appName), '2015-05-01').InstrumentationKey
        }   
        {
          name: 'MicrosoftAppId'
          value: msftAppId
        }
        {
          name: 'MicrosoftAppPassword'
          value: botPassword
        }     
        {
          //so the app id legitimately is tightly coupled ot "apps" hosted at https://luis.ai
          //TODO: determine the best way to get the app id from luis and into this config item
          //current solution was to manually create the app in the LUIS portal and drop it as an input param
          name: 'LuisAppId'
          value: luisAppId
        }
        {
          name: 'LuisAPIKey'
          value: luisApiKey
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
}

output botKey string = listkeys('${app.id}/host/default', '2018-11-01').functionKeys.default
