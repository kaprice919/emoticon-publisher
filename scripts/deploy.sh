#!/bin/bash
set -e
set -u

# Requires the following environment variables to be set:
# - ARM_TENANT_ID
# - ARM_SUBSCRIPTION_ID
# - ARM_CLIENT_ID
# - ARM_CLIENT_SECRET

echo "Starting Deployment"

echo Configure Terraform
terraform init -reconfigure

echo Deploy Infrastructure
terraform apply -auto-approve

echo Deploying functions...