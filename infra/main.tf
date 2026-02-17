terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0"
    }
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }
    google = {
      source  = "hashicorp/google"
      version = "4.51.0"
    }
  }
}

provider "azurerm" {
  features {}
}

provider "aws" {
  region = var.aws_region
}

provider "google" {
  project = var.gcp_project_id
  region  = var.gcp_region
}

module "azure_aks" {
  source              = "./modules/azure_aks"
  resource_group_name = var.azure_rg_name
  location            = var.azure_location
  cluster_name        = "xcloudapp-aks"
  node_count          = 2
}

module "aws_eks" {
  source           = "./modules/aws_eks"
  cluster_name     = "xcloudapp-eks"
  cluster_role_arn = var.aws_eks_cluster_role_arn
  node_role_arn    = var.aws_eks_node_role_arn
  subnet_ids       = var.aws_subnet_ids
  node_count       = 2
}

module "gcp_gke" {
  source                = "./modules/gcp_gke"
  cluster_name          = "xcloudapp-gke"
  location              = var.gcp_region
  node_count            = 1
  service_account_email = var.gcp_service_account_email
}
