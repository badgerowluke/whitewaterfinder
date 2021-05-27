resource "azurerm_storage_account" "storage" {
    name                        = var.name
    resource_group_name         = var.rg_name
    location                    = var.location
    account_tier                = var.tier
    account_replication_type    = var.redundancy
    account_kind                = var.kind
}



resource "azurerm_application_insights" "insights" {
  name                  = var.name
  location              = var.location
  resource_group_name   = var.rg_name
  application_type      = "web"
}
