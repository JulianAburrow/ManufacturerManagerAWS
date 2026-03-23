namespace ManufacturerManagerAWS.Application.DTOs.Colours;

public class ColourDetailsDto
{
    public string ColourId { get; set; } = default!;

    public string Name { get; set; } = default!;

    public List<WidgetSummaryDto> Widgets { get; set; } = new();
}
