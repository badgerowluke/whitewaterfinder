
param kvName string
param storageAccountName string

@secure() 
param apimKey string

@secure()
param instrumentKey string

@secure()
param storageKey string

@secure()
param searchKey string

@secure()
param botAppId string

@secure()
param botPassword string

@secure()
param luisAppId string

@secure()
param luisApiKey string

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

resource instrumentConnection 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/instrumentConnection'
  properties: {
    value: 'InstrumentationKey=${instrumentKey}'
  }
}

resource msftAppId 'Microsoft.KeyVault/vaults/secrets@2019-09-01' = {
  name: '${kvName}/botAppId'
  properties: {
    value: botAppId
  }
}

resource botPass 'Microsoft.KeyVault/vaults/secrets@2019-09-01' = {
  name: '${kvName}/botPassword'
  properties: {
    value: botPassword
  }
}

resource luisApp 'Microsoft.KeyVault/vaults/secrets@2019-09-01' = {
  name: '${kvName}/luisAppId'
  properties: {
    value: luisAppId
  }
}

resource luisKey 'Microsoft.KeyVault/vaults/secrets@2019-09-01' = {
  name: '${kvName}/luisApiKey'
  properties: {
    value: luisApiKey
  }
}
