using Play.Contracts.Responses.Payloads.Primitives;

namespace Play.Contracts.Responses.Payloads.Ok;

public record TransferResourcePayload : ResourcePayload
{
    public long SenderPlayerId { get; init; }
    
    public static TransferResourcePayload From(
        long senderPlayerId,
        ResourceType type,
        int value)
        => new () {
            SenderPlayerId = senderPlayerId,
            Type = type,
            Value = value
        };
}