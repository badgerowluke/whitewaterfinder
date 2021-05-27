@description('Location for all resources.')
param location string = resourceGroup().location
param tenantId string
param adminId string
param kvName string
param apimName string
param appName string = 'paddle-finder'

var riversAppId = resourceId('Microsoft.Web/sites', appName)
var usersAppId = resourceId('Microsoft.Web/sites', '${appName}-preferences')
var botFuncId = resourceId('Microsoft.Web/sites', '${appName}-webster')

resource kvName_resource 'Microsoft.KeyVault/vaults@2018-02-14' = {
  name: kvName
  location: location
  properties: {
    sku: {
      name: 'standard'
      family: 'A'
    }
    tenantId: tenantId
    accessPolicies: [
      {
        objectId: adminId
        tenantId: tenantId
        permissions: {
          keys: [
            'get'
            'list'
            'update'
            'create'
            'import'
            'delete'
            'recover'
            'backup'
            'restore'
          ]
          secrets: [
            'get'
            'list'
            'set'
            'delete'
            'recover'
            'backup'
            'restore'
          ]
          certificates: [
            'get'
            'list'
            'update'
            'create'
            'import'
            'delete'
            'recover'
            'backup'
            'restore'
            'managecontacts'
            'manageissuers'
            'getissuers'
            'listissuers'
            'setissuers'
            'deleteissuers'
          ]
        }
      }
    ]
  }
}

resource kvName_apim_master_key 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName_resource.name}/apim-master-key'
  properties: {
    value: reference(resourceId('Microsoft.ApiManagement/service/subscriptions', apimName, 'master'), '2019-01-01').primaryKey
  }
}

resource kvName_riverfunckey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName_resource.name}/riverfunckey'
  properties: {
    value: listkeys('${riversAppId}/host/default', '2018-11-01').functionKeys.default
  }
}

resource kvName_preferencefunckey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName_resource.name}/preferencefunckey'
  properties: {
    value: listkeys('${usersAppId}/host/default', '2018-11-01').functionKeys.default
  }
}

resource kvName_botfunckey 'Microsoft.KeyVault/vaults/secrets@2016-10-01' = {
  name: '${kvName_resource.name}/botfunckey'
  properties: {
    value: listkeys('${botFuncId}/host/default', '2018-11-01').functionKeys.default
  }
}