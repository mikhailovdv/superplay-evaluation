namespace Play.Contracts.Json;

public interface IPlayJson
{
    string Serialize<T>(
        T content);
    
    T? Deserialize<T>(
        string json);
}