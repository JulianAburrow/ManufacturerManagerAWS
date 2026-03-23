namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Widgets;

public partial class EditWidget
{
    private WidgetDetailsDto? LoadedWidget {  get; set; }

    private UpdateWidgetRequest UpdateWidgetRequest { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(WidgetId))
        {
            return;
        }

        LoadedWidget = await WidgetService.GetWidgetDetailsAsync(WidgetId);

        if (LoadedWidget is null)
        {
            Snackbar.Add($"{WidgetSingular} not found.", Severity.Warning);
            NavigationManager.NavigateTo($"/{WidgetPlural.ToLower()}/list{WidgetPlural.ToLower()}");
            return;
        }

        WidgetDisplayModel.Name = LoadedWidget.Name;
        WidgetDisplayModel.ManufacturerId = LoadedWidget.ManufacturerId;
        WidgetDisplayModel.ColourId = LoadedWidget.ColourId ?? SharedValues.PleaseSelectValue;
        WidgetDisplayModel.ColourJustificationId = LoadedWidget.ColourJustificationId ?? SharedValues.PleaseSelectValue;
        WidgetDisplayModel.StatusId = LoadedWidget.StatusId;
        WidgetDisplayModel.CostPrice = LoadedWidget.CostPrice;
        WidgetDisplayModel.RetailPrice = LoadedWidget.RetailPrice;
        WidgetDisplayModel.StockLevel = LoadedWidget.StockLevel;

        Manufacturers = await ManufacturerService.GetManufacturerSummariesAsync();
        Colours = await ColourService.GetColourDetailsListAsync();
        Colours.Insert(0, new ColourDetailsDto
        {
            ColourId = SharedValues.PleaseSelectValue,
            Name = SharedValues.PleaseSelectText,
        });
        ColourJustifications = await ColourJustificationService.GetColourJustificationDetailsListAsync();
        ColourJustifications.Insert(0, new ColourJustificationDetailsDto
        {
            ColourJustificationId = SharedValues.PleaseSelectValue,
            Justification = SharedValues.PleaseSelectText,
        });
        WidgetStatuses = await WidgetStatusService.GetWidgetStatusesAsync();
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetWidgetHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"Edit {WidgetSingular}"),
        ]);
    }

    private async Task UpdateWidgetAsync()
    {
        try
        {
            UpdateWidgetRequest.WidgetId = LoadedWidget!.WidgetId;
            UpdateWidgetRequest.Name = WidgetDisplayModel.Name;
            UpdateWidgetRequest.ManufacturerId = WidgetDisplayModel.ManufacturerId;
            UpdateWidgetRequest.ColourId = WidgetDisplayModel.ColourId != SharedValues.PleaseSelectValue ? WidgetDisplayModel.ColourId : null;
            UpdateWidgetRequest.ColourJustificationId = WidgetDisplayModel.ColourJustificationId != SharedValues.PleaseSelectValue ? WidgetDisplayModel.ColourJustificationId : null;
            UpdateWidgetRequest.StatusId = WidgetDisplayModel.StatusId;
            UpdateWidgetRequest.CostPrice = WidgetDisplayModel.CostPrice;
            UpdateWidgetRequest.RetailPrice = WidgetDisplayModel.RetailPrice;
            UpdateWidgetRequest.StockLevel = WidgetDisplayModel.StockLevel;

            await WidgetService.UpdateWidgetAsync(UpdateWidgetRequest);

            Snackbar.Add($"{WidgetSingular} {UpdateWidgetRequest.Name} successfully updated.", Severity.Success);
            NavigationManager.NavigateTo($"/{WidgetPlural.ToLower()}/list{WidgetPlural.ToLower()}");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {WidgetSingular.ToLower()} {UpdateWidgetRequest.Name}. Please try again.", Severity.Error);
        }
    }
}