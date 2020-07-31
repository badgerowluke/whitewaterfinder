output "primary_conn_string" {
    value = azurerm_storage_account.storage.primary_connection_string
}

output "account_name" {
    value = azurerm_storage_account.storage.name
}

output "account_key" {
    value = azurerm_storage_account.storage.primary_access_key
}

output "instrumentation_key" {
    description = "insights instrumentaion key"
    value = azurerm_application_insights.insights.instrumentation_key
}