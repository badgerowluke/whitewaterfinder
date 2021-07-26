param appName string

module riverConfig 'riverConfig.bicep' = {
  name: 'rivers-config'
  params: {
    appName: appName
  }
}
