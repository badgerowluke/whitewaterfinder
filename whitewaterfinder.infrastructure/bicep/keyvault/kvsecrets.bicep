param appName string
param kvName string
param apimName string

var riversAppId = resourceId('Microsoft.Web/sites', appName)
var usersAppId = resourceId('Microsoft.Web/sites', '${appName}-preferences')
var botFuncId = resourceId('Microsoft.Web/sites', '${appName}-webster')



resource kvName_apim_master_key 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/apim-master-key'
  properties: {
    value: reference(resourceId('Microsoft.ApiManagement/service/subscriptions', apimName, 'master'), '2019-01-01').primaryKey
  }
}

resource kvName_riverfunckey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/riverfunckey'
  properties: {
    value: listkeys('${riversAppId}/host/default', '2018-11-01').functionKeys.default
  }
}

resource kvName_preferencefunckey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/preferencefunckey'
  properties: {
    value: listkeys('${usersAppId}/host/default', '2018-11-01').functionKeys.default
  }
}

resource kvName_botfunckey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName}/botfunckey'
  properties: {
    value: listkeys('${botFuncId}/host/default', '2018-11-01').functionKeys.default
  }
}
