variable "location" {
    description = "the location of the resource"
    type        = string
    default     = "northcentralus"
    
}

variable "rg_name" {
    description = "resource group"
    type        = string
    default     = ""
}

variable "name" {
    description = "name of the resource"
    type        = string
    default     = ""
}

variable "planname" {
    description = "name of app service plan"
    type = string
    default = ""
}

variable "storage_conn_string" {
    description = "connection string for the storage account"
    type = string
    default = ""
}

variable "instrumentkey" {
    description = "insights instrumentation key"
    type = string
    default = ""
}

variable "storage_account_name" {
    type = string
    default = ""
}

variable "storage_account_key" {
    type = string 
    default = ""
}

variable "searchkey" {
    type = string
    default = ""
}