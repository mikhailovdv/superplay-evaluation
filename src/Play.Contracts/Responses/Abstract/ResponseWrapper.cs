using System.Text.Json.Serialization;

namespace Play.Contracts.Responses.Abstract;

public abstract record ResponseWrapper<TResponse> : IResponseWrapper<TResponse>
{
    public string Type { get; init; }
    
    public TResponse Payload { get; init; }

    [JsonConstructor]
    protected ResponseWrapper(
        string type,
        TResponse payload)
    {
        Type = type;
        Payload = payload;
    }
}