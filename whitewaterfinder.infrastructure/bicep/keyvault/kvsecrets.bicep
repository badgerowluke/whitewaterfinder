
param kvName string

@secure() 
param apimKey string

@secure()
param instrumentKey string

@secure()
param storageKey string

@secure()
param searchKey string

param storageAccountName string

resource apimMasterKey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/apim-master-key'
  properties: {
    value:  apimKey
  }
}

resource instrumentationKey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/instrumentkey'
  properties: {
    value: instrumentKey
  }
}

resource storageAccess 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/storageKey'
  properties: {
    value: storageKey
  }
}

resource searchAccess 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/searchKey'
  properties: {
    value: searchKey
  }
}

resource storageConnection 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/storageConnection'
  properties: {
    value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${storageKey}'
  }
}
