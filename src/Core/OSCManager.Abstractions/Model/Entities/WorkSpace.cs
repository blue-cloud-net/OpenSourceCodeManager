namespace OSCManager.Abstractions.Model.Entities;

public class WorkSpace : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string Url { get; set; } = String.Empty;
}
