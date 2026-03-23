namespace ManufacturerManagerAWS.Application.Services.WidgetStatus;

public class WidgetStatusService(
    IWidgetStatusRepository widgetStatusRepository) : IWidgetStatusService
{
    public async Task<WidgetStatusDto?> GetWidgetStatusAsync(string statusId)
    {
        var widgetStatus = await widgetStatusRepository.GetWidgetStatusAsync(statusId);
        if (widgetStatus is null)
            return null;

        return new WidgetStatusDto
        {
            WidgetStatusId = widgetStatus.WidgetStatusId,
            Name = widgetStatus.Name,
        };
    }

    public async Task<List<WidgetStatusDto>> GetWidgetStatusesAsync()
    {
        var widgetStatuses = await widgetStatusRepository.GetWidgetStatusesAsync();

        return widgetStatuses.Select(w => new WidgetStatusDto
        {
            WidgetStatusId = w.WidgetStatusId,
            Name = w.Name,
        })
        .OrderBy(w => w.Name)
        .ToList();
    }
}
