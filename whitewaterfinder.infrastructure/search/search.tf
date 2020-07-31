resource "azurerm_search_service" "search" {
    name = var.name
    resource_group_name = var.rg_name
    location = var.location
    sku = "free"
}