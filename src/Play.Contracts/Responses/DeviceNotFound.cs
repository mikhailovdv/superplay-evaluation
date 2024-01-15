using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Bad;

namespace Play.Contracts.Responses;

public record DeviceNotFound : ResponseWrapper<DeviceNotFoundPayload>
{
    public const string TypeValue = "device_not_found";

    public DeviceNotFound(DeviceNotFoundPayload payload)
        : base(TypeValue, payload) { }
}