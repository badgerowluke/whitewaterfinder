param luisName string = 'webster-luis'
param authoringName string = 'webster-luis-authoring'
param botAppName string = 'WhitewaterWebster'

param botInsightsName string = 'paddle-finder'
param botName string = 'whitewaterwebster-ar'
param botPassword string

param spid string
param password string
param tenant string
param storageAccountName string
@secure()
param storageAccountKey string

@description('Location for all resources.')
param location string = resourceGroup().location

resource authoring_resource 'Microsoft.CognitiveServices/accounts@2017-04-18' = {
  kind: 'LUIS.Authoring'
  name: authoringName
  location: 'westus'
  sku: {
    name: 'F0'
  }
}

resource luis_resource 'Microsoft.CognitiveServices/accounts@2017-04-18' = {
  kind: 'LUIS'
  name: luisName
  location: location
  sku: {
    name: 'S0'
  }
  dependsOn: [
    authoring_resource
  ]
}

resource depScript 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
  kind:'AzureCLI'
  location: location
  name: 'bot-app-id-create'

  properties: {
    storageAccountSettings: {
      storageAccountKey: storageAccountKey
      storageAccountName: storageAccountName
    }
    azCliVersion: '2.24.0'
    retentionInterval: 'PT4H'
    cleanupPreference: 'OnExpiration'
    arguments: '--botName ${botName} --botPassword ${botPassword} --spid ${spid} --pass ${password} --tenant ${tenant}'
    scriptContent: '''
  

    botName=""
    botPassword=""
    spid=""
    pass=""
    tenant=""
    #parse and get the botName parameter
    while [ $# -gt 0 ]; do
    
    if [[ $1 == *"--"* ]]; then
    param="${1/--/}"
    declare $param="$2"
    
    fi
    
    shift
    done
    
    az login --service-principal --username $spid --password $pass --tenant $tenant
    #go and find the App Registration/MSFT ID if it exists
    doCreate=true
    
    for item in $(az ad app list | jq -c '.[] .displayName') 
    do
         val="${item%\"}"
         val="${val#\"}"
         if [[ $val == $botName ]]; then
              doCreate=false
              break
         fi
    done
    
    appId=""
    
    #create it first if it doesn't exist
    if [ "$doCreate" =  true ]; then
         app=$(az ad app create --display-name $botName --password $botPassword --available-to-other-tenants)
         appId=$(az ad app list --all --display-name $botName | jq '{"appId": (.[0] .appId)}' > $AZ_SCRIPTS_OUTPUT_PATH)
    fi
    
    appId=$(az ad app list --all --display-name $botName | jq '{"appId": (.[0] .appId)}' > $AZ_SCRIPTS_OUTPUT_PATH)
    echo $appId

    '''
  }
}

resource botService 'Microsoft.BotService/botServices@2018-07-12' = {
  kind: 'sdk'
  name: botAppName
  location: 'global'
  sku: {
    name: 'F0'
  }
  properties: {
    displayName: botAppName
    iconUrl: 'https://docs.botframework.com/static/devportal/client/images/bot-framework-default.png'
    endpoint: 'https://whitewater-finder.azure-api.net/webster/messages'
    msaAppId: depScript.properties.outputs.appId
    developerAppInsightKey: reference(resourceId('microsoft.insights/components/', botInsightsName), '2015-05-01').InstrumentationKey
    developerAppInsightsApplicationId: reference(resourceId('microsoft.insights/components', botInsightsName), '2015-05-01').appId
    luisAppIds: [
      listKeys(luis_resource.id, '2016-02-01-preview').key1
    ]

  }
}

output msaAppId string = depScript.properties.outputs.appId

output luisId string = listKeys(luis_resource.id, '2016-02-01-preview').key1
output luisEndpoint string = reference(luis_resource.id, '2017-04-18').endpoint
