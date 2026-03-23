namespace ManufacturerManagerAWS.Application.DTOs.ColourJustifications;

public class ColourJustificationDetailsDto
{
    public string ColourJustificationId { get; set; } = default!;

    public string Justification { get;set; } = default!;

    public List<WidgetSummaryDto> Widgets { get; set; } = new();
}
