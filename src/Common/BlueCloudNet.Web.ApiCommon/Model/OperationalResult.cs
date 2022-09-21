using System.Text.Json.Serialization;

namespace BlueCloudNet.Web.ApiCommon.Model;

public class OperationalResult
{
    public OperationalStatus Status { get; set; }
    public string Message { get; set; } = String.Empty;

    [JsonIgnore]
    public bool IsSuccessed => this.Status is OperationalStatus.Succeeded;
}

public class OperationalResult<T> : OperationalResult
{
    public T? Data { get; set; }
}