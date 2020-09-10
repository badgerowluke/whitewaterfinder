resource "azurerm_app_service_plan" "pf-plan" {
  name                = "paddlefinderplan"
  location            = var.location
  resource_group_name = var.rg_name

  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}

resource "azurerm_function_app" "paddlefinder" {
  name                      = var.name
  location                  = var.location
  resource_group_name       = var.rg_name
  app_service_plan_id       = azurerm_app_service_plan.pf-plan.id

  storage_account_name      = var.storage_account_name
  storage_account_access_key= var.storage_account_key

  app_settings = {
    APPINSIGHTS_INSTRUMENTATIONKEY = var.instrumentkey
    APPINSIGHTS_CONNECTION_STRING = "InstrumentationKey=${var.instrumentkey}"
    ApplicationInsightsAgent_EXTENSION_VERSION = "~2"
    FUNCTIONS_WORKER_RUNTIME = "dotnet"
    FUNCTIONS_EXTENSION_VERSION = "~3"
    "WEBSITE_CONTENTSHARE" = lower("${var.name}")  
    "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}"
    "blobStore" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}"
    "AzureWebJobsStorage" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}"
    "azureSearchKey" = var.searchkey
    "azureSearchUrl" = "" 
    "baseUSGSUrl" = ""
  }
}

resource "azurerm_function_app" "pf-users" {
  name                      = "${var.name}-users"
  location                  = var.location
  resource_group_name       = var.rg_name
  app_service_plan_id       = azurerm_app_service_plan.pf-plan.id

  storage_account_name      = var.storage_account_name
  storage_account_access_key= var.storage_account_key

  app_settings = {
    APPINSIGHTS_INSTRUMENTATIONKEY = var.instrumentkey
    APPINSIGHTS_CONNECTION_STRING = "InstrumentationKey=${var.instrumentkey}"
    ApplicationInsightsAgent_EXTENSION_VERSION = "~2"   
    "WEBSITE_CONTENTSHARE" = lower("${var.name}-users")  
    "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}" 
    "AzureWebJobsStorage" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}"
    "blobStore" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}"
  }

}

resource "azurerm_function_app" "pf-webster" {
  name                        = "${var.name}-${var.botName}"
  location                    = var.location
  resource_group_name         = var.rg_name
  app_service_plan_id         = azurerm_app_service_plan.pf-plan.id
  storage_account_name        = var.storage_account_name
  storage_account_access_key  = var.storage_account_key

  app_settings = {
    "stateStore"        = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}"
    "LuisAPIHostName"   = ""
    "MicrosoftAppId"    = ""
    "MicrosoftAppPassword" = ""
    APPINSIGHTS_INSTRUMENTATIONKEY = var.instrumentkey
    APPINSIGHTS_CONNECTION_STRING = "InstrumentationKey=${var.instrumentkey}"
    ApplicationInsightsAgent_EXTENSION_VERSION = "~2"   
    "WEBSITE_CONTENTSHARE" = lower("${var.name}-users")  
    "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}" 
    "AzureWebJobsStorage" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}"

  }  
}

resource "azurerm_function_app" "pf-admin" {
  name = "${var.name}-admin"
  location = var.location
  resource_group_name = var.rg_name
  app_service_plan_id = azurerm_app_service_plan.pf-plan.id
  storage_account_name = var.storage_account_name
  storage_account_access_key = var.storage_account_key
  
  app_settings = {
    APPINSIGHTS_INSTRUMENTATIONKEY = var.instrumentkey
    APPINSIGHTS_CONNECTION_STRING = "InstrumentationKey=${var.instrumentkey}"
    ApplicationInsightsAgent_EXTENSION_VERSION = "~2"   
    "WEBSITE_CONTENTSHARE" = lower("${var.name}-users")  
    "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}" 
    "AzureWebJobsStorage" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}"
    "blobStore" = "DefaultEndpointsProtocol=https;AccountName=${var.storage_account_name};AccountKey=${var.storage_account_key}"
  }
}
