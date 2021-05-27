@description('Location for all resources.')
param location string = resourceGroup().location
param botAppName string = 'WhitewaterWebster'
param botInsightsName string = 'paddle-finder'
param msftAppId string
param storageAccountName string

var storageAccountId = '${resourceGroup().id}/providers/Microsoft.Storage/storageAccounts/${storageAccountName}'

resource botAppName_resource 'Microsoft.Web/serverfarms@2017-08-01' = {
  kind: 'app'
  name: botAppName
  location: location
  sku: {
    name: 'F1'
    tier: 'Free'
    size: 'F1'
    family: 'F'
    capacity: 0
  }
  properties: {
    name: botAppName
    perSiteScaling: false
    reserved: false
    targetWorkerCount: 0
    targetWorkerSizeId: 0
  }
}

resource Microsoft_Web_sites_botAppName 'Microsoft.Web/sites@2018-11-01' = {
  name: botAppName
  location: location
  tags: null
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    name: botAppName
    siteConfig: {
      appSettings: [
        {
          name: 'stateStore'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${listKeys(storageAccountId, '2015-05-01-preview').key1}'
        }
        {
          name: 'LuisAPIHostName'
          value: location
        }
        {
          name: 'MicrosoftAppId'
          value: msftAppId
        }
        {
          name: 'MicrosoftAppPassword'
          value: 'tacospastapizza4@11'
        }
        {
          name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
          value: reference(resourceId('microsoft.insights/components/', botInsightsName), '2015-05-01').InstrumentationKey
        }
        {
          name: 'ApplicationInsightsAgent_EXTENSION_VERSION'
          value: '~2'
        }
        {
          name: 'XDT_MicrosoftApplicationInsights_Mode'
          value: 'default'
        }
        {
          name: 'DiagnosticServices_EXTENSION_VERSION'
          value: 'disabled'
        }
        {
          name: 'APPINSIGHTS_PROFILERFEATURE_VERSION'
          value: 'disabled'
        }
        {
          name: 'APPINSIGHTS_SNAPSHOTFEATURE_VERSION'
          value: 'disabled'
        }
        {
          name: 'InstrumentationEngine_EXTENSION_VERSION'
          value: 'disabled'
        }
        {
          name: 'SnapshotDebugger_EXTENSION_VERSION'
          value: 'disabled'
        }
        {
          name: 'XDT_MicrosoftApplicationInsights_BaseExtensions'
          value: 'disabled'
        }
      ]
      metadata: [
        {
          name: 'CURRENT_STACK'
          value: 'dotnetcore'
        }
      ]
      alwaysOn: false
    }
    serverFarmId: botAppName_resource.id
    hostingEnvironment: ''
    clientAffinityEnabled: true
  }
}