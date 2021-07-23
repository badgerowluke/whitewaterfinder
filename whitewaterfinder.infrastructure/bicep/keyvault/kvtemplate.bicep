
@description('Location for all resources.')
param location string
param tenantId string
@secure()
param adminId string
param kvName string
@secure()
param spnid string

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
      {
        objectId: spnid
        tenantId: tenantId
        permissions: {
          secrets:[
            'get'
            'list'
          ]
        }
      }
    ]
  }
}

