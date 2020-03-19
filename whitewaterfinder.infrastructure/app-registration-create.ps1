param (
  [Parameter(Mandatory=$true)]  $botName
)

$val = az ad app create --display-name "dumby" --password "tacospastapizza4@11" `
         --available-to-other-tenants | ConvertFrom-Json


$newAppId =  $val.appId
Write-Host "##vso[task.setvariable variable=searchKey;]$newAppId"