namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Widgets;

public partial class CreateWidget
{
    private CreateWidgetRequest CreateWidgetRequest { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Manufacturers = await ManufacturerService.GetManufacturerSummariesAsync();
        Manufacturers.Insert(0, new ManufacturerSummaryDto
        {
            ManufacturerId = SharedValues.PleaseSelectValue,
            Name = SharedValues.PleaseSelectText,
        });
        WidgetDisplayModel.ManufacturerId = SharedValues.PleaseSelectValue;

        Colours = await ColourService.GetColourDetailsListAsync();
        Colours.Insert(0, new ColourDetailsDto
        {
            ColourId = SharedValues.PleaseSelectValue,
            Name = SharedValues.PleaseSelectText,
        });
        WidgetDisplayModel.ColourId = SharedValues.PleaseSelectValue;

        ColourJustifications = await ColourJustificationService.GetColourJustificationDetailsListAsync();
        ColourJustifications.Insert(0, new ColourJustificationDetailsDto
        {
            ColourJustificationId = SharedValues.PleaseSelectValue,
            Justification = SharedValues.PleaseSelectText,
        });
        WidgetDisplayModel.ColourJustificationId = SharedValues.PleaseSelectValue;

        WidgetStatuses = await WidgetStatusService.GetWidgetStatusesAsync();
        WidgetStatuses.Insert(0, new WidgetStatusDto
        {
            WidgetStatusId = SharedValues.PleaseSelectValue,
            Name = SharedValues.PleaseSelectText,
        });
        WidgetDisplayModel.StatusId = SharedValues.PleaseSelectValue;

        MainLayout.SetHeaderValue($"Create {WidgetSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetWidgetHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"Create {WidgetSingular}")
        ]);
    }

    private async Task CreateWidgetAsync()
    {
        try
        {
            CreateWidgetRequest.Name = WidgetDisplayModel.Name;
            CreateWidgetRequest.ManufacturerId = WidgetDisplayModel.ManufacturerId;
            CreateWidgetRequest.ColourId = WidgetDisplayModel.ColourId != SharedValues.PleaseSelectValue ? WidgetDisplayModel.ColourId : null;
            CreateWidgetRequest.ColourJustificationId = WidgetDisplayModel.ColourJustificationId != SharedValues.PleaseSelectValue ? WidgetDisplayModel.ColourJustificationId : null;
            CreateWidgetRequest.StatusId = WidgetDisplayModel.StatusId;
            CreateWidgetRequest.CostPrice = WidgetDisplayModel.CostPrice;
            CreateWidgetRequest.RetailPrice = WidgetDisplayModel.RetailPrice;
            CreateWidgetRequest.StockLevel = WidgetDisplayModel.StockLevel;

            await WidgetService.CreateWidgetAsync(CreateWidgetRequest);

            Snackbar.Add($"{WidgetSingular} {CreateWidgetRequest.Name} successfully created.", Severity.Success);
            NavigationManager.NavigateTo($"{WidgetPlural.ToLower()}/list{WidgetPlural.ToLower()}");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {WidgetSingular.ToLower()}. Please try again", Severity.Error);
        }
    }
}