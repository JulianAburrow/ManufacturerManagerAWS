# ============================================
# Manufacturer Manager — Seed Data
# ============================================

$endpoint = "http://localhost:4566"
$region   = "us-east-1"

function New-IdGuid {
    [guid]::NewGuid().ToString()
}

Write-Host "=== Seeding ColourJustification ==="

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_ColourJustification `
  --item "{""ColourJustificationId"":{""S"":""COLOURJUSTIFICATION#$($(New-IdGuid))""},""Justification"":{""S"":""Felt like it""}}"

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_ColourJustification `
  --item "{""ColourJustificationId"":{""S"":""COLOURJUSTIFICATION#$($(New-IdGuid))""},""Justification"":{""S"":""Customer request""}}"

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_ColourJustification `
  --item "{""ColourJustificationId"":{""S"":""COLOURJUSTIFICATION#$($(New-IdGuid))""},""Justification"":{""S"":""It's all the rage, darling""}}"

Write-Host "=== Seeding Colour ==="

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_Colour `
  --item "{""ColourId"":{""S"":""COLOUR#$($(New-IdGuid))""},""Name"":{""S"":""Red""}}"

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_Colour `
  --item "{""ColourId"":{""S"":""COLOUR#$($(New-IdGuid))""},""Name"":{""S"":""Green""}}"

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_Colour `
  --item "{""ColourId"":{""S"":""COLOUR#$($(New-IdGuid))""},""Name"":{""S"":""Blue""}}"

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_Colour `
  --item "{""ColourId"":{""S"":""COLOUR#$($(New-IdGuid))""},""Name"":{""S"":""Pink""}}"


Write-Host "=== Seeding ManufacturerStatus ==="

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_ManufacturerStatus `
  --item "{""ManufacturerStatusId"":{""S"":""MANUFACTURERSTATUS#$($(New-IdGuid))""},""Name"":{""S"":""Active""}}"

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_ManufacturerStatus `
  --item "{""ManufacturerStatusId"":{""S"":""MANUFACTURERSTATUS#$($(New-IdGuid))""},""Name"":{""S"":""Inactive""}}"


Write-Host "=== Seeding WidgetStatus ==="

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_WidgetStatus `
  --item "{""WidgetStatusId"":{""S"":""WIDGETSTATUS#$($(New-IdGuid))""},""Name"":{""S"":""Active""}}"

aws dynamodb put-item `
  --endpoint-url $endpoint `
  --region $region `
  --table-name ManufacturerManager_WidgetStatus `
  --item "{""WidgetStatusId"":{""S"":""WIDGETSTATUS#$($(New-IdGuid))""},""Name"":{""S"":""Inactive""}}"


Write-Host "=== Seed complete ==="