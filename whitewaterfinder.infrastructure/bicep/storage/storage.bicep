@allowed([
  'Standard_LRS'
  'Standard_GRS'
  'Standard_ZRS'
  'Premium_LRS'
])
@description('Storage Account type')
param storageAccountType string = 'Standard_LRS'
param appName string = 'paddle-finder'

@description('Location for all resources.')
param location string = resourceGroup().location
param botApp string = 'paddle-finder-webster'
param preferencesApp string = 'paddle-finder-preferences'
param storageAccountName string = 'waterfinder'




resource storageAccount'Microsoft.Storage/storageAccounts@2019-04-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: storageAccountType
  }
  kind: 'StorageV2'
  properties: {}
}


resource blobService 'Microsoft.Storage/storageAccounts/blobServices@2019-04-01' = {
  name: '${storageAccount.name}/default'
  properties: {
    
    cors: {
      corsRules: [
        {
          allowedOrigins: [
            'https://${appName}.azurewebsites.net'
            'https://${preferencesApp}.azurewebsites.net'
            'https://${botApp}.azurewebsites.net'
          ]
          allowedMethods: [
            'GET'
            'PUT'
            'POST'
          ]
          maxAgeInSeconds: 0
          exposedHeaders: [
            ''
          ]
          allowedHeaders: [
            ''
          ]
        }
      ]
    }
    deleteRetentionPolicy: {
      enabled: false
    }
  }
}

resource azure_webjobs_hosts 'Microsoft.Storage/storageAccounts/blobServices/containers@2019-04-01' = {
  name: '${blobService.name}/azure-webjobs-hosts'
  properties: {
    publicAccess: 'None'
  }
  dependsOn: [
    storageAccount
  ]
}

resource azure_webjobs_secrets 'Microsoft.Storage/storageAccounts/blobServices/containers@2019-04-01' = {
  name: '${blobService.name}/azure-webjobs-secrets'
  properties: {
    publicAccess: 'None'
  }
  dependsOn: [
    storageAccount
  ]
}

resource data 'Microsoft.Storage/storageAccounts/blobServices/containers@2019-04-01' = {
  name: '${blobService.name}/data'
  properties: {
    publicAccess: 'None'
  }
  dependsOn: [
    storageAccount
  ]
}

resource botstore 'Microsoft.Storage/storageAccounts/blobServices/containers@2019-04-01' = {
  name: '${blobService.name}/botstore'
  properties: {
    publicAccess: 'None'
  }
  dependsOn: [
    storageAccount
  ]
}
resource archive 'Microsoft.Storage/storageAccounts/blobServices/containers@2019-04-01' = {
  name: '${blobService.name}/archive'
  properties: {
    publicAccess: 'None'
  }
  dependsOn: [
    storageAccount
  ]
}

output storageKey string = storageAccount.listkeys().keys[0].value



