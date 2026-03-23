namespace ManufacturerManagerAWS.Application.Services.WidgetStatus;

public interface IWidgetStatusService
{
    Task<List<WidgetStatusDto>> GetWidgetStatusesAsync();

    Task<WidgetStatusDto?> GetWidgetStatusAsync(string statusId);
}
