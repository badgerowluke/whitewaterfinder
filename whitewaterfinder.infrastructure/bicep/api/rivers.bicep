param location string
param appName string
param planId string

resource app 'Microsoft.Web/sites@2020-10-01' = {
  name: appName
  location: location
  kind: 'functionapp'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    enabled: true
    hostNameSslStates: [
      {
        name: '${appName}.azurewebsites.net'
        sslState: 'Disabled'
        hostType: 'Standard'
      }
      {
        name: '${appName}.scm.azurewebsites.net'
        sslState: 'Disabled'
        hostType: 'Repository'
      }
    ]
    serverFarmId: planId
    reserved: false
    scmSiteAlsoStopped: false
    clientAffinityEnabled: false
    clientCertEnabled: false
    hostNamesDisabled: false
    containerSize: 1536
    dailyMemoryTimeQuota: 0
    httpsOnly: true


  }
}




output riversKey string = listkeys('${app.id}/host/default', '2018-11-01').functionKeys.default
output appIdent string = app.identity.principalId
