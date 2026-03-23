namespace ManufacturerManagerAWS.DataAccess.Models;

[DynamoDBTable("ManufacturerManager_ManufacturerStatus")]
public class ManufacturerStatusModel
{
    [DynamoDBHashKey]
    public string ManufacturerStatusId {  get; set; } = default!;

    public string Name { get; set; } = default!;
}
