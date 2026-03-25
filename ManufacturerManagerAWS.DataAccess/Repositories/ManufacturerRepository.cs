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

    public TransactWriteItem BuildUpdateTransactItem(ManufacturerModel model)
    {
        var key = new Dictionary<string, AttributeValue>
        {
            ["ManufacturerId"] = new AttributeValue { S = model.ManufacturerId }
        };

        var expressionValues = new Dictionary<string, AttributeValue>
        {
            [":name"] = new AttributeValue { S = model.Name },
            [":status"] = new AttributeValue { S = model.StatusId }
        };

        return new TransactWriteItem
        {
            Update = new Update
            {
                TableName = "ManufacturerManager_Manufacturer",
                Key = key,
                UpdateExpression = "SET #n = :name, #s = :status",
                ConditionExpression = "attribute_exists(ManufacturerId)",
                ExpressionAttributeNames = new Dictionary<string, string>
                {
                    ["#n"] = "Name",
                    ["#s"] = "StatusId"
                },
                ExpressionAttributeValues = expressionValues
            }
        };
    }
}
