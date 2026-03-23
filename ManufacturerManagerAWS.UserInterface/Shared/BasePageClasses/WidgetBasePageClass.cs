namespace ManufacturerManagerAWS.UserInterface.Shared.BasePageClasses;

public class WidgetBasePageClass : BasePageClass
{
    [Inject] protected IWidgetService WidgetService { get; set; } = null!;

    [Inject] protected IManufacturerService ManufacturerService { get; set; } = null!;

    [Inject] protected IColourService ColourService { get; set; } = null!;

    [Inject] protected IColourJustificationService ColourJustificationService { get; set; } = null!;

    [Inject] protected IWidgetStatusService WidgetStatusService { get; set; } = null!;

    [Parameter] public string? WidgetId { get; set; }

    protected WidgetDetailsDto? Widget { get; set;  }

    protected WidgetDisplayModel WidgetDisplayModel { get; set; } = new();

    protected List<ManufacturerSummaryDto> Manufacturers { get; set; } = null!;

    protected List<ColourDetailsDto> Colours { get; set; } = null!;

    protected List<ColourJustificationDetailsDto> ColourJustifications { get; set; } = null!;

    protected List<WidgetStatusDto> WidgetStatuses { get; set; } = null!;

    protected string WidgetSingular = "Widget";

    protected string WidgetPlural = "Widgets";

    protected BreadcrumbItem GetWidgetHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(WidgetPlural, $"{WidgetPlural.ToLower()}/list{WidgetPlural.ToLower()}", isDisabled);
    }
}
