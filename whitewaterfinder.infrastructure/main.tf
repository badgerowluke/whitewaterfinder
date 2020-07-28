provider "azurerm" {
    version = "2.20.0"
    features {}
}
resource "azurerm_resource_group" "rg" {
    name = "waterfinder"
    location = "northcentralus"
}

resource "azurerm_storage_account" "storage" {
    name ="waterfinder"
    resource_group_name = azurerm_resource_group.rg.name
    location = azurerm_resource_group.rg.location
    account_tier = "Standard"
    account_replication_type = "LRS"
    account_kind = "StorageV2"
}

resource "azurerm_app_service_plan" "pf-plan" {
  name                = "paddlefinderplan"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}

resource "azurerm_application_insights" "insights" {
  name                = "paddlefinder"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  application_type    = "web"
}

output "instrumentation_key" {
  value = azurerm_application_insights.insights.instrumentation_key
}

resource "azurerm_function_app" "paddlefinder" {
  name                      = "paddlefinder"
  location                  = azurerm_resource_group.rg.location
  resource_group_name       = azurerm_resource_group.rg.name
  app_service_plan_id       = azurerm_app_service_plan.pf-plan.id
  storage_connection_string = azurerm_storage_account.storage.primary_connection_string

  app_settings = {
    APPINSIGHTS_INSTRUMENTATIONKEY = azurerm_application_insights.insights.instrumentation_key
  }

}

resource "azurerm_function_app" "pf-preferences" {
  name                      = "paddlefinderpreferences"
  location                  = azurerm_resource_group.rg.location
  resource_group_name       = azurerm_resource_group.rg.name
  app_service_plan_id       = azurerm_app_service_plan.pf-plan.id
  storage_connection_string = azurerm_storage_account.storage.primary_connection_string

}

