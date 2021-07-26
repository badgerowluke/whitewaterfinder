@description('Location for all resources.')
param location string = resourceGroup().location
param appName string = 'paddle-finder'
param appPlanName string = 'WaterFinderPlan'
param preferencesApp string = 'paddle-finder-preferences'
param storageAccountName string = 'waterfinder'

param botAppId string
param instrumentKey string
@secure()
param storageKey string

@secure()
param botPassword string

param botName string = 'paddle-finder-webster'
param adminName string = 'paddle-finder-admin'
@secure()
param luisApiKey string
@secure()
param luisAppId string

@secure()
param searchKey string



resource appPlan 'Microsoft.Web/serverfarms@2016-09-01' = {
  name: appPlanName
  location: location
  sku: {
    name: 'Y1'
    tier: 'Dynamic'
    size: 'Y1'
    family: 'Y'
    capacity: 0
  }
  kind: 'functionapp'
  properties: {
    name: appPlanName
    perSiteScaling: false
    reserved: false
    targetWorkerCount: 0
    targetWorkerSizeId: 0
  }
}

module rivers 'rivers.bicep' = {
   name: 'rivers-api'

   params: {
     appName: appName
     location: location
     planId: appPlan.id
   }
}

module preferences 'users.bicep' = {
  name: 'preferences-api'

  params: {
    preferencesApp: preferencesApp
    location: location
    planId: appPlan.id
    storageAccountName: storageAccountName
    instrumentKey: instrumentKey
    storageKey: storageKey
  }
}

module bot 'bot.bicep' ={
  name:'bot-api'

  params: {
    botName: botName
    msftAppId: botAppId
    botPassword: botPassword
    luisApiKey: luisApiKey
    luisAppId: luisAppId
    location: location
    planId: appPlan.id
    instrumentKey: instrumentKey
    storageAccountName: storageAccountName
    storageKey: storageKey

  }
}



module admin 'admin.bicep' ={ 
  name: 'admin-api'
  dependsOn: [
    appPlan
  ]
  params: {
    adminName: adminName
    instrumentKey: instrumentKey
    location: location
    planId: appPlan.id
    storageAccountName: storageAccountName
    storageKey: storageKey
    
  }
}

output riversKey string = rivers.outputs.riversKey
output usersKey string = preferences.outputs.prefsKey
output botKey string = bot.outputs.botKey
output adminKey string = admin.outputs.adminKey
output riversMI string = rivers.outputs.appIdent
