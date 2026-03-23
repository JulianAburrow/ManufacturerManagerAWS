namespace ManufacturerManagerAWS.DataAccess.Interfaces;

public interface IColourJustificationRepository
{
    Task<ColourJustificationModel?> GetColourJustificationAsync(string colourJustificationId);

    Task<IEnumerable<ColourJustificationModel>> GetColourJustificationsAsync();

    Task CreateColourJustificationAsync(ColourJustificationModel colourJustification);

    Task UpdateColourJustificationAsync(ColourJustificationModel colourJustification);

    Task DeleteColourJustificationAsync(string colourJustificationId);
}
