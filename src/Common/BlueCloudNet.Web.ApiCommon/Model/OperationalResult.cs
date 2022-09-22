using System.Data.Common;
using System.Text.Json.Serialization;

namespace BlueCloudNet.Web.ApiCommon.Model;

public class OperationalResult
{
    public OperationalStatus Status { get; set; }
    public string Message { get; set; } = String.Empty;

    [JsonIgnore]
    public bool IsSuccessed => this.Status is OperationalStatus.Succeeded;

    public static OperationalResult OK() => new();
    public static OperationalResult Failed(string message) => new()
    {
        Status = OperationalStatus.Failed,
        Message = message,
    };
    public static OperationalResult Error(Exception e) => new()
    {
        Status = OperationalStatus.Failed,
        Message = e.Message,
    };
}

public class OperationalResult<T> : OperationalResult
{
    public T? Data { get; set; }

    public static new OperationalResult<T> OK() => new();
    public static OperationalResult<T> OK(T? data) => new() { Data = data };
    public static new OperationalResult<T> Failed(string message) => new()
    {
        Status = OperationalStatus.Failed,
        Message = message,
    };
    public static new OperationalResult<T> Error(Exception e) => new()
    {
        Status = OperationalStatus.Failed,
        Message = e.Message,
    };
}