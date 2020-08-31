param (
    [Parameter(Mandatory=$true)] $resourceGroup,
    [Parameter(Mandatory=$true)] $appName,
    [Parameter(Mandatory=$true)] $functionName,
    [Parameter(Mandatory=$true)] $emailAddress,
    [Parameter(Mandatory=$true)] $sendgridKey
)

Import-Module ..\whitewaterfinder.infrastructure\modules\kudu-security.psm1
Import-Module ..\whitewaterfinder.infrastructure\modules\azure-functions.psm1 


$creds = Get-KuduCredentials $appName $resourceGroup



$key = Set-NewKey $appName $functionName $emailAddress $creds

$value = $key.value

$msg = "your access key for $functionName : $value"

Write-Host $msg





$header = @{
    "Authorization" =  "Bearer $sendgridKey"
}

$Body = @{
    "personalizations" = @(
        @{
            "to"      = @(
                @{
                    "email" = $emalAddress

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
        "email" = "keys-no-reply@transducersdirect.com"
        "name"  = "Tr"
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