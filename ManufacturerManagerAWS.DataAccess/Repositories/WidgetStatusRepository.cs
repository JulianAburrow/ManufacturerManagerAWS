namespace ManufacturerManagerAWS.DataAccess.Repositories;

public class WidgetStatusRepository(IDynamoDBContext context) : IWidgetStatusRepository
{
    public async Task<WidgetStatusModel?> GetWidgetStatusAsync(string statusId) =>
        await context.LoadAsync<WidgetStatusModel>(statusId);

    public async Task<WidgetStatusModel?> GetWidgetStatusByName(string statusName)
    {
        var statuses = await GetWidgetStatusesAsync();
        return statuses.FirstOrDefault(s => s.Name.Equals(statusName, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<IEnumerable<WidgetStatusModel>> GetWidgetStatusesAsync()
    {
        var conditions = new List<ScanCondition>();
        return await context.ScanAsync<WidgetStatusModel>(conditions).GetRemainingAsync();
    }
}
