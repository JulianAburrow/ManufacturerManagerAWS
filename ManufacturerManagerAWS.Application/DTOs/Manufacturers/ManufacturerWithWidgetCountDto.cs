namespace ManufacturerManagerAWS.Application.DTOs.Manufacturers;

public class ManufacturerWithWidgetCountDto
{
    public string ManufacturerId { get; set; } = default!;

    public string Name { get; set;} = default!;

    public string StatusId { get; set; } = default!;

    public string StatusName { get; set; } = default!;

    public int WidgetCount { get; set; }
}
