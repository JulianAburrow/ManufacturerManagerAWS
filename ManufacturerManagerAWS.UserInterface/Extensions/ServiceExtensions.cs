using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using ManufacturerManagerAWS.Application.Services.Colour;
using ManufacturerManagerAWS.DataAccess.Context;
using ManufacturerManagerAWS.DataAccess.Interfaces;
using ManufacturerManagerAWS.DataAccess.Repositories;

namespace ManufacturerManagerAWS.UserInterface.Extensions;

public static class ServiceExtensions
{
    public static void AddDependencies(this IServiceCollection services)
    {
        // 1. Register the DynamoDB client manually
        services.AddSingleton<IAmazonDynamoDB>(sp =>
        {
            return new AmazonDynamoDBClient(new AmazonDynamoDBConfig
            {
                ServiceURL = "http://localhost:4566",
                UseHttp = true,
                AuthenticationRegion = "us-east-1"
            });
        });

        // 2. Register the DynamoDB context
        services.AddSingleton<IDynamoDBContext>(sp =>
        {
            var client = sp.GetRequiredService<IAmazonDynamoDB>();

            #pragma warning disable CS0618 // DynamoDBContext is obsolete

            return new DynamoDBContext(client, new DynamoDBContextConfig
            {
                ConsistentRead = false,
                IgnoreNullValues = true,
                Conversion = DynamoDBEntryConversion.V2
            });
            
            #pragma warning restore CS0618


        });

        // 3. Register your wrapper
        services.AddSingleton<DynamoDbDataContext>();

        services.AddTransient<IColourRepository, ColourRepository>();
        services.AddTransient<IColourService, ColourService>();
        services.AddTransient<IColourJustificationRepository, ColourJustificationRepository>();
        services.AddTransient<IColourJustificationService, ColourJustificationService>();
        services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
        services.AddTransient<IManufacturerService, ManufacturerService>();
        services.AddTransient<IManufacturerStatusRepository, ManufacturerStatusRepository>();
        services.AddTransient<IManufacturerStatusService, ManufacturerStatusService>();
        services.AddTransient<IManufacturerService, ManufacturerService>();
        services.AddTransient<IWidgetRepository, WidgetRepository>();
        services.AddTransient<IWidgetService, WidgetService>();
        services.AddTransient<IWidgetStatusRepository, WidgetStatusRepository>();
        services.AddTransient<IWidgetStatusService, WidgetStatusService>();
    }
}