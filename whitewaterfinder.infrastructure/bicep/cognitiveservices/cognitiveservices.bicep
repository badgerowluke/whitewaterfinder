param luisName string = 'webster-luis'
param authoringName string = 'webster-luis-authoring'
param botAppName string = 'WhitewaterWebster'
param msftAppId string = ''
param botInsightsName string = 'paddle-finder'

@description('Location for all resources.')
param location string = resourceGroup().location

resource authoringName_resource 'Microsoft.CognitiveServices/accounts@2017-04-18' = {
  kind: 'LUIS.Authoring'
  name: authoringName
  location: 'westus'
  sku: {
    name: 'F0'
  }
}

resource luisName_resource 'Microsoft.CognitiveServices/accounts@2017-04-18' = {
  kind: 'LUIS'
  name: luisName
  location: location
  sku: {
    name: 'S0'
  }
  dependsOn: [
    authoringName_resource
  ]
}

resource botAppName_resource 'Microsoft.BotService/botServices@2018-07-12' = {
  kind: 'sdk'
  name: botAppName
  location: 'global'
  sku: {
    name: 'F0'
  }
  properties: {
    displayName: botAppName
    iconUrl: 'https://docs.botframework.com/static/devportal/client/images/bot-framework-default.png'
    endpoint: 'https://whitewater-finder.azure-api.net/webster/messages'
    msaAppId: msftAppId
    developerAppInsightKey: reference(resourceId('microsoft.insights/components/', botInsightsName), '2015-05-01').InstrumentationKey
    developerAppInsightsApplicationId: reference(resourceId('microsoft.insights/components', botInsightsName), '2015-05-01').appId
    luisAppIds: []
  }
}

output luisId string = listKeys(luisName_resource.id, '2016-02-01-preview').key1
output luisEndpoint string = reference(luisName_resource.id, '2017-04-18').endpoint