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

var storageAccountId = '${resourceGroup().id}/providers/Microsoft.Storage/storageAccounts/${storageAccountName}'

resource appName_resource 'Microsoft.Insights/components@2015-05-01' = {
  name: appName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
    Request_Source: 'rest'
  }
}

resource storageAccountName_resource 'Microsoft.Storage/storageAccounts@2019-04-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: storageAccountType
  }
  kind: 'StorageV2'
  properties: {}
}

resource storageAccountName_default 'Microsoft.Storage/storageAccounts/blobServices@2019-04-01' = {
  name: '${storageAccountName_resource.name}/default'
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
    deleteRententionPolicy: {
      enabled: false
    }
  }
}

resource storageAccountName_default_azure_webjobs_hosts 'Microsoft.Storage/storageAccounts/blobServices/containers@2019-04-01' = {
  name: '${storageAccountName_default.name}/azure-webjobs-hosts'
  properties: {
    publicAccess: 'None'
  }
  dependsOn: [
    storageAccountName_resource
  ]
}

resource storageAccountName_default_azure_webjobs_secrets 'Microsoft.Storage/storageAccounts/blobServices/containers@2019-04-01' = {
  name: '${storageAccountName_default.name}/azure-webjobs-secrets'
  properties: {
    publicAccess: 'None'
  }
  dependsOn: [
    storageAccountName_resource
  ]
}

resource storageAccountName_default_data 'Microsoft.Storage/storageAccounts/blobServices/containers@2019-04-01' = {
  name: '${storageAccountName_default.name}/data'
  properties: {
    publicAccess: 'Container'
  }
  dependsOn: [
    storageAccountName_resource
  ]
}

resource storageAccountName_default_botstore 'Microsoft.Storage/storageAccounts/blobServices/containers@2019-04-01' = {
  name: '${storageAccountName_default.name}/botstore'
  properties: {
    publicAccess: 'Container'
  }
  dependsOn: [
    storageAccountName_resource
  ]
}

output storageKey string = concat(listKeys(storageAccountId, '2015-05-01-preview').key1)