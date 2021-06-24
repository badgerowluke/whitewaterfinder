param preferencesApp string = 'paddle-finder-preferences'
param apimName string
param prefFuncKey string

resource apimName_preferencesApp 'Microsoft.ApiManagement/service/apis@2019-01-01' = {
  name: '${apimName}/${preferencesApp}'
  properties: {
    displayName: 'users'
    protocols: [
      'https'
    ]
    path: 'users'
    isCurrent: true
    apiRevision: '1'
  }
}

//<policies><inbound><base /><set-backend-service base-url="https://{{functionApp}}.azurewebsites.net/api/" /><rewrite-uri template="{{route}}" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>{{funcCode}}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>



resource apimName_preferencesApp_getuserpreferences 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
  name: '${apimName_preferencesApp.name}/getuserpreferences'
  properties: {
    displayName: 'GetUserPreferences'
    method: 'GET'
    urlTemplate: 'users/{subId}'
    templateParameters: [
      {
        name: 'subId'
        type: 'string'
      }
    ]
    responses: []
  }

}

resource apimName_preferencesApp_getuserpreferences_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
  name: '${apimName_preferencesApp_getuserpreferences.name}/policy'
  properties: {
    value: '<policies><inbound><base /><set-backend-service base-url="https://${preferencesApp}.azurewebsites.net/api/" /><rewrite-uri template="/users/{subId}" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>${prefFuncKey}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>'
    format: 'xml'
  }
  dependsOn: [
    apimName_preferencesApp
  ]
}

resource apimName_preferencesApp_postuserpreferences 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
  name: '${apimName_preferencesApp.name}/postuserpreferences'
  properties: {
    displayName: 'PostUserPreferences'
    method: 'POST'
    urlTemplate: '/'
    templateParameters: []
    responses: []
  }

}

resource apimName_preferencesApp_postuserpreferences_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
  name: '${apimName_preferencesApp_postuserpreferences.name}/policy'
  properties: {
    value: '<policies><inbound><base /><set-backend-service base-url="https://${preferencesApp}.azurewebsites.net/api/" /><rewrite-uri template="/users" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>${prefFuncKey}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>'
    format: 'xml'
  }
  dependsOn: [
    apimName_preferencesApp
  ]
}
