
@description('Location for all resources.')
param location string
param tenantId string
param adminId string
param kvName string

resource kvName_resource 'Microsoft.KeyVault/vaults@2019-09-01' = {
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
          secrets:[
            'get'
            'list'
            'set'
            'delete'
            'recover'
            'backup'
            'restore'
          ]
        }
      }
    ]
  }
}

