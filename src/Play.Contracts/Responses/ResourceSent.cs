using System.Text.Json.Serialization;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Ok;
using Play.Contracts.Responses.Payloads.Primitives;

namespace Play.Contracts.Responses;

public record ResourceSent : ResponseWrapper<TransferResourcePayload>
{
    public const string TypeValue = "resource_sent";

    [JsonConstructor]
    public ResourceSent(
        string type,
        TransferResourcePayload payload)
        : base(type, payload) { }
    
    public ResourceSent(TransferResourcePayload payload)
        : this(TypeValue, payload) { }
    
    public ResourceSent(
        long senderPlayerId,
        ResourceType type,
        int value)
        : this(TypeValue, TransferResourcePayload.From(senderPlayerId, type, value)) { }
}