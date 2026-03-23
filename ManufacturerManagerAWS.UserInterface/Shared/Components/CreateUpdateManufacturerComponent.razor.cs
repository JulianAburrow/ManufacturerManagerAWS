namespace ManufacturerManagerAWS.UserInterface.Shared.Components;

public partial class CreateUpdateManufacturerComponent
{
    [Parameter] public ManufacturerDisplayModel ManufacturerDisplayModel { get; set; } = new();

    [Parameter] public List<ManufacturerStatusDto> ManufacturerStatusDtos { get; set; } = null!;
}