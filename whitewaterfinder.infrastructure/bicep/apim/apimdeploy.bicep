param apimName string = 'whitewater-finder'

@description('Location for all resources.')
param location string = resourceGroup().location
param adminEmail string = 'badgerow.luke@outlook.com'
param orgName string = 'burning-river-geospatial-solutions'
param preferencesApp string = 'paddle-finder-preferences'
param appName string = 'paddle-finder'
param botName string = 'paddle-finder-webster'
param adminName string = 'paddle-finder-admin'

resource apimName_resource 'Microsoft.ApiManagement/service@2019-01-01' = {
  name: apimName
  location: location
  sku: {
    name: 'Consumption'
    capacity: 0
  }
  properties: {
    publisherEmail: adminEmail
    publisherName: orgName
  }
}

resource apimName_appName 'Microsoft.ApiManagement/service/apis@2019-01-01' = {
  name: '${apimName_resource.name}/${appName}'
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

resource apimName_policy 'Microsoft.ApiManagement/service/policies@2019-12-01' = {
  name: '${apimName_resource.name}/policy'
  properties: {
    value: '''
    <policies>
        <inbound>    
          <cors allow-credentials="true">      
            <allowed-origins>     
              <origin>http://localhost:5000</origin>        
              <origin>http://localhost:3000</origin>        
              <origin>http://localhost:4200</origin>       
              <origin>http://paddle-finder.com</origin>       
              <origin>https://paddle-finder.com</origin>     
            </allowed-origins>
            <allowed-methods preflight-result-max-age="300">   
              <method>GET</method>       
              <method>POST</method>       
              <method>DELETE</method>       
              <method>OPTIONS</method>
            </allowed-methods>    
            <allowed-headers>     
              <header>content-type</header>     
              <header>accept</header> 
            </allowed-headers>
          </cors> 
        </inbound> 
        <backend>  
          <forward-request />
        </backend>
        <outbound>
          <set-header name="Request-Id" exists-action="override">    
            <value>@(context.Response.Headers.GetValueOrDefault("x-ms-request-id"))</value>
          </set-header>
        </outbound>
        <on-error />
      </policies>
      '''
    format: 'xml'
  }
}

resource apimName_appName_riverdetails 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
  name: '${apimName_appName.name}/riverdetails'
  properties: {
    displayName: 'RiverDetails'
    method: 'GET'
    urlTemplate: '/details/{riverCode}'
    templateParameters: [
      {
        name: 'riverCode'
        type: 'string'
      }
    ]
    responses: []
    operationId: 'RiverDetails'
  }
  dependsOn: [
    apimName_resource
  ]
}

// resource apimName_appName_riverdetails_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
//   name: '${apimName_appName_riverdetails.name}/policy'
//   properties: {
//     value: '<policies></policies>'
//     format: 'xml'
//   }
//   dependsOn: [
//     apimName_resource
//     apimName_appName
//   ]
// }

// resource apimName_appName_rivers 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
//   name: '${apimName_appName.name}/rivers'
//   properties: {
//     displayName: 'Rivers'
//     method: 'GET'
//     urlTemplate: '/Rivers'
//     templateParameters: []
//     responses: []
//   }
//   dependsOn: [
//     apimName_resource
//   ]
// }

// resource apimName_appName_rivers_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
//   name: '${apimName_appName_rivers.name}/policy'
//   properties: {
//     value: '<policies></policies>'
//     format: 'xml'
//   }
//   dependsOn: [
//     apimName_resource
//     apimName_appName
//   ]
// }

// resource apimName_appName_riversbystate 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
//   name: '${apimName_appName.name}/riversbystate'
//   properties: {
//     displayName: 'RiversByState'
//     method: 'GET'
//     urlTemplate: 'rivers/{state}'
//     templateParameters: [
//       {
//         name: 'state'
//         type: 'string'
//       }
//     ]
//     responses: []
//   }
//   dependsOn: [
//     apimName_resource
//   ]
// }

// resource apimName_appName_riversbystate_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
//   name: '${apimName_appName_riversbystate.name}/policy'
//   properties: {
//     value: '<policies></policies>'
//     format: 'xml'
//   }
//   dependsOn: [
//     apimName_resource
//     apimName_appName
//   ]
// }

// resource apimName_preferencesApp 'Microsoft.ApiManagement/service/apis@2019-01-01' = {
//   name: '${apimName_resource.name}/${preferencesApp}'
//   properties: {
//     displayName: 'users'
//     protocols: [
//       'https'
//     ]
//     path: 'users'
//     isCurrent: true
//     apiRevision: '1'
//   }
// }

