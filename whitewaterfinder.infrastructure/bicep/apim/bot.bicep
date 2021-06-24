param botName string = 'paddle-finder-webster'
param apimName string
param botFuncKey string

//<policies><inbound><base /><set-backend-service base-url="https://{{functionApp}}.azurewebsites.net/api/" /><rewrite-uri template="{{route}}" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>{{funcCode}}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>

resource apimName_botName 'Microsoft.ApiManagement/service/apis@2019-01-01' = {
  name: '${apimName}/${botName}'
  properties: {
    displayName: 'webster'
    protocols: [
      'https'
    ]
    path: 'webster'
    isCurrent: true
    apiRevision: '1'
  }
}

resource apimName_botName_messages 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
  name: '${apimName_botName.name}/messages'
  properties: {
    displayName: 'messages'
    method: 'POST'
    urlTemplate: 'messages'
    templateParameters: []
    responses: []
  }

}

resource apimName_botName_messages_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
  name: '${apimName_botName_messages.name}/policy'
  properties: {
    value: '<policies><inbound><base /><set-backend-service base-url="https://${botName}.azurewebsites.net/api/" /><rewrite-uri template="/messages" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>${botFuncKey}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>'
    format: 'xml'
  }
  dependsOn: [
    apimName_botName

  ]
}
