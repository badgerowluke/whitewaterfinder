function Set-BasePolicy($policy, $resourceGroup)
{
    $policy = $policy -replace '"', "\"""
    $policy = $policy -replace "`n", " " -replace "`r", " "
    az resource update `
            -g $resourceGroup `
            -n "whitewater-finder" `
            --resource-type "Microsoft.ApiManagement/service/apis/operations/policies" `
            --set properties.value=$policy
}
function Set-OperationPolicy([string]$resourceGroup, [string] $name, [string]$app, $policy)
{
    $policy = $policy -replace '"', "\"""
    $policy = $policy -replace "`n", " " -replace "`r", " "

    az resource update `
            -g $resourceGroup `
            -n "whitewater-finder/apis/$app/operations/$name/policies/policy" `
            --resource-type "Microsoft.ApiManagement/service/apis/operations/policies" `
            --set properties.value=$policy
}

function Remove-SoftDeletedAPIMInstances([string] $creds, [string] $location, [string] $subscriptionId, [string] $serviceName)
{
    Invoke-RestMethod -Uri "https://management.azure.com/subscriptions/$subscriptionId/providers/Microsoft.ApiManagement/locations/$location/deletedservices/$serviceName?api-version=2020-06-01-preview" `
                        -Headers @{Authorization=("Basic {0}" -f $creds)} `
                        -Method DELETE
}