// resource apimName_preferencesApp_getuserpreferences 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
//   name: '${apimName_preferencesApp.name}/getuserpreferences'
//   properties: {
//     displayName: 'GetUserPreferences'
//     method: 'GET'
//     urlTemplate: 'users/{subId}'
//     templateParameters: [
//       {
//         name: 'subId'
//         type: 'string'
//       }
//     ]
//     responses: []
//   }
//   dependsOn: [
//     apimName_resource
//   ]
// }

// resource apimName_preferencesApp_getuserpreferences_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
//   name: '${apimName_preferencesApp_getuserpreferences.name}/policy'
//   properties: {
//     value: '<policies></policies>'
//     format: 'xml'
//   }
//   dependsOn: [
//     apimName_resource
//     apimName_preferencesApp
//   ]
// }

// resource apimName_preferencesApp_postuserpreferences 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
//   name: '${apimName_preferencesApp.name}/postuserpreferences'
//   properties: {
//     displayName: 'PostUserPreferences'
//     method: 'POST'
//     urlTemplate: '/'
//     templateParameters: []
//     responses: []
//   }
//   dependsOn: [
//     apimName_resource
//   ]
// }

// resource apimName_preferencesApp_postuserpreferences_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
//   name: '${apimName_preferencesApp_postuserpreferences.name}/policy'
//   properties: {
//     value: '<policies></policies>'
//     format: 'xml'
//   }
//   dependsOn: [
//     apimName_resource
//     apimName_preferencesApp
//   ]
// }

// resource apimName_botName 'Microsoft.ApiManagement/service/apis@2019-01-01' = {
//   name: '${apimName_resource.name}/${botName}'
//   properties: {
//     displayName: 'webster'
//     protocols: [
//       'https'
//     ]
//     path: 'webster'
//     isCurrent: true
//     apiRevision: '1'
//   }
// }

// resource apimName_botName_messages 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
//   name: '${apimName_botName.name}/messages'
//   properties: {
//     displayName: 'messages'
//     method: 'POST'
//     urlTemplate: 'messages'
//     templateParameters: []
//     responses: []
//   }
//   dependsOn: [
//     apimName_resource
//   ]
// }

// resource apimName_botName_messages_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
//   name: '${apimName_botName_messages.name}/policy'
//   properties: {
//     value: '<policies></policies>'
//     format: 'xml'
//   }
//   dependsOn: [
//     apimName_botName
//     apimName_resource
//   ]
// }

// resource apimName_adminName 'Microsoft.ApiManagement/service/apis@2019-01-01' = {
//   name: '${apimName_resource.name}/${adminName}'
//   properties: {
//     displayName: 'pfadmin'
//     protocols: [
//       'https'
//     ]
//     path: 'pfadmin'
//     isCurrent: true
//     apiRevision: '1'
//   }
// }

// resource apimName_adminName_functionkeys 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
//   name: '${apimName_adminName.name}/functionkeys'
//   properties: {
//     displayName: 'functionkeys'
//     method: 'POST'
//     urlTemplate: 'functionkeys/{appName}/{keyName}'
//     templateParameters: [
//       {
//         name: 'appName'
//         type: 'string'
//       }
//       {
//         name: 'keyName'
//         type: 'string'
//       }
//     ]
//     responses: []
//   }
//   dependsOn: [
//     apimName_resource
//   ]
// }

// resource apimName_adminName_functionkeys_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
//   name: '${apimName_adminName_functionkeys.name}/policy'
//   properties: {
//     value: '<policies></policies>'
//     format: 'xml'
//   }
//   dependsOn: [
//     apimName_adminName
//     apimName_resource
//   ]
// }

// resource apimName_adminName_email 'Microsoft.ApiManagement/service/apis/operations@2019-01-01' = {
//   name: '${apimName_adminName.name}/email'
//   properties: {
//     displayName: 'email'
//     method: 'POST'
//     urlTemplate: 'email'
//     templateParameters: []
//     responses: []
//   }
//   dependsOn: [
//     apimName_resource
//   ]
// }

// resource apimName_adminName_email_policy 'Microsoft.ApiManagement/service/apis/operations/policies@2019-01-01' = {
//   name: '${apimName_adminName_email.name}/policy'
//   properties: {
//     value: '<policies></policies>'
//     format: 'xml'
//   }
//   dependsOn: [
//     apimName_adminName
//     apimName_resource
//   ]
// }

output subkey string = reference(resourceId('Microsoft.ApiManagement/service/subscriptions', apimName, 'master'), '2019-01-01').primaryKey
