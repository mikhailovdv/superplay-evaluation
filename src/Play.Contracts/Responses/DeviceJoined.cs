using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Ok;

namespace Play.Contracts.Responses;

public record DeviceJoined : ResponseWrapper<PlayerPayload>
{
    public const string TypeValue = "device_joined";
    
    public DeviceJoined(PlayerPayload payload)
        : base(TypeValue, payload) { }

    public DeviceJoined(long playerId)
        : this(PlayerPayload.From(playerId)) { }
}