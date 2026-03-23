namespace ManufacturerManagerAWS.UserInterface.Shared.Components;

public partial class ManufacturerGridviewComponent
{
    [Parameter] public List<ManufacturerWithWidgetCountDto> Manufacturers { get; set; } = null!;
}