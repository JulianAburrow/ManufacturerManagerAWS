namespace ManufacturerManagerAWS.DataAccess.Repositories;

public class ManufacturerStatusRepository(IDynamoDBContext context) : IManufacturerStatusRepository
{
    public async Task<ManufacturerStatusModel?> GetManufacturerStatusAsync(string statusId) =>
        await context.LoadAsync<ManufacturerStatusModel>(statusId);

    public async Task<IEnumerable<ManufacturerStatusModel>> GetManufacturerStatusesAsync()
    {
        var conditions = new List<ScanCondition>();
        return await context.ScanAsync<ManufacturerStatusModel>(conditions).GetRemainingAsync();
    }
}
