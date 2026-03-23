namespace ManufacturerManagerAWS.Application.DTOs.Manufacturers;

public class CreateManufacturerRequest
{
    public string Name { get; set; } = default!;

    public string StatusId { get; set; } = default!;
}
