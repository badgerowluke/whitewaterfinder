@description('Location for all resources.')
param location string = resourceGroup().location
param azureSearchName string = 'waterfindersearch'


param spid string
param password string
param tenant string

resource azureSearch 'Microsoft.Search/searchServices@2020-03-13' = {
  name: azureSearchName
  location: location
  sku: {
    name: 'free'
  }
  properties: {
    replicaCount: 1
    partitionCount: 1
    hostingMode: 'default'
  }
}


resource depScript 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
  kind: 'AzureCLI'
  location: location
  name: 'search-index-builder'

  dependsOn: [
    azureSearch
  ]
  properties: {
    azCliVersion: '2.24.0'
    retentionInterval: 'P1D'
    cleanupPreference: 'OnSuccess'
    arguments: '--spid ${spid} --pass ${password} --tenant ${tenant} --resourceGroup ${resourceGroup().name} --jsonFile ../../riverswithid'
    scriptContent: '''

        resourceGroup=""
        jsonFile=""
        spid=""
        pass=""
        tenant=""
        while [ $# -gt 0 ]; do
        
          if [[ $1 == *"--"* ]]; then
            param="${1/--/}"
            declare $param="$2"
          
          fi
        
        shift
        done

        az login --service-principal --username $spid --password $pass --tenant $tenant
    
        key=$(az search admin-key show --output json --resource-group ${resourceGroup} --service-name "waterfindersearch" | jq '. .primaryKey')
        
        stripped="${key%\"}"
        stripped="${stripped#\"}"

        
        curl -X PUT https://waterfindersearch.search.windows.net/indexes/riversearch-index?api-version=2019-05-06 \
           -H "api-key : ${stripped}" \
           -H "Content-Type: application/json" \
           --data "
           {
                'name': 'riversearch-index',
                'fields': [
                    {'name': 'PartitionKey', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': false, 'sortable':false, 'facetable':false, 'key':false},
                    {'name': 'RowKey', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': false, 'sortable':false, 'facetable':false, 'key':false},
                    {'name': 'ETag', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': false, 'sortable':false, 'facetable':false, 'key':false},
                    {'name': 'Timestamp', 'type': 'Edm.DateTimeOffset', 'searchable':false, 'filterable':false, 'retrievable': false, 'sortable':false, 'facetable':false, 'key':false},
                    {'name': 'Key', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': false, 'sortable':false, 'facetable':false, 'key':false},
                    {'name': 'Id', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': true, 'sortable':false, 'facetable':false, 'key':true},
                    {'name': 'Latitude', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': true, 'sortable':false, 'facetable':false, 'key':false},
                    {'name': 'Longitude', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': true, 'sortable':false, 'facetable':false, 'key':false},
                    {'name': 'Name', 'type': 'Edm.String', 'searchable':true, 'filterable':false, 'retrievable': true, 'sortable':false, 'facetable':false, 'key':false, 'analyzer': 'standard.lucene'},
                    {'name': 'RiverId', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': true, 'sortable':false, 'facetable':false, 'key':false},
                    {'name': 'Srs', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': true, 'sortable':false, 'facetable':false, 'key':false},
                    {'name': 'State', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': true, 'sortable':false, 'facetable':false, 'key':false},
                    {'name': 'StateCode', 'type': 'Edm.String', 'searchable':false, 'filterable':false, 'retrievable': true, 'sortable':false, 'facetable':false, 'key':false}
                ],
                'suggesters': [
                    {
                        'name':'RiverName',
                        'searchMode':'analyzingInfixMatching',
                        'sourceFields':['Name']
                    }
                ]
            }
            " 
    '''
  }
}

output searchKey string = azureSearch.listQueryKeys().value[0].key

