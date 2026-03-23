namespace ManufacturerManagerAWS.Application.DTOs.Widgets;

public class WidgetSummaryDto
{
    public string WidgetId { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string? ColourId { get; set; }

    public string ColourName { get; set; } = default!;

    public string? ColourJustificationId { get; set; }

    public string ColourJustificationJustification { get; set; } = default!;

    public string StatusId { get; set; } = default!;

    public string StatusName { get; set; } = default!;
}
