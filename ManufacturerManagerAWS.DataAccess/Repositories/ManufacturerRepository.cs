namespace ManufacturerManagerAWS.DataAccess.Repositories;

public class ManufacturerRepository(IDynamoDBContext context) : IManufacturerRepository
{
    public Task CreateManufacturerAsync(ManufacturerModel manufacturer) =>
        context.SaveAsync(manufacturer);

    public async Task<ManufacturerModel?> GetManufacturerAsync(string manufacturerId) =>
        await context.LoadAsync<ManufacturerModel>(manufacturerId);

    public async Task<IEnumerable<ManufacturerModel>> GetManufacturersAsync()
    {
        var conditions = new List<ScanCondition>();
        return await context.ScanAsync<ManufacturerModel>(conditions).GetRemainingAsync();
    }

    public Task UpdateManufacturerAsync(ManufacturerModel manufacturer) =>
        context.SaveAsync(manufacturer);
}
