namespace ManufacturerManagerAWS.UserInterface.Shared.Components;

public partial class ColourGridviewComponent
{
    [Parameter] public List<ColourWithWidgetCountDto> Colours { get; set; } = null!;
}