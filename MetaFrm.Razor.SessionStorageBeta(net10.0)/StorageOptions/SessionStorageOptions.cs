using System.Text.Json;

namespace Blazored.SessionStorage.StorageOptions;

/// <summary>
/// 
/// </summary>
public class SessionStorageOptions
{
    /// <summary>
    /// 
    /// </summary>
    public JsonSerializerOptions JsonSerializerOptions { get; set; } = new();
}
