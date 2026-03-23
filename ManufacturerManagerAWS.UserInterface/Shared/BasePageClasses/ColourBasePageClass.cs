namespace ManufacturerManagerAWS.UserInterface.Shared.BasePageClasses;

public class ColourBasePageClass : BasePageClass
{
    [Inject] protected IColourService ColourService { get; set; } = null!;

    [Parameter] public string? ColourId { get; set; }

    protected ColourDisplayModel ColourDisplayModel { get; set; } = new();

    protected ColourDetailsDto? Colour { get; set; }

    protected string ColourSingular = "Colour";

    protected string ColourPlural = "Colours";

    protected BreadcrumbItem GetColourHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(ColourPlural, $"/{ColourPlural.ToLower()}/list{ColourPlural.ToLower()}", isDisabled);
    }
}
