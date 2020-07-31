resource "azurerm_api_management" "apim" {
  name                = var.name
  location            = var.location
  resource_group_name = var.rg_name
  publisher_name      = var.publisher
  publisher_email     = var.publisheremail

  sku_name = "Consumption_1"

  policy {
    xml_content = <<XML
    <policies>
      <inbound />
      <backend />
      <outbound />
      <on-error />
    </policies>
XML

  }
}

resource "azurerm_api_management_api" "rivers" {
    name = "rivers"
    resource_group_name = var.rg_name
    api_management_name =azurerm_api_management.apim.name
    revision = "1"
    display_name = "rivers"
    path = "rivers"
    protocols = ["https"]
    
}

resource "azurerm_api_management_api" "users" {
    name = "users"
    resource_group_name = var.rg_name
    api_management_name =azurerm_api_management.apim.name
    revision = "1"
    display_name = "users"
    path = "users"
    protocols = ["https"]
    
}