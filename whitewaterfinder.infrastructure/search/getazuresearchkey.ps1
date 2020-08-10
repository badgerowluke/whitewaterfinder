param (
    [Parameter(Mandatory=$true)][string] $templateOutput,
    [Parameter(Mandatory=$true)][string] $variableName
)



$json = $templateOutput | ConvertFrom-Json

Write-Host $json
Write-Host "##vso[task.setvariable variable=$variableName]$json.searchKey.Value"


# $key = az search query-key list --resource-group $resourceGroup --service-name 'waterfindersearch' | ConvertFrom-Json
# $keyValue = $key.key
# Write-Host "##vso[task.setvariable variable=searchKey;]$keyValue"


