namespace ManufacturerManagerAWS.DataAccess.Interfaces;

public interface ITransactionRepository
{
    Task ExecuteTransactionAsync(IEnumerable<TransactWriteItem> items);
}
