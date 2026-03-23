# Manufacturer Manager

A lightweight Blazor application for managing manufacturers and their widgets, backed by AWS DynamoDB.  

## Features

- Blazor Server UI
- Manufacturer and widget management with supplementary admin pages
- AWS DynamoDB back end for persistence

## Project Structure

- **Data Layer**  
  - AWS DynamoDB integration for storing manufacturers and widgets  
  - Simple repository pattern for data access

## Getting Started

1. Clone the repository  
2. Ensure LocalStack is running (the project is built against DynamoDB in LocalStack)  
3. Run the PowerShell setup scripts:
   - `CreateTables.ps1` – creates the required DynamoDB tables  
   - `SeedTables.ps1` – inserts initial sample data  
4. Start the Blazor Server project  
5. All DynamoDB connection settings (endpoint, region, credentials) are configured in `ServiceExtensions.cs`, so no AWS credential setup is required

## LocalStack

This project uses LocalStack to provide a local DynamoDB instance for development.  
You’ll need LocalStack running before executing the setup scripts or starting the application.

- https://localstack.cloud/

## Requirements

- .NET 10

## Why This Exists

This project serves as a compact example of building a Blazor application with a DynamoDB back end, using a clear DTO pattern and a tidy component architecture. It’s intentionally small, easy to read, and suitable as a reference or starting point for similar applications.
