using System.Text.Json.Serialization;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Ok;

namespace Play.Contracts.Responses;

public record DeviceJoined : ResponseWrapper<PlayerPayload>
{
    public const string TypeValue = "device_joined";
    
    [JsonConstructor]
    public DeviceJoined(
        string type,
        PlayerPayload payload)
        : base(type, payload) { }
    
    public DeviceJoined(PlayerPayload payload)
        : this(TypeValue, payload) { }

    public DeviceJoined(long playerId)
        : this(PlayerPayload.From(playerId)) { }
}