param botName string
param location string

param planId string
param storageAccountName string
param msftAppId string
param instrumentKey string
@secure()
param botPassword string
@secure()
param luisApiKey string
param luisAppId string

@secure()
param storageKey string


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
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${storageKey}'
        }
        {
          name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${storageKey}'
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
          value: instrumentKey
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
          //TODO: investifart if I can do it as part of a deployment script block here in the bicep
          //meaningless trigger bump
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
