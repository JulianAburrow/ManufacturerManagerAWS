namespace ManufacturerManagerAWS.Application.DTOs.Manufacturers;

public class ManufacturerDetailsDto
{
    public string ManufacturerId { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string StatusId { get; set; } = default!;

    public string StatusName { get; set; } = default!;

    public List<WidgetDetailsDto> Widgets { get; set; } = new();
}
