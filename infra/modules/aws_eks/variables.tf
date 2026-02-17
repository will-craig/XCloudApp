variable "cluster_name" {
  type = string
}

variable "cluster_role_arn" {
  type        = string
  description = "ARN of the IAM role for the EKS cluster"
}

variable "node_role_arn" {
  type        = string
  description = "ARN of the IAM role for the Worker Nodes"
}

variable "subnet_ids" {
  type        = list(string)
  description = "List of subnet IDs for the cluster"
}

variable "node_count" {
  type    = number
  default = 2
}
