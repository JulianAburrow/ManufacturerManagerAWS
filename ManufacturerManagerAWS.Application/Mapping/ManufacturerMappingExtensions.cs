namespace ManufacturerManagerAWS.Application.Mapping;

public static class ManufacturerMappingExtensions
{
    public static ManufacturerDetailsDto ToDto(this ManufacturerModel model) => new()
    {
        ManufacturerId = model.ManufacturerId,
        Name = model.Name,
        StatusId = model.StatusId,
    };

    public static ManufacturerModel ToModel(this CreateManufacturerRequest request) => new()
    {
        ManufacturerId = $"MANUFACTURER#{Guid.NewGuid()}",
        Name = request.Name,
        StatusId = request.StatusId,
    };

    public static ManufacturerModel ToModel(this UpdateManufacturerRequest request) => new()
    {
        ManufacturerId = request.ManufacturerId,
        Name = request.Name,
        StatusId = request.StatusId,
    };
}
