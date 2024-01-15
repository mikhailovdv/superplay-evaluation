using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Play.Contracts.Json.Converters;

namespace Play.Contracts.Json;

public class PlayJson : IPlayJson
{
    private readonly JsonSerializerOptions _options
        = new() {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters = {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };

    public string Serialize<T>(T content)
        => JsonSerializer.Serialize(content, _options);

    public T? Deserialize<T>(string json)
        => JsonSerializer.Deserialize<T>(json, _options);

    public PlayJson WithPlayRequestJsonConverter()
    {
        _options.Converters.Add(new PlayRequestJsonConverter());
        return this;
    }
    
    public PlayJson WithPlayResponseJsonConverter()
    {
        _options.Converters.Add(new PlayResponseJsonConverter());
        return this;
    }
}