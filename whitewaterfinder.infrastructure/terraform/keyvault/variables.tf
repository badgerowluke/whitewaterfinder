variable "name" {
    type = string 
    default = ""
}

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