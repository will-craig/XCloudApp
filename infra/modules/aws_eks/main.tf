resource "aws_eks_cluster" "eks" {
  name     = var.cluster_name
  role_arn = var.cluster_role_arn

  vpc_config {
    subnet_ids = var.subnet_ids
  }
}

resource "aws_eks_node_group" "nodes" {
  cluster_name    = aws_eks_cluster.eks.name
  node_group_name = "default-nodes"
  node_role_arn   = var.node_role_arn
  subnet_ids      = var.subnet_ids

  scaling_config {
    desired_size = var.node_count
    max_size     = var.node_count + 1
    min_size     = 1
  }

  instance_types = ["t3.medium"]
}

output "endpoint" {
  value = aws_eks_cluster.eks.endpoint
}

output "kubeconfig-certificate-authority-data" {
  value = aws_eks_cluster.eks.certificate_authority[0].data
}
