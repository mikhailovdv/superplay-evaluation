using Play.Contracts.Requests.Payloads.Primitives;

namespace Play.Contracts.Requests.Payloads;

public record UpdateResourcePayload : IRequestPayload
{
    public ResourceType Type { get; init; }
    
    public int Value { get; init; }

    public static UpdateResourcePayload From(
        ResourceType type,
        int value)
        => new () {
            Type = type,
            Value = value
        };
}