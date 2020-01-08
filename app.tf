provider "azurerm" {
  version = "=1.28.0"
}

terraform {
  backend "azurerm" {
    container_name = "emoticonpublisher"
    key = "emoticonpublisher.tfstate"
  }
}

variable "app_name" {
    description = "Azure function app name."
    default = "emoticonservice"
}
variable "resource_group_name" {
    description = "Azure resource group name."
    default = "emoticon_service"
}
variable "storage_account_name" {
    description = "The name of the storage account."
    default = "storageaccountemotiaab2"
}
variable "resource_location" {
    description = "Azure resource location."
    default = "Central US"
}

resource "azurerm_storage_account" "EmoticonPublisher" {
  name                     = "${var.storage_account_name}"
  resource_group_name      = "${var.resource_group_name}"
  location                 = "${var.resource_location}"
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_app_service_plan" "EmoticonPublisher" {
  name                = "${var.app_name}"
  location            = "${var.resource_location}"
  resource_group_name = "${var.resource_group_name}"
  kind                = "FunctionApp"

  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}

resource "azurerm_application_insights" "EmoticonPublisher" {
  name                = "${var.app_name}"
  location            = "${var.resource_location}"
  resource_group_name = "${var.resource_group_name}"
  application_type    = "web"

}

resource "azurerm_function_app" "EmoticonPublisher" {
  name                      = "${var.app_name}"
  location                  = "${var.resource_location}"
  resource_group_name       = "${var.resource_group_name}"
  app_service_plan_id       = "${azurerm_app_service_plan.EmoticonPublisher.id}"
  storage_connection_string = "${azurerm_storage_account.EmoticonPublisher.primary_connection_string}"
  version                   = "~3"

}