namespace ManufacturerManagerAWS.DataAccess.Models;

[DynamoDBTable("ManufacturerManager_WidgetStatus")]
public class WidgetStatusModel
{
    [DynamoDBHashKey]
    public string WidgetStatusId { get; set; } = default!;

    public string Name { get; set; } = default!;
}
