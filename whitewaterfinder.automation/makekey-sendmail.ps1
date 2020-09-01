param (
    [Parameter(Mandatory=$true)] $resourceGroup,
    [Parameter(Mandatory=$true)] $appName,
    [Parameter(Mandatory=$true)] $functionName,
    [Parameter(Mandatory=$true)] $sendgridKey
)

Import-Module ..\whitewaterfinder.infrastructure\modules\kudu-security.psm1
Import-Module ..\whitewaterfinder.infrastructure\modules\azure-functions.psm1 


$creds = Get-KuduCredentials "paddle-finder-preferences" "waterfinder"



$key = Set-NewKey "paddle-finder-preferences" "PostUserPreferences" "luke.badgerow@gmail.com" $creds

$value = $key.value

$msg = "your access key for the CirrusSense telemetry API is: $value"

Write-Host $msg





$header = @{
    "Authorization" =  "Bearer $sendgridKey"
}

$Body = @{
    "personalizations" = @(
        @{
            "to"      = @(
                @{
                    "email" = "badgerow.luke@gmail.com"
                    "name"  = "Luke"
                }
            )
            "subject" = " example "
        }
    )
    "content"          = @(
        @{
            "type"  = "text/plain"
            "value" = "$msg"
        }
    )
    "from"             = @{
        "email" = "keys-no-reply@paddle-finder.com"
        "name"  = "Paddle-Finder Keys"
    }
}

$BodyJson = $Body | ConvertTo-Json -Depth 4

$Parameters = @{
    Method      = "POST"
    Uri         = "https://api.sendgrid.com/v3/mail/send"
    Headers     = $Header
    ContentType = "application/json"
    Body        = $BodyJson
}
Invoke-RestMethod @Parameters