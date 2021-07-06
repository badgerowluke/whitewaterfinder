


param (
        [Parameter(Mandatory=$true)] $resourceGroup,
        [Parameter(Mandatory=$true)] $jsonFile
    
    )
    
$keys = az search admin-key show --output json --resource-group $resourceGroup `
        --service-name "waterfindersearch" | ConvertFrom-Json

$key = $keys.primaryKey
Write-Output 'Attempting to Build Index'

if($key)
{

    $indexHeaders = @{

        'api-key' = $key
        'Content-Type' = 'application/json'
        'Accept' = 'application/json'
    }

    $filePath = $path + $jsonFile

    $rivers =  Get-Content $filePath |  ConvertFrom-Json

    $index = @{value = @()}

    $index.value += ($rivers)

    Write-Output "attempting to POST documents to Azure Search"


    $index = ConvertTo-Json -InputObject $index
    $updateUrl = "https://waterfindersearch.search.windows.net/indexes/riversearch-index/docs/index?api-version=2019-05-06"
    Invoke-RestMethod -Uri $updateUrl -Headers $indexHeaders -Method Post -Body $index -TimeoutSec 300


    Write-Output "invoked REST"
} else {
    Write-Output 'was not able to get search keys'
}

