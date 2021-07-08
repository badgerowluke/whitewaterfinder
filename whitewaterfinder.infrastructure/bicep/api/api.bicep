@description('Location for all resources.')
param location string = resourceGroup().location
param appName string = 'paddle-finder'
param appPlanName string = 'WaterFinderPlan'
param preferencesApp string = 'paddle-finder-preferences'
param storageAccountName string = 'waterfinder'
param azureSearchKey string
param baseUSGSUrl string
param searchUrl string
param botAppId string
@secure()
param botPassword string

param botName string = 'paddle-finder-webster'
param adminName string = 'paddle-finder-admin'
param luisApiKey string

var storageAccountId = '${resourceGroup().id}/providers/Microsoft.Storage/storageAccounts/${storageAccountName}'


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
   dependsOn: [
     appPlan
   ]
   params: {
     appName: appName
     location: location
     planId: appPlan.id
     storageAccountName: storageAccountName
     storageAccountId: storageAccountId
     azureSearchKey: azureSearchKey
     baseUSGSUrl: baseUSGSUrl
     searchUrl: searchUrl

   }
}

module preferences 'users.bicep' = {
  name: 'preferences-api'
  dependsOn: [
    appPlan
  ]
  params: {
    preferencesApp: preferencesApp
    appName: appName
    location: location
    planId: appPlan.id
    storageAccountName: storageAccountName
    storageAccountId: storageAccountId
  }

}

module bot 'bot.bicep' ={
  name:'bot-api'
  dependsOn: [
    appPlan
  ]
  params: {
    botName: botName
    msftAppId: botAppId
    botPassword: botPassword
    luisApiKey: luisApiKey
    appName: appName
    location: location
    planId: appPlan.id
    storageAccountName: storageAccountName
    storageAccountId: storageAccountId

  }
}



module admin 'admin.bicep' ={ 
  name: 'admin-api'
  dependsOn: [
    appPlan
  ]
  params: {
    adminName: adminName
    appName: appName
    location: location
    planId: appPlan.id
    storageAccountName: storageAccountName
    storageAccountId: storageAccountId
    
  }
}

output riversKey string = rivers.outputs.riversKey
output usersKey string = preferences.outputs.prefsKey
output botKey string = bot.outputs.botKey
output adminKey string = admin.outputs.adminKey
