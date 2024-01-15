using System.Text.Json.Serialization;
using Play.Contracts.Requests.Payloads.Primitives;

namespace Play.Contracts.Requests.Payloads;

public record UpdateResourcePayload : IRequestPayload
{
    public ResourceType Type { get; }
    
    public int Value { get; }

    [JsonConstructor]
    public UpdateResourcePayload(
        ResourceType type,
        int value)
    {
        Type = type;
        Value = value;
    }
}