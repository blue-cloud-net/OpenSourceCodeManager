namespace OSCManager.Abstractions.Model.Entities;

public class SourceHub : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;

    public ICollection<SourceHubRegistry> Registries { get; set; } = new List<SourceHubRegistry>();
}
