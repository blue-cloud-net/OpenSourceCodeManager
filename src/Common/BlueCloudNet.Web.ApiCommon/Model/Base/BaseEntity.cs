namespace BlueCloudNet.Web.ApiCommon.Model.Entities;

public abstract class BaseEntity : IEntity
{
    public string Id { get; set; } = String.Empty;

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
    public bool IsDelete { get; set; } = false;
    public DateTime? DeleteTime { get; set; }
}
