@description('Location for all resources.')
param location string = resourceGroup().location
param azureSearchName string = 'waterfindersearch'

resource azureSearchName_resource 'Microsoft.Search/searchServices@2020-03-13' = {
  name: azureSearchName
  location: location
  sku: {
    name: 'free'
  }
  properties: {
    replicaCount: 1
    partitionCount: 1
    hostingMode: 'default'
  }
}

output searchKey string = listQueryKeys(azureSearchName, '2020-03-13').value[0].key