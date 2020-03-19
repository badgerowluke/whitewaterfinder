param (
    [Parameter(Mandatory=$true)] $resourceGroup
)




$key = az search query-key list --resource-group $resourceGroup --service-name 'waterfindersearch' | ConvertFrom-Json




$keyValue = $key.key
Write-Host "##vso[task.setvariable variable=searchKey;]$keyValue"


