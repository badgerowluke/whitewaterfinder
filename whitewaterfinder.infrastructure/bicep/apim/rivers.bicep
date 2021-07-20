param appName string = 'paddle-finder'
param apimName string
param riverFuncKey string

resource apimName_appName 'Microsoft.ApiManagement/service/apis@2019-01-01' = {
  name: '${apimName}/${appName}'
  properties: {
    displayName: 'rivers'
    protocols: [
      'https'
    ]
    path: 'Rivers'
    isCurrent: true
    apiRevision: '1'
    serviceUrl: 'https://${appName}.azurewebsites.net/api'
  }
}


resource apimName_appName_riverdetails 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
  name: '${apimName_appName.name}/riverdetails'
  properties: {
    displayName: 'RiverDetails'
    method: 'GET'
    urlTemplate: '/rivers/{riverCode}/details'
    templateParameters: [
      {
        name: 'riverCode'
        type: 'string'
      }
    ]
    responses: []
  }

}



resource apimName_appName_riverdetails_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
  name: '${apimName_appName_riverdetails.name}/policy'
  properties: {
    value: '<policies><inbound><base /><set-backend-service base-url="https://${appName}.azurewebsites.net/api/" /><rewrite-uri template="/rivers/{riverCode}/details" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>${riverFuncKey}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>'
    format: 'xml'
  }
  dependsOn: [
    apimName_appName
  ]
}

resource apimName_appName_rivers 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
  name: '${apimName_appName.name}/rivers'
  properties: {
    displayName: 'Rivers'
    method: 'GET'
    urlTemplate: '/Rivers'
    templateParameters: []
    responses: []
  }

}

resource apimName_appName_rivers_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
  name: '${apimName_appName_rivers.name}/policy'
  properties: {
    value: '<policies><inbound><base /><set-backend-service base-url="https://${appName}.azurewebsites.net/api/" /><rewrite-uri template="/rivers" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>${riverFuncKey}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>'
    format: 'xml'
  }
  dependsOn: [
    apimName_appName
  ]
}

resource apimName_appName_riversbystate 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
  name: '${apimName_appName.name}/riversbystate'
  properties: {
    displayName: 'RiversByState'
    method: 'GET'
    urlTemplate: 'rivers/{state}'
    templateParameters: [
      {
        name: 'state'
        type: 'string'
      }
    ]
    responses: []
  }

}

resource apimName_appName_riversbystate_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
  name: '${apimName_appName_riversbystate.name}/policy'
  properties: {
    value: '<policies><inbound><base /><set-backend-service base-url="https://${appName}.azurewebsites.net/api/" /><rewrite-uri template="/rivers/{state}" copy-unmatched-params="true" /><set-header name="x-functions-key" exists-action="override"><value>${riverFuncKey}</value></set-header></inbound><backend><base /></backend><outbound><base /></outbound><on-error><base /></on-error></policies>'
    format: 'xml'
  }
  dependsOn: [
    apimName_appName
  ]
}
