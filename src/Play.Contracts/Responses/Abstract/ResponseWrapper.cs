using System.Text.Json.Serialization;

namespace Play.Contracts.Responses.Abstract;

public abstract record ResponseWrapper<TResponse> : IResponseWrapper<TResponse>
{
    public string Type { get; }
    
    public TResponse Payload { get; }

    [JsonConstructor]
    protected ResponseWrapper(
        string type,
        TResponse payload)
    {
        Type = type;
        Payload = payload;
    }
}