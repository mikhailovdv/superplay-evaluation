using System.Text.Json.Serialization;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Bad;

namespace Play.Contracts.Responses;

public record DeviceRejected : ResponseWrapper<DeviceRejectPayload>
{
    public const string TypeValue = "device_rejected";

    [JsonConstructor]
    public DeviceRejected(
        string type,
        DeviceRejectPayload payload)
        : base(type, payload) { }
    
    public DeviceRejected(DeviceRejectPayload payload)
        : this(TypeValue, payload) { }

    public DeviceRejected(
        string alreadyConnectedDeviceUDID,
        long playerId)
        : this(DeviceRejectPayload.From(alreadyConnectedDeviceUDID, playerId)) { }
}