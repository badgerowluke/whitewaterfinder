param apimName string
param apimId string
resource lukesubscription 'Microsoft.ApiManagement/service/subscriptions@2021-01-01-preview' = {
  name: '${apimName}/demo-sub'
  properties: {
    allowTracing: true
    displayName: 'Demo-Sub'
    scope:'${apimId}/apis'
  }
}
