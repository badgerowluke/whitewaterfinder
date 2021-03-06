param serviceprincipal string 
@secure()
param sppassword string
param tenant string
param adminId string
@secure()
param botPassword string
param luisAppId string

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

module registry 'bicep/registry/registry.bicep' = {
  name: 'container-registry'
  scope: newRg
  params: {
    name: 'paddlefinderregistry'
    location: newRg.location
  }
}

module bot 'bicep/cognitiveservices/cognitiveservices.bicep' = {
  name: 'bot-deploy'
  scope: newRg
  params: {
    botPassword: botPassword
    spid: serviceprincipal
    password: sppassword
    tenant: tenant
  }
}

module apis 'bicep/api/api.bicep' = {
  name: 'paddle-finder-apis'
  dependsOn: [ 
    storage 
  ]
  scope: newRg
  params: {
    botAppId: bot.outputs.msaAppId
    luisApiKey: bot.outputs.luisId
    luisAppId: luisAppId
    botPassword: botPassword
    azureSearchKey: search.outputs.searchKey
    baseUSGSUrl: 'https://waterservices.usgs.gov/nwis/iv/?format=json&indent=on&'
    searchUrl: 'https://waterfindersearch.search.windows.net/indexes/riversearch-index/docs/suggest?suggesterName=RiverName&api-version=2019-05-06&fuzzy=false&$top=20&&$select=Name,RiverId,Latitude,Longitude&search="'
  }
}

module keyvault 'bicep/keyvault/kvtemplate.bicep' = {
  name: 'paddle-finder-keyvault'

  params: {
    adminId: adminId
    kvName: 'paddle-finder'
    location: newRg.location
    tenantId: tenant
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





