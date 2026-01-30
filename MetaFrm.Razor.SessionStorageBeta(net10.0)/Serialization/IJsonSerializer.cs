namespace Blazored.SessionStorage.Serialization;

/// <summary>
/// 
/// </summary>
public interface IJsonSerializer
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    string Serialize<T>(T obj);
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="text"></param>
    /// <returns></returns>
    T Deserialize<T>(string text);
}
