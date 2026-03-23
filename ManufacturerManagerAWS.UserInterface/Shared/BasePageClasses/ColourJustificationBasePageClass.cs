namespace ManufacturerManagerAWS.UserInterface.Shared.BasePageClasses;

public class ColourJustificationBasePageClass : BasePageClass
{
    [Inject] protected IColourJustificationService ColourJustificationService { get; set; } = null!;

    [Parameter] public string? ColourJustificationId { get; set; }

    protected ColourJustificationDisplayModel ColourJustificationDisplayModel { get; set; } = new();

    protected ColourJustificationDetailsDto? ColourJustification { get; set; }

    protected string ColourJustificationSingular = "ColourJustification";

    protected string ColourJustificationPlural = "ColourJustifications";

    protected BreadcrumbItem GetColourJustificationHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(ColourJustificationPlural, $"/{ColourJustificationPlural.ToLower()}/list{ColourJustificationPlural.ToLower()}", isDisabled);
    }
}
