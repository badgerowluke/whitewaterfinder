


param (
        [Parameter(Mandatory=$true)] $resourceGroup,
        [Parameter(Mandatory=$true)] $path
    
    )
    


# $service = az search service list --resource-group $resourceGroup | ConvertFrom-Json
# Write-Output $service.name

# $serviceName = $service.name



$keys = az search admin-key show --output json --resource-group $resourceGroup `
        --service-name "waterfindersearch" | ConvertFrom-Json

$body = @"
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
"@


try 
{




    $key = $keys.primaryKey
    Write-Output 'Attempting to Build Index'

    Write-Host $keys.primaryKey



    if($key)
    {

        $indexHeaders = @{

            'api-key' = $key
            'Content-Type' = 'application/json'
            'Accept' = 'application/json'
        }
        $url = "https://waterfindersearch.search.windows.net/indexes/riversearch-index?api-version=2019-05-06"
        $putResult = Invoke-RestMethod -Uri $url -Headers $indexHeaders -Method Put -Body $body



        Write-Output "building the actual index documents"


        $rivers =  Get-Content $path |  ConvertFrom-Json

        $index = @{value = @()}

        $index.value += ($rivers)

        Write-Output "attempting to POST documents to Azure Search"


        Write-Host $index

        $index = ConvertTo-Json -InputObject $index
        $updateUrl = "https://waterfindersearch.search.windows.net/indexes/riversearch-index/docs/index?api-version=2019-05-06"
        Invoke-RestMethod -Uri $updateUrl -Headers $indexHeaders -Method Post -Body $index -TimeoutSec 300


        Write-Output "invoked REST"
    } else {
        Write-Output 'was not able to get search keys'
    }



} catch [System.Exception]
{


}
