function Get-AzureSearchServiceName([string] $rgName)
{
    $service = az search service list --resource-group $rgName | ConvertFrom-Json
    return $service.name
}

function Get-AzureSearchAdminKey([string] $rgName, [string] $searchService)
{
    $keys = az search admin-key show --output json --resource-group $resourceGroup `
        --service-name "waterfindersearch" | ConvertFrom-Json

    return $keys.primaryKey
}