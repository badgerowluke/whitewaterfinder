function Get-AzureSearchServiceName([string] $rgName)
{
    $service = az search service list --resource-group $rgName | ConvertFrom-Json
    return $service.name
}



param (
    [Parameter(Mandatory=$true)] $resourceGroup
)
$seervName = Get-AzureSearchServiceName($resourceGroup)
Write-Host $seervName


$searchService = $resourceGroup + "search"
Write-Output $searchService
$key = az search query-key list --resource-group $resourceGroup --service-name $searchService | ConvertFrom-Json
Write-Output $key.key



$keyValue = $key.key
Write-Host "##vso[task.setvariable variable=searchKey;]$keyValue"

Get-ChildItem Env:
