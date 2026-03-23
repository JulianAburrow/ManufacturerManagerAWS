namespace ManufacturerManagerAWS.UserInterface.Shared.BasePageClasses;

public class ManufacturerBasePageClass : BasePageClass
{
    [Inject] protected IManufacturerService ManufacturerService { get; set; } = null!;

    [Inject] protected IManufacturerStatusService ManufacturerStatusService { get; set; } = null!;

    [Parameter] public string? ManufacturerId { get; set; }

    protected ManufacturerDisplayModel ManufacturerDisplayModel { get; set; } = new();

    protected List<ManufacturerStatusDto> ManufacturerStatuses { get; set; } = null!;

    protected ManufacturerDetailsDto? Manufacturer { get; set; }

    protected string ManufacturerSingular = "Manufacturer";

    protected string ManufacturerPlural = "Manufacturers";

    protected string ManufacturerStatusSingular = "ManufacturerStatus";

    protected string ManufacturerStatusPlural = "ManufacturerStatuses";

    protected BreadcrumbItem GetManufacturerHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(ManufacturerPlural, $"/{ManufacturerPlural.ToLower()}/list{ManufacturerPlural.ToLower()}", isDisabled);
    }
}
