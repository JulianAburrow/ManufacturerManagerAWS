namespace ManufacturerManagerAWS.DataAccess.Context;

public class DynamoDbDataContext (IDynamoDBContext context)
{
    public Task<T> LoadAsync<T>(object hashKey, CancellationToken cancellationToken = default)
        => context.LoadAsync<T>(hashKey, cancellationToken);

    public IAsyncSearch<T> ScanAsync<T>(IEnumerable<ScanCondition> conditions)
        => context.ScanAsync<T>(conditions);

    public Task SaveAsync<T>(T value, CancellationToken cancellationToken = default)
        => context.SaveAsync(value, cancellationToken);

    public Task DeleteAsync<T>(object hashKey, CancellationToken cancellationToken = default)
        => context.DeleteAsync<T>(hashKey, cancellationToken);
}
