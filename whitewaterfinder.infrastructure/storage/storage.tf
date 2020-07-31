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



resource "azurerm_cosmosdb_account" "dbaccount" {
  name                  = "${var.name}db-account"
  location              = var.location
  resource_group_name   = var.rg_name
  offer_type            = "Standard"

  enable_free_tier      = true

  capabilities {
      name = "EnableCassandra"
  }

  consistency_policy {
    consistency_level       = "BoundedStaleness"
    max_interval_in_seconds = 10
    max_staleness_prefix    = 200
  }

  geo_location {
      location = var.location
      failover_priority = 0
  }
}