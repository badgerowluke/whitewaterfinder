param appName string = 'paddle-finder'

@description('Location for all resources.')
param location string = resourceGroup().location

resource appInsights 'Microsoft.Insights/components@2015-05-01' = {
  name: appName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
    Request_Source: 'rest'
  }
}

resource logAnalytics 'Microsoft.OperationalInsights/workspaces@2021-06-01' = {
  name: '${appName}-logs'
  location: location
  properties: {
    sku: {
      name:'PerGB2018'
  
    }
    retentionInDays: 30
    

  }

}

output instrumentKey string = appInsights.properties.InstrumentationKey
output aiAppId string = appInsights.properties.AppId
