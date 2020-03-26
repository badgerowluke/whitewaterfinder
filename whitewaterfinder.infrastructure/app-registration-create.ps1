param (
  [Parameter(Mandatory=$true)]  $botName
)

$apps = az ad app list | ConvertFrom-Json
$doCreate = $true
$val = $null


foreach($app in $apps)
{
  if($app.displayName -eq $botName)
  {

    $doCreate = $false
    $val =  $app
    break
  }

}

if($doCreate)
{
  $val = az ad app create --display-name $botName --password "tacospastapizza4@11" `
           --available-to-other-tenants | ConvertFrom-Json

}



$newAppId =  $val.appId
Write-Host $newAppId
Write-Host "##vso[task.setvariable variable=newAppId;]$newAppId"