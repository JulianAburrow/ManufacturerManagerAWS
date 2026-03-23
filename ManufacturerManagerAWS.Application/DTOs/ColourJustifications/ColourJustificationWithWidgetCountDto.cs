namespace ManufacturerManagerAWS.Application.DTOs.ColourJustifications;

public class ColourJustificationWithWidgetCountDto
{
    public string ColourJustificationId { get; set; } = default!;

    public string Justification { get; set;} = default!;

    public int WidgetCount { get; set; }
}
