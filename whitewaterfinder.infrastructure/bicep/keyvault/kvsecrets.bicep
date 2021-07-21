
param kvName string


@secure()
param riverFuncKey string

@secure()
param prefFuncKey string

@secure()
param botFuncKey string

@secure()
param adminFuncKey string

@secure() 
param apimKey string



resource apimMasterKey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/apim-master-key'
  properties: {
    value:  apimKey
  }
}

resource riversKey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/riverfunckey'
  properties: {
    value: riverFuncKey
  }
}

resource prefsKey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/preferencefunckey'
  properties: {
    value: prefFuncKey
  }
}

resource botKey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/botfunckey'
  properties: {
    value: botFuncKey
  }
}

resource adminKey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/adminfunckey'
  properties: {
    value: adminFuncKey
  }
}
