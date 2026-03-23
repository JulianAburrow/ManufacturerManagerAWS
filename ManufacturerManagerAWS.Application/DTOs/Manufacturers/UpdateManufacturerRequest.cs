namespace ManufacturerManagerAWS.Application.DTOs.Manufacturers;

public class UpdateManufacturerRequest
{
    public string ManufacturerId { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string StatusId { get; set; } = default!;
}
