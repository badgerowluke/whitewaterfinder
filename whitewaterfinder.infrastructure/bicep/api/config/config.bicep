param appName string
param botName string
param adminName string
param prefsName string
param location string
param searchName string

module riverConfig 'riverConfig.bicep' = {
  name: 'rivers-config'
  params: {
    appName: appName
    searchServiceName:searchName
  }
}

module botConfig 'botConfig.bicep' = {
  name: 'bot-config'
  params: {
    botName: botName
    location: location
  }
}

module adminConfig 'adminConfig.bicep' = {
  name: 'admin-config'
  params: {
    adminName: adminName
  }
}

module userConfig 'usersConfig.bicep' = {
  name: 'users-config'
  params: {
    name: prefsName
  }
}
