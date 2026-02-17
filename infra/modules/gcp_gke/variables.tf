variable "location" {
  type        = string
  description = "GCP region or zone"
  default     = "us-central1-a"
}

variable "cluster_name" {
  type = string
}

variable "node_count" {
  type    = number
  default = 1
}

variable "service_account_email" {
  type        = string
  description = "Service account email for the node pool"
}
