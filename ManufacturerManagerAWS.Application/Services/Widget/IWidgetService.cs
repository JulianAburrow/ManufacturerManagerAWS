namespace ManufacturerManagerAWS.Application.Services.Widget;

public interface IWidgetService
{
    Task<WidgetDetailsDto> CreateWidgetAsync(CreateWidgetRequest request);

    Task<WidgetDetailsDto> UpdateWidgetAsync(UpdateWidgetRequest request);

    Task<WidgetDetailsDto?> GetWidgetDetailsAsync(string widgetId);

    Task<List<WidgetDetailsDto>> GetWidgetsAsync(IEnumerable<WidgetModel>? widgets = null);
}
