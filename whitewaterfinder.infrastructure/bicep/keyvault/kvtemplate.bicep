
@description('Location for all resources.')
param location string
param kvName string

@secure()
param tenantId string

@secure()
param adminId string

@secure()
param spnid string

@secure()
param riversMI string

@secure()
param botMI string

@secure()
param adminMI string

@secure()
param preferencesMI string

resource kvName_resource 'Microsoft.KeyVault/vaults@2019-09-01' = {
  name: kvName
  location: location
  properties: {
    sku: {
      name: 'standard'
      family: 'A'
    }
    tenantId: tenantId
    enablePurgeProtection: true
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
      {
        objectId: riversMI
        tenantId: tenantId
        permissions: {
          secrets:[
            'get'
            'list'
          ]
        }
      }
      {
        objectId: botMI
        tenantId: tenantId
        permissions: {
          secrets:[
            'get'
            'list'
          ]
        }
      }
      {
        objectId: adminMI
        tenantId: tenantId
        permissions: {
          secrets:[
            'get'
            'list'
          ]
        }
      }
      {
        objectId: preferencesMI
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

