namespace ManufacturerManagerAWS.DataAccess.Interfaces;

public interface IColourRepository
{
    Task<ColourModel?> GetColourAsync(string colourId);

    Task<IEnumerable<ColourModel>> GetColoursAsync();

    Task CreateColourAsync(ColourModel colour);

    Task UpdateColourAsync(ColourModel colour);

    Task DeleteColourAsync(string colourId);
}
