using Play.Contracts.Responses.Payloads.Primitives;

namespace Play.Contracts.Responses.Payloads.Ok;

public record ResourcePayload : IResponsePayload
{
    public ResourceType Type { get; init; }
    
    public int Value { get; init; }
    
    public static ResourcePayload From(
        ResourceType type,
        int value)
        => new () {
            Type = type,
            Value = value
        };
}