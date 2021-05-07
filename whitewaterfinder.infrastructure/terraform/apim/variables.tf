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

variable "publisher" {
    description = "owner"
    type = string
    default = "Burning River Solutions"
}

variable "publisheremail" {
    description = "how to get a hold of us"
    type = string
    default = ""
}