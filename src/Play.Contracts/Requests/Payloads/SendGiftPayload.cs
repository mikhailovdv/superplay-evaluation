using System.Text.Json.Serialization;
using Play.Contracts.Requests.Payloads.Primitives;

namespace Play.Contracts.Requests.Payloads;

public record SendGiftPayload : UpdateResourcePayload
{
    public long RecipientPlayerId { get; }

    [JsonConstructor]
    public SendGiftPayload(
        long recipientPlayerId,
        ResourceType type,
        int value)
        : base(type, value)
    {
        RecipientPlayerId = recipientPlayerId;
    }
}