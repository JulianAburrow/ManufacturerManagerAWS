namespace ManufacturerManagerAWS.DataAccess.Repositories;

public class WidgetRepository(IDynamoDBContext context) : IWidgetRepository
{
    public Task CreateWidgetAsync(WidgetModel widget) =>
        context.SaveAsync(widget);

    public Task DeleteWidgetAsync(string widgetId) =>
        context.DeleteAsync<WidgetModel>(widgetId);

    public async Task<WidgetModel?> GetWidgetAsync(string widgetId) =>
        await context.LoadAsync<WidgetModel>(widgetId);

    public async Task<IEnumerable<WidgetModel>> GetWidgetsAsync()
    {
        var conditions = new List<ScanCondition>();
        return await context.ScanAsync<WidgetModel>(conditions).GetRemainingAsync();
    }

    public Task<List<WidgetModel>> GetWidgetsByColourAsync(string colourId) =>
    ScanWidgetsAsync(nameof(WidgetModel.ColourId), colourId);

    public Task<List<WidgetModel>> GetWidgetsByColourJustificationAsync(string colourJustificationId) =>
        ScanWidgetsAsync(nameof(WidgetModel.ColourJustificationId), colourJustificationId);

    public async Task<int> GetWidgetCountByColourAsync(string colourId) =>
        (await ScanWidgetsAsync(nameof(WidgetModel.ColourId), colourId)).Count;

    public async Task<int> GetWidgetCountByColourJustificationAsync(string colourJustificationId) =>
        (await ScanWidgetsAsync(nameof(WidgetModel.ColourJustificationId), colourJustificationId)).Count;

    public async Task<List<WidgetModel>> GetWidgetsByStatusAsync(string statusId) =>
        (await ScanWidgetsAsync(nameof(WidgetModel.StatusId), statusId));

    public async Task<int> GetWidgetCountByStatusAsync(string statusId) =>
        (await ScanWidgetsAsync(nameof(WidgetModel.StatusId), statusId)).Count;

    public async Task<int> GetWidgetCountByManufacturerAsync(string manufacturerId) =>
        (await ScanWidgetsAsync(nameof(WidgetModel.ManufacturerId), manufacturerId)).Count;

    private async Task<List<WidgetModel>> ScanWidgetsAsync(string propertyName, string value)
    {
        var conditions = new List<ScanCondition>
        {
            new(propertyName, ScanOperator.Equal, value)
        };

        return await context
            .ScanAsync<WidgetModel>(conditions)
            .GetRemainingAsync();
    }

    public Task UpdateWidgetAsync(WidgetModel widget) =>
        context.SaveAsync(widget);

    public Task<List<WidgetModel>> GetWidgetsByManufacturerAsync(string manufacturerId) =>
        ScanWidgetsAsync(nameof(WidgetModel.ManufacturerId), manufacturerId);
}
