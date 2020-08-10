

param (
    [Parameter(Mandatory=$true)][string] $templateOutput,
    [Parameter(Mandatory=$true)][string] $containerName,
    [Parameter(Mandatory=$true)][string] $tableOrQueue
)
$json = $templateOutput | ConvertFrom-Json


$key =  $json.storageKey.Value
$container = $json.storageAccountName.Value



if( "table" -eq $tableOrQueue) {
    az storage table create -n $containerName `
    --account-key $key `
    --account-name $container

}

if( "queue" -eq $tableOrQueue) {
    az storage queue create -n $containerName `
    --account-key $key `
    --account-name $container
}