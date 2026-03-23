namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Admin.Colours;

public partial class DeleteColour
{
    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(ColourId))
        {
            return;
        }

        Colour = await ColourService.GetColourDetailsAsync(ColourId);

        if (Colour is null)
        {
            Snackbar.Add($"{ColourSingular} not found", Severity.Warning);
            NavigationManager.NavigateTo($"/{ColourSingular.ToLower()}/list{ColourPlural.ToLower()}");
            return;
        }

        PreventDeleting = Colour.Widgets.Count > 0;
        MainLayout.SetHeaderValue($"Delete {ColourSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"Delete {ColourSingular}"),
        ]);
    }

    private async Task DeleteColourAsync()
    {
        if (string.IsNullOrWhiteSpace(ColourId))
            return;

        try
        {
            await ColourService.DeleteColourAsync(ColourId);
            Snackbar.Add($"{ColourSingular} {Colour!.Name} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo($"/{ColourPlural.ToLower()}/list{ColourPlural.ToLower()}");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {ColourSingular.ToLower()} {Colour!.Name}. Please try again.", Severity.Error);
        }
    }
}