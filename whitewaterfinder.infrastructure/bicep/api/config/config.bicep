param appName string
param botName string
param location string

module riverConfig 'riverConfig.bicep' = {
  name: 'rivers-config'
  params: {
    appName: appName
  }
}

module botConfig 'botConfig.bicep' = {
  name: 'bot-config'
  params: {
    botName: botName
    location: location

  }
}
