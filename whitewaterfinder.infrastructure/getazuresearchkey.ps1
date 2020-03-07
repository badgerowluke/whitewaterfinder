param (
    [Parameter(Mandatory=$true)] $resourceGroup
)
$searchService = $resourceGroup + "search"
Write-Output $searchService
$key = az search query-key list --resource-group $resourceGroup --service-name $searchService | ConvertFrom-Json
Write-Output $key.key

$service = az search service list --resource-group $resourceGroup | ConvertFrom-Json
Write-Output $service.name
$serviceName = $service.name
$keys = az search admin-key show --output json --resource-group $resourceGroup --service-name 

$keyValue = $key.key
Write-Host "##vso[task.setvariable variable=AZURE_SEARCH_KEY;]$keyValue"
Get-ChildItem Env:

Write-Host "Key is: ($keyValue)"