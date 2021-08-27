param serviceprincipal string 
@secure()
param spObjectId string
@secure()
param sppassword string
param tenant string
@secure()
param adminId string
@secure()
param botPassword string
param luisAppId string

param storageAccountName string = 'waterfinder'

targetScope = 'subscription'

resource  newRg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: 'waterfinder'
  location: deployment().location
}

module storage 'bicep/storage/storage.bicep' = {
  name: 'paddle-finder'

  scope:newRg
}
module monitoring 'bicep/monitoring/insights.bicep' = {
  name: 'monitoring'
  scope: newRg
}
module search 'bicep/search/search.bicep' = {
  name: 'paddle-finder-search'
  scope: newRg
  params: {
    spid: serviceprincipal
    password: sppassword
    tenant: tenant
  }
}

// module registry 'bicep/registry/registry.bicep' = {
//   name: 'container-registry'
//   scope: newRg
//   params: {
//     name: 'paddlefinderregistry'
//     location: newRg.location
//   }
// }

module bot 'bicep/cognitiveservices/cognitiveservices.bicep' = {
  name: 'bot-deploy'
  scope: newRg
  params: {
    storageAccountName: newRg.name
    storageAccountKey: storage.outputs.storageKey
    botPassword: botPassword
    spid: serviceprincipal
    password: sppassword
    tenant: tenant
    instrumentKey: monitoring.outputs.instrumentKey
    aiAppId: monitoring.outputs.aiAppId
  }
}

module apis 'bicep/api/api.bicep' = {
  name: 'paddle-finder-apis'
  scope: newRg
}

module keyvault 'bicep/keyvault/kvtemplate.bicep' = {
  name: 'paddle-finder-keyvault'

  params: {
    adminId: adminId
    kvName: 'paddle-finder'
    location: newRg.location
    tenantId: tenant
    spnid: spObjectId 
    riversMI: apis.outputs.riversMI
    botMI: apis.outputs.botMI
    adminMI: apis.outputs.adminMI
    preferencesMI: apis.outputs.prefsMI
  }
  scope: newRg
}

module apim 'bicep/apim/apimdeploy.bicep' = {
  name: 'paddle-finder-apim'
  scope: newRg
  params: {
    riverFuncKey: apis.outputs.riversKey
    prefFuncKey: apis.outputs.usersKey
    botFuncKey: apis.outputs.botKey
    adminFuncKey: apis.outputs.adminKey
  }
}

module secrets 'bicep/keyvault/kvsecrets.bicep' = {
  name: 'paddle-finder-secrets'
  scope: newRg
  params: {
    kvName: 'paddle-finder'
    apimKey: apim.outputs.subkey
    instrumentKey: monitoring.outputs.instrumentKey
    storageKey: storage.outputs.storageKey
    searchKey: search.outputs.searchKey
    storageAccountName: storageAccountName
    botAppId: bot.outputs.msaAppId
    botPassword: botPassword
    luisAppId: luisAppId
    luisApiKey: bot.outputs.luisId
  }
}

module config 'bicep/api/config/config.bicep' = {
  scope: newRg
  dependsOn: [
    apis
    secrets
  ]
  name: 'app-config'
  params: {
    appName: 'paddle-finder'
    botName: 'paddle-finder-webster'
    adminName: 'paddle-finder-admin'
    prefsName: 'paddle-finder-preferences'
    location: newRg.location
  }
}

