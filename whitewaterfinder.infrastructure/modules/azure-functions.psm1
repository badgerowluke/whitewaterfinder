function Get-FunctionKey([string] $appName, [string] $funcName, [string] $creds )
{
    $token = Invoke-RestMethod -Uri "https://$appName.scm.azurewebsites.net/api/functions/admin/token" `
                                -Headers @{Authorization=("Basic {0}" -f $creds)} `
                                -Method GET
    $keys = Invoke-RestMethod -Method GET `
                                -Headers @{Authorization=("Bearer {0}" -f $token)} `
                                -Uri "https://$appName.azurewebsites.net/admin/functions/$funcName/keys"

    
    
    return $keys.keys[0].value
}
function Get-Functions([string] $appName, [string] $creds)
{
                                
    $token = Invoke-RestMethod -Uri "https://$appName.scm.azurewebsites.net/api/functions/admin/token" `
                                -Headers @{Authorization=("Basic {0}" -f $creds)} `
                                -Method GET
    $functions = Invoke-RestMethod -Method GET `
                                    -Headers @{Authorization=("Bearer {0}" -f $token)} `
                                    -Uri "https://$appName.azurewebsites.net/admin/functions"
    return $functions

}