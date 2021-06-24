param apimName string = 'whitewater-finder'

@description('Location for all resources.')
param location string = resourceGroup().location
param adminEmail string = 'badgerow.luke@outlook.com'
param orgName string = 'burning-river-geospatial-solutions'

param riverFuncKey string
param prefFuncKey string
param botFuncKey string
param adminFuncKey string


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

module riversAPIM 'rivers.bicep' = {
  name: 'rivers-apim-deploy'
  dependsOn: [
    apimName_resource
  ]
  params: {
    apimName: apimName_resource.name
    riverFuncKey: riverFuncKey
  }
}

module users 'users.bicep' = {
  name: 'users-apim-deploy'
  dependsOn: [
    apimName_resource
  ]
  params: {
    apimName: apimName
    prefFuncKey: prefFuncKey
  }
}

module bot 'bot.bicep' = {
  name: 'bot-apim-deploy'
  dependsOn: [
    apimName_resource
  ]
  params: {
    apimName: apimName
    botFuncKey: botFuncKey
  }

}

module admin 'admin.bicep' = {
  name: 'admin-apim-deploy'
  dependsOn: [
    apimName_resource
  ]
  params: {
    apimName: apimName
    adminFuncKey: adminFuncKey
  }
}

output subkey string = reference(resourceId('Microsoft.ApiManagement/service/subscriptions', apimName, 'master'), '2019-01-01').primaryKey
