namespace ManufacturerManagerAWS.DataAccess.Models;

[DynamoDBTable("ManufacturerManager_ColourJustification")]
public class ColourJustificationModel
{
    [DynamoDBHashKey]
    public string ColourJustificationId { get; set; } = default!;

    public string Justification { get; set; } = default!;
}
