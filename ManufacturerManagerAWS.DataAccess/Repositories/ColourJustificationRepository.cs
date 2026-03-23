namespace ManufacturerManagerAWS.DataAccess.Repositories;

public class ColourJustificationRepository(IDynamoDBContext context) : IColourJustificationRepository
{
    public Task CreateColourJustificationAsync(ColourJustificationModel colourJustification) =>
        context.SaveAsync(colourJustification);

    public Task DeleteColourJustificationAsync(string colourJustificationId) =>
        context.DeleteAsync<ColourJustificationModel>(colourJustificationId);

    public async Task<ColourJustificationModel?> GetColourJustificationAsync(string colourJustificationId) =>
        await context.LoadAsync<ColourJustificationModel>(colourJustificationId);

    public async Task<IEnumerable<ColourJustificationModel>> GetColourJustificationsAsync()
    {
        var conditions = new List<ScanCondition>();
        return await context.ScanAsync<ColourJustificationModel>(conditions).GetRemainingAsync();
    }

    public Task UpdateColourJustificationAsync(ColourJustificationModel colourJustification) =>
        context.SaveAsync(colourJustification);

}
