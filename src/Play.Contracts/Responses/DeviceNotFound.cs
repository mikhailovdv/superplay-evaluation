using System.Text.Json.Serialization;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Bad;

namespace Play.Contracts.Responses;

public record DeviceNotFound : ResponseWrapper<DeviceNotFoundPayload>
{
    public const string TypeValue = "device_not_found";

    [JsonConstructor]
    public DeviceNotFound(
        string type,
        DeviceNotFoundPayload payload)
        : base(type, payload) { }
    
    public DeviceNotFound(DeviceNotFoundPayload payload)
        : this(TypeValue, payload) { }

    public DeviceNotFound(
        string notFoundDeviceUDID)
        : this(DeviceNotFoundPayload.From(notFoundDeviceUDID)) { }
}