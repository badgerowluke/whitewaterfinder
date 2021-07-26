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
    instrumentKey: storage.outputs.instrumentKey
    aiAppId: storage.outputs.aiAppId
  }
}

module apis 'bicep/api/api.bicep' = {
  name: 'paddle-finder-apis'

  scope: newRg
  params: {
    botAppId: bot.outputs.msaAppId
    luisApiKey: bot.outputs.luisId
    luisAppId: luisAppId
    botPassword: botPassword
    instrumentKey: storage.outputs.instrumentKey
    storageKey: storage.outputs.storageKey
    storageAccountName: storageAccountName
    searchKey: search.outputs.searchKey
 
  }
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
    instrumentKey: storage.outputs.instrumentKey
    storageKey: storage.outputs.storageKey
    searchKey: search.outputs.searchKey
    storageAccountName: storageAccountName
  }
}

module config 'bicep/api/config.bicep' = {
  scope: newRg
  dependsOn: [
    apis
    secrets
  ]
  name: 'app-config'
  params: {
    appName: 'paddle-finder'
    instrumentKey: storage.outputs.instrumentKey
    storageAccountName: storageAccountName
    storageKey: storage.outputs.storageKey
  }
  
}

