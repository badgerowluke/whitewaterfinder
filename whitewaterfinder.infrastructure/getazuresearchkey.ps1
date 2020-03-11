param (
    [Parameter(Mandatory=$true)] $resourceGroup
)

$searchService = az search service list --resource-group $resourceGroup | ConvertFrom-Json


Write-Output $searchService
$key = az search query-key list --resource-group $resourceGroup --service-name $searchService.name | ConvertFrom-Json
Write-Output $key.key



$keyValue = $key.key
Write-Host "##vso[task.setvariable variable=searchKey;]$keyValue"

Get-ChildItem Env:
