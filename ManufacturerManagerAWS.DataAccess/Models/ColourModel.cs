namespace ManufacturerManagerAWS.DataAccess.Models;

[DynamoDBTable("ManufacturerManager_Colour")]
public class ColourModel
{
    [DynamoDBHashKey]
    public string ColourId { get; set; } = default!;

    public string Name { get; set; } = default!;
}
