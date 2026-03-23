namespace ManufacturerManagerAWS.Application.DTOs.Colours;

public class ColourWithWidgetCountDto
{
    public string ColourId { get; set; } = default!;

    public string Name { get; set; } = default!;

    public int WidgetCount { get; set; }
}
