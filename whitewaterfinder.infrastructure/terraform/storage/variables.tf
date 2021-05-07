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

variable "kind" {
    description = "storage type"
    type        = string
    default     = "StorageV2"
}

variable "tier" {
    description = "account tier for storage"
    type        = string
    default     = "Standard"
}

variable "redundancy" {
    description = "failover redundancy of the resource"
    type        = string
    default     = "LRS"
}

