namespace ManufacturerManagerAWS.DataAccess.Repositories;

public class TransactionRepository(IAmazonDynamoDB client) : ITransactionRepository
{
    public async Task ExecuteTransactionAsync(IEnumerable<TransactWriteItem> items)
    {
        var request = new TransactWriteItemsRequest
        {
            TransactItems = items.ToList(),
        };

        await client.TransactWriteItemsAsync(request);
    }
}
