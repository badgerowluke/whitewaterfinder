


provider "azurerm" {

  features {}

}


resource "azurerm_resource_group" "rg" {
  name     = "waterfinder"
  location = "northcentralus"
}

module "keyvault" {
  source   = "./keyvault"
  location = azurerm_resource_group.rg.location
  rg_name  = azurerm_resource_group.rg.name
  name     = azurerm_resource_group.rg.name
}

module "storage" {
  source   = "./storage"
  location = azurerm_resource_group.rg.location
  rg_name  = azurerm_resource_group.rg.name
  name     = azurerm_resource_group.rg.name
}

module "search" {
  source   = "./search"
  location = azurerm_resource_group.rg.location
  rg_name  = azurerm_resource_group.rg.name
  name     = "${azurerm_resource_group.rg.name}search"
}

module "api" {
  source               = "./api"
  location             = azurerm_resource_group.rg.location
  rg_name              = azurerm_resource_group.rg.name
  name                 = "paddlefinder"
  planname             = "paddlefinderplan"
  botName              = "webster"
  storage_conn_string  = module.storage.primary_conn_string
  instrumentkey        = module.storage.instrumentation_key
  storage_account_name = module.storage.account_name
  storage_account_key  = module.storage.account_key
  searchkey            = module.search.query_keys[0].key
}



