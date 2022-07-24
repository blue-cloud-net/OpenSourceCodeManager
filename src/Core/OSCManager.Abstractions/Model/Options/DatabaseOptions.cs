using System.ComponentModel.DataAnnotations;

namespace OSCManager.Abstractions.Model;

public class DatabaseOptions
{
    public string Type { get; set; } = String.Empty;

    [Required]
    public string ConnectionString { get; set; } = String.Empty;
}
