namespace OSCManager.Abstractions.Model.Entities;

public class SourceHubRegistry : BaseEntity
{
    public string Domain { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public Uri Url { get; set; } = default!;
    public bool IsMainRegistry { get; set; }
    public bool IsUseRegistry { get; set; }

    public string UrlString => this.Url.ToString();
}
