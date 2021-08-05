[![Netlify Status](https://api.netlify.com/api/v1/badges/cb5517bd-aa5a-4049-aaa0-ccb513384c88/deploy-status)](https://app.netlify.com/sites/reverent-yalow-362967/deploys)
[![.github/workflows/front.paddlefinder.yml](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/front.paddlefinder.yml/badge.svg)](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/front.paddlefinder.yml)
[![.github/workflows/api.admin.yml](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/api.admin.yml/badge.svg)](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/api.admin.yml)
[![.github/workflows/api.bot.yml](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/api.bot.yml/badge.svg)](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/api.bot.yml)
[![.github/workflows/api.monitoring.yml](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/api.monitoring.yml/badge.svg)](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/api.monitoring.yml)
[![.github/workflows/api.rivers.yml](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/api.rivers.yml/badge.svg)](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/api.rivers.yml)
[![.github/workflows/api.user.yml](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/api.user.yml/badge.svg)](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/api.user.yml)
[![.github/workflows/bicep.deploy.yml](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/bicep.deploy.yml/badge.svg)](https://github.com/badgerowluke/whitewaterfinder/actions/workflows/bicep.deploy.yml)

Included within this repo is a multi-year concept that would allow paddlers (or angulars, or any navigable water enthusiast) to determine the conditions of the users favorite river.  The architecture makes use of United States Geological Survey (USGS) River Gauging stations to retreive and calculate these data points.  The initial "river list" is populated and queried against an instance of Azure Search (currently), all other calls are made directly against the USGS API.

Also included is a wrapper for some of the National Weather Service APIs to retreive weather data.  There is currently no globalized search capability for locations included at this time.

The architecture for this api is trending towards serverless microservices, with the exception of the MSFT Bot Framework v4 app service (also slated to move to Az Func).  Infrastructure/Azure Resources are provisioned via ARM Templates currently, with the roadmap to move over to Terraform in the near future.

Currently utilizing microsoft's "economy" storage offerings, with an instance of the Free Tier Cosmos DB being added very recently.

## Github Actions Builds
we're using github actions to create the container images that are being hosted in Azure Container Registry.  The process requires a secret be stored in the Secrets section of the Repo Settings.
The format looks like this:


```json
{
    "clientId": "<SPNGUID>",
    "clientSecret": "<SPNSECRET>",
    "subscriptionId": "<SUBID>",
    "tenantId": "<TENANTID>"
}
```

## Infrastructure Provisioning with Azure Bicep
[Azure Bicep](https://github.com/Azure/bicep) is a super cool DSL that, by the Azure Teams own definition "starts to treat ARM Templates as an intermedate language".  It still utilizes the parameters construct the same way as when deploying ARM from the cli, we're passing that into the AZCLI to trigger the deployment:
```yml
    - name: provision
    working-directory: whitewaterfinder.infrastructure
    run: |
        az deployment sub create -f main.bicep \
                                -l northcentralus \
                                --parameters 'serviceprincipal=${{ secrets.SERVICE_PRINCIPAL }}' \
                                            'sppassword=${{ secrets.SPPASSWORD }}' \
                                            'tenant=${{ secrets.TENANT }}' \
                                            'botPassword=${{ secrets.BOTPASSWORD }}' \
                                            'luisAppId=${{ secrets.LUISID }}' \
                                            'adminId=${{ secrets.ADMINID }}'
```