namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Admin.Colours;

public partial class EditColour
{
    private ColourDetailsDto? LoadedColour { get; set; }

    private UpdateColourRequest UpdateColourRequest { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(ColourId))
            return;

        LoadedColour = await ColourService.GetColourDetailsAsync(ColourId);

        if (LoadedColour is null)
        {
            Snackbar.Add($"{ColourSingular} not found.", Severity.Warning);
            NavigationManager.NavigateTo($"/{ColourPlural.ToLower()}/list{ColourPlural.ToLower()}");
            return;
        }

        ColourDisplayModel.Name = LoadedColour.Name;

        MainLayout.SetHeaderValue($"Edit {ColourSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"Edit {ColourSingular}"),
        ]);
    }

    private async Task UpdateColourAsync()
    {
        try
        {
            UpdateColourRequest.ColourId = LoadedColour!.ColourId;
            UpdateColourRequest.Name = ColourDisplayModel.Name;

            await ColourService.UpdateColourAsync(UpdateColourRequest);

            Snackbar.Add($"{ColourSingular} {UpdateColourRequest.Name} successfully updated.", Severity.Success);
            NavigationManager.NavigateTo($"/{ColourPlural.ToLower()}/list{ColourPlural.ToLower()}");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {ColourSingular.ToLower()} {UpdateColourRequest.Name}. Please try again.", Severity.Error);
        }
    }
}