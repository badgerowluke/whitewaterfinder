resource "azurerm_api_management" "apim" {
  name                = var.name
  location            = var.location
  resource_group_name = var.rg_name
  publisher_name      = var.publisher
  publisher_email     = var.publisheremail

  sku_name = "Consumption_1"


}

resource "azurerm_api_management_api" "rivers" {
    name = "rivers"
    display_name = "rivers"
    path = "rivers"
    resource_group_name = var.rg_name
    api_management_name =azurerm_api_management.apim.name
    revision = "1"
    protocols = ["https"]
    
}

resource "azurerm_api_management_api" "users" {
    name = "users"
    display_name = "users"
    path = "users"
    resource_group_name = var.rg_name
    api_management_name =azurerm_api_management.apim.name
    revision = "1"
    protocols = ["https"]
    
}

resource "azurerm_api_management_api" "bot" {
    name = "webster"
    display_name = "webster"
    path = "webster"
    resource_group_name = var.rg_name
    api_management_name =azurerm_api_management.apim.name
    revision = "1"
    protocols = ["https"]
}

resource "azurerm_api_management_api" "pfadmin" {
    name = "pfadmin"
    display_name = "pfadmin"
    path = "pfadmin"
    resource_group_name = var.rg_name
    api_management_name = api_management_name.apim.name
    revision = "1"
    protocols = ["https"]
}