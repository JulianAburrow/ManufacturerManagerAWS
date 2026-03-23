# ============================================
# Manufacturer Manager — Create Tables
# ============================================

Write-Host "RUNNING SCRIPT FROM: $PSScriptRoot"
Write-Host "SCRIPT FILE: $($MyInvocation.MyCommand.Path)"

$endpoint = "http://localhost:4566"
$region   = "us-east-1"

# --------------------------------------------
Write-Host "=== Creating ManufacturerManager_ManufacturerStatus ==="
aws dynamodb create-table `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_ManufacturerStatus `
  --attribute-definitions "AttributeName=ManufacturerStatusId,AttributeType=S" `
  --key-schema "AttributeName=ManufacturerStatusId,KeyType=HASH" `
  --billing-mode PAY_PER_REQUEST

# --------------------------------------------
Write-Host "=== Creating ManufacturerManager_ColourJustification ==="
aws dynamodb create-table `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_ColourJustification `
  --attribute-definitions "AttributeName=ColourJustificationId,AttributeType=S" `
  --key-schema "AttributeName=ColourJustificationId,KeyType=HASH" `
  --billing-mode PAY_PER_REQUEST

# --------------------------------------------
Write-Host "=== Creating ManufacturerManager_Colour ==="
aws dynamodb create-table `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_Colour `
  --attribute-definitions "AttributeName=ColourId,AttributeType=S" `
  --key-schema "AttributeName=ColourId,KeyType=HASH" `
  --billing-mode PAY_PER_REQUEST

# --------------------------------------------
Write-Host "=== Creating ManufacturerManager_Manufacturer ==="
aws dynamodb create-table `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_Manufacturer `
  --attribute-definitions "AttributeName=ManufacturerId,AttributeType=S" `
  --key-schema "AttributeName=ManufacturerId,KeyType=HASH" `
  --billing-mode PAY_PER_REQUEST

# --------------------------------------------
Write-Host "=== Creating ManufacturerManager_Widget ==="
aws dynamodb create-table `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_Widget `
  --attribute-definitions "AttributeName=WidgetId,AttributeType=S" `
  --key-schema "AttributeName=WidgetId,KeyType=HASH" `
  --billing-mode PAY_PER_REQUEST

# --------------------------------------------
Write-Host "=== Creating ManufacturerManager_WidgetStatus ==="
aws dynamodb create-table `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_WidgetStatus `
  --attribute-definitions "AttributeName=WidgetStatusId,AttributeType=S" `
  --key-schema "AttributeName=WidgetStatusId,KeyType=HASH" `
  --billing-mode PAY_PER_REQUEST

Write-Host "=== Table creation complete (errors about existing tables are normal) ==="