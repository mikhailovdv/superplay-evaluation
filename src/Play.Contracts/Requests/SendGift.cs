using System.Text.Json.Serialization;
using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;
using Play.Contracts.Requests.Payloads.Primitives;

namespace Play.Contracts.Requests;

public record SendGift : RequestWrapper<SendGiftPayload>
{
    public const string TypeValue = "send_gift";
    
    [JsonConstructor]
    public SendGift(
        string type,
        SendGiftPayload payload)
        : base(type, payload) { }
    
    public SendGift(
        long recipientPlayerId,
        ResourceType type,
        int value)
        : this(TypeValue, SendGiftPayload.From(recipientPlayerId, type, value)) { }
}