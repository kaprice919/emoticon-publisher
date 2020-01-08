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
terraform init \
    -reconfigure \
    -backend-config="storage_account_name=deployterraform" \
    -backend-config="resource_group_name=emoticon_service"

echo Deploy Infrastructure
terraform apply -auto-approve

echo Deploying functions
az login --service-principal \
  -u ${ARM_CLIENT_ID} \
  --password=${ARM_CLIENT_SECRET} \
  --tenant ${ARM_TENANT_ID}

echo Zipping deployment files
cd "EmoticonPublisher/bin/Release/"

rm -f EmoticonPublisher.zip
pushd netcoreapp3.0
    zip -r ../EmoticonPublisher.zip .
popd

echo Deploying functions to Azure
az functionapp deployment source config-zip \
    -g "emoticon_service" \
    -n "EmoticonPublisher" \
    --subscription "${ARM_SUBSCRIPTION_ID}" \
    --src EmoticonPublisher.zip