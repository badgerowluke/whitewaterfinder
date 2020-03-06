param (
    [Parameter(Mandatory=$true)] $resourceGroup
)
$searchService = $resourceGroup + "search"
Write-Output $searchService
$key = az search query-key list --resource-group $resourceGroup --service-name $searchService | ConvertFrom-Json
Write-Output $key.key
Write-Host "##vso[task.setvariable variable=searchKey;]$key.key"
Get-ChildItem Env:

Write-Host "Key is: ($key.key)"