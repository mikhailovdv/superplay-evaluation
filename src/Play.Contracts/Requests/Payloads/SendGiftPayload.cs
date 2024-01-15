using Play.Contracts.Requests.Payloads.Primitives;

namespace Play.Contracts.Requests.Payloads;

public record SendGiftPayload : UpdateResourcePayload
{
    public long RecipientPlayerId { get; init; }

    public static SendGiftPayload From(
        long recipientPlayerId,
        ResourceType type,
        int value)
        => new () {
            RecipientPlayerId = recipientPlayerId,
            Type = type,
            Value = value
        };
}