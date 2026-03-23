namespace ManufacturerManagerAWS.UserInterface.Shared.Components;

public partial class ColourJustificationGridviewComponent
{
    [Parameter] public List<ColourJustificationWithWidgetCountDto> ColourJustifications { get; set; } = null!;
}