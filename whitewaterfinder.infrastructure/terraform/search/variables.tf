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