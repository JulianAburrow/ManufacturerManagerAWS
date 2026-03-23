namespace ManufacturerManagerAWS.DataAccess.Repositories;

public class ColourRepository(IDynamoDBContext context) : IColourRepository
{
    public Task CreateColourAsync(ColourModel colour) =>
        context.SaveAsync(colour);

    public Task DeleteColourAsync(string colourId) =>
        context.DeleteAsync<ColourModel>(colourId);

    public async Task<ColourModel?> GetColourAsync(string colourId) =>
        await context.LoadAsync<ColourModel>(colourId);

    public async Task<IEnumerable<ColourModel>> GetColoursAsync()
    {
        var conditions = new List<ScanCondition>();
        return await context.ScanAsync<ColourModel>(conditions).GetRemainingAsync();
    }

    public Task UpdateColourAsync(ColourModel colour) =>
        context.SaveAsync(colour);
}
