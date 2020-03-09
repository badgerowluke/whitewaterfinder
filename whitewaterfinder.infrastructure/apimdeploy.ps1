param (
    [Parameter(Mandatory=$true)] $resourceGroup,
    [Parameter(Mandatory=$true)] $fullPath
)

Import-Module $fullPath\modules\kudu-security.psm1
Import-Module $fullPath\modules\azure-functions.psm1
Import-Module $fullPath\modules\apim-policies.psm1

# ===== start here =====
Write-Output "Getting Functions"
$apps = az functionapp list --query "[?resourceGroup=='$($resourceGroup)'].name" | ConvertFrom-Json
Write-Output "Load template policy"
$functionGetInbound = Get-Content $fullPath\apim-policy\FunctionGetPolicy.xml -Raw

Write-Output "Loop Function Apps"
foreach($name in $apps.GetEnumerator())
{
    $rg = $resourceGroup
    
    $creds = Get-KuduCredentials $name $rg

    $functions = Get-Functions $name $creds
    Write-Output "Loop Functions in App"
    foreach($func in $functions)
    {
        
        if($func.config.bindings[0].authLevel -eq "function" -AND $func.config.bindings[0].type -eq "httpTrigger")
        {
            $retryCount = 0
            $completed = $false
            while (-not $completed)
            {
                try 
                {
                    $key = Get-FunctionKey $name $func.name $creds
                    $newInboundPolicy = $functionGetInbound.Replace("{{funcCode}}", $key )
                    $newInboundPolicy = $newInboundPolicy.Replace("{{functionName}}", $func.name)
                    $newInboundPolicy = $newInboundPolicy.Replace("{{functionApp}}", $name)
                    Set-OperationPolicy $rg $func.name $name $newInboundPolicy
                    $completed = $true
                } catch 
                {
                    if($retryCount -ge 5)
                    {
                        Write-Output "$($func.name) failed to pull keys, please try again.  This appears to be an intermittent failure"
                        throw
                    } else 
                    {
                        Write-Output "$($func.name) unavailable.  Waiting 3 seconds to retry"
                        Start-Sleep 3
                        $retryCount++
                    }
                }
            }
        }
    }
}