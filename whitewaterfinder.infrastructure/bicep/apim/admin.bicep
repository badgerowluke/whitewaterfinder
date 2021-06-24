param adminName string = 'paddle-finder-admin'
param apimName string
param adminFuncKey string

//<policies><inbound><base /><set-backend-service base-url="https://{{functionApp}}.azurewebsites.net/api/" /><rewrite-uri template="{{route}}" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>{{funcCode}}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>

resource apimName_adminName 'Microsoft.ApiManagement/service/apis@2019-01-01' = {
  name: '${apimName}/${adminName}'
  properties: {
    displayName: 'pfadmin'
    protocols: [
      'https'
    ]
    path: 'pfadmin'
    isCurrent: true
    apiRevision: '1'
  }
}

resource apimName_adminName_functionkeys 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
  name: '${apimName_adminName.name}/functionkeys'
  properties: {
    displayName: 'functionkeys'
    method: 'POST'
    urlTemplate: 'functionkeys/{appName}/{keyName}'
    templateParameters: [
      {
        name: 'appName'
        type: 'string'
      }
      {
        name: 'keyName'
        type: 'string'
      }
    ]
    responses: []
  }

}

resource apimName_adminName_functionkeys_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
  name: '${apimName_adminName_functionkeys.name}/policy'
  properties: {
    value: '<policies><inbound><base /><set-backend-service base-url="https://${adminName}.azurewebsites.net/api/" /><rewrite-uri template="/functionkeys/{appName}/{keyName}" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>${adminFuncKey}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>'
    format: 'xml'
  }
  dependsOn: [
    apimName_adminName

  ]
}

resource apimName_adminName_email 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
  name: '${apimName_adminName.name}/email'
  properties: {
    displayName: 'email'
    method: 'POST'
    urlTemplate: 'email'
    templateParameters: []
    responses: []
  }

}

resource apimName_adminName_email_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
  name: '${apimName_adminName_email.name}/policy'
  properties: {
    value: '<policies><inbound><base /><set-backend-service base-url="https://${adminName}.azurewebsites.net/api/" /><rewrite-uri template="/email" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>${adminFuncKey}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>'
    format: 'xml'
  }
  dependsOn: [
    apimName_adminName
  ]
}
