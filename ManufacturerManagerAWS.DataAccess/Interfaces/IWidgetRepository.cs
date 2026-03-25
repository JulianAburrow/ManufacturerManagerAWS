namespace ManufacturerManagerAWS.DataAccess.Interfaces;

public interface IWidgetRepository
{
    Task<WidgetModel?> GetWidgetAsync(string widgetId);

    Task<IEnumerable<WidgetModel>> GetWidgetsAsync();

    Task CreateWidgetAsync(WidgetModel widget);

    Task DeleteWidgetAsync(string widgetid);

    Task UpdateWidgetAsync(WidgetModel widget);

    Task<List<WidgetModel>> GetWidgetsByColourAsync(string colourId);

    Task<List<WidgetModel>> GetWidgetsByColourJustificationAsync(string colourJustificationId);

    Task<List<WidgetModel>> GetWidgetsByManufacturerAsync(string manufacturerId);

    Task<List<WidgetModel>> GetWidgetsByStatusAsync(string statusId);

    Task<int> GetWidgetCountByColourAsync(string colourId);

    Task<int> GetWidgetCountByColourJustificationAsync(string colourJustificationId);

    Task<int> GetWidgetCountByManufacturerAsync(string manufacturerId);

    Task<int> GetWidgetCountByStatusAsync(string widgetId);

    TransactWriteItem BuildUpdateTransactItem(WidgetModel model);
}
