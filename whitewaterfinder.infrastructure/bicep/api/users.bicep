param location string
param preferencesApp string
param planId string
param storageAccountName string
param instrumentKey string

@secure()
param storageKey string


resource app 'Microsoft.Web/sites@2016-08-01' = {
  name: preferencesApp
  location: location
  kind: 'functionapp'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    enabled: true
    hostNameSslStates: [
      {
        name: '${preferencesApp}.azurewebsites.net'
        sslState: 'Disabled'
        hostType: 'Standard'
      }
      {
        name: '${preferencesApp}.scm.azurewebsites.net'
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

output prefsKey string = listkeys('${app.id}/host/default', '2018-11-01').functionKeys.default
output appIdent string = app.identity.principalId
