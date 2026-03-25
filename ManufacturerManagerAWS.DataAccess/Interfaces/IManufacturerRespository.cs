namespace ManufacturerManagerAWS.DataAccess.Interfaces;

public interface IManufacturerRepository
{
    Task<ManufacturerModel?> GetManufacturerAsync(string manufacturerId);

    Task<IEnumerable<ManufacturerModel>> GetManufacturersAsync();

    Task CreateManufacturerAsync(ManufacturerModel manufacturer);

    Task UpdateManufacturerAsync(ManufacturerModel manufacturer);

    TransactWriteItem BuildUpdateTransactItem(ManufacturerModel model);
}
