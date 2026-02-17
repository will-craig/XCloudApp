# Common
variable "environment" {
  type    = string
  default = "poc"
}

# Azure
variable "azure_rg_name" {
  type = string
}
variable "azure_location" {
  type = string
}

# AWS
variable "aws_region" {
  type = string
}
variable "aws_eks_cluster_role_arn" {
  type = string
}
variable "aws_eks_node_role_arn" {
  type = string
}
variable "aws_subnet_ids" {
  type = list(string)
}

# GCP
variable "gcp_project_id" {
  type = string
}
variable "gcp_region" {
  type = string
}
variable "gcp_service_account_email" {
  type = string
}
