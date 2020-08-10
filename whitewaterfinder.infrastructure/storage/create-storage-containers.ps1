

param (
    [Parameter(Mandatory=$true)] $templateOutput,
    [Parameter(Mandatory=$true)] $containerName,
    [Parameter(Mandatory=$true)] $tableOrQueue
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