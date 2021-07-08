variable "name" {
  description = "the name of the registry"
  type        = string
  default     = "pf-registry"
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
