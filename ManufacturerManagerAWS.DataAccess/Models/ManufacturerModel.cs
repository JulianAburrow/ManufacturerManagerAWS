namespace ManufacturerManagerAWS.DataAccess.Models;

[DynamoDBTable("ManufacturerManager_Manufacturer")]
public class ManufacturerModel
{
    [DynamoDBHashKey]
    public string ManufacturerId { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string StatusId { get; set; } = default!;
}
