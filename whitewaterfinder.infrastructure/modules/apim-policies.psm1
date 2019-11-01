function Set-BasePolicy($policy, $resourceGroup, $appName)
{
    az resource update `
            -g $resourceGroup `
            -n "whitewater-finder/apis/$appName/policies/policy" `
            --resource-type "Microsoft.ApiManagement/service/apis/policies" `
            --set properties.value=$policy
}
function Set-OperationPolicy([string]$resourceGroup, [string] $name, [string]$app, $policy)
{
    $policy = $policy -replace '"', "\"""
    $policy = $policy -replace "`n", " " -replace "`r", " "


    Write-Output "whitewater-finder/apis/$app/operations/$name/policies/policy"
    az resource update `
            -g $resourceGroup `
            -n "whitewater-finder/apis/$app/operations/$name/policies/policy" `
            --resource-type "Microsoft.ApiManagement/service/apis/operations/policies" `
            --set properties.value=$policy
}