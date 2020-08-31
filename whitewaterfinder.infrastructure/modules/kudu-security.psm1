function Get-KuduCredentials([string]$appName, [string]$resourceGroup)
{
    $user = az webapp deployment list-publishing-profiles `
            -n $appName -g $resourceGroup `
            --query "[?publishMethod=='MSDeploy'].userName" `
            -o tsv
    
    $pass = az webapp deployment list-publishing-profiles `
            -n $appName -g $resourceGroup `
            --query "[?publishMethod=='MSDeploy'].userPWD" `
            -o tsv


    $pair = "$($user):$($pass)"

    $creds =  [System.Convert]::ToBase64String([System.Text.Encoding]::ASCII.GetBytes($pair))

    return $creds
}


