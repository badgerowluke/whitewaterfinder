resource "azurerm_app_service_plan" "botplan" {
  name                = var.name
  location            = var.location
  resource_group_name = var.rg_name

  sku {
    tier = "Free"
    size = "F1"
  }
}

resource "azurerm_app_service" "botapp" {
  name                = var.name
  location            = var.location
  resource_group_name = var.rg_name
  app_service_plan_id = azurerm_app_service_plan.botplan.id



  app_settings = {
    "stateStore"        = ""
    "LuisAPIHostName"   = ""
    "MicrosoftAppId"    = ""
    "MicrosoftAppPassword" = ""
    APPINSIGHTS_INSTRUMENTATIONKEY = var.instrumentkey
    APPINSIGHTS_CONNECTION_STRING = "InstrumentationKey=${var.instrumentkey}"
    ApplicationInsightsAgent_EXTENSION_VERSION = "~2"
  }


}