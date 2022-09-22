namespace OSCManager.Abstractions.Model.Entities;

public class Source : BaseEntity
{
    public string DisplayName { get; set; } = String.Empty;
    public string Belong { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;

    public Uri CreateUrl { get; set; } = default!;
    public string ConnectType { get; set; } = String.Empty;
    public string About { get; set; } = String.Empty;
    public string DefaultBranche { get; set; } = String.Empty;
    public DateTime LastUpdateTime { get; set; }

    public SourceHub Repository { get; set; } = new SourceHub();

    [NotMapped]
    public string Url => this.GetUrl();

    public string GetUrl()
    {
        var dowloadRegistry = this.Repository.Registries.FirstOrDefault();

        return dowloadRegistry is not null ? new Uri(dowloadRegistry.Url, this.Belong + "/" + this.Name).ToString() : String.Empty;
    }
}
