namespace ManufacturerManagerAWS.UserInterface.Shared.Components;

public partial class CreateUpdateWidgetComponent
{
    [Parameter] public WidgetDisplayModel WidgetDisplayModel { get; set; } = new();

    [Parameter] public List<ManufacturerSummaryDto> ManufacturerDtos { get; set; } = null!;

    [Parameter] public List<ColourDetailsDto> ColourDtos { get; set; } = null!;

    [Parameter] public List<ColourJustificationDetailsDto> ColourJustificationDtos { get; set; } = null!;

    [Parameter] public List<WidgetStatusDto> WidgetStatusDtos { get; set;} = null!;
}