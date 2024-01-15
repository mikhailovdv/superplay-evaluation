using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Bad;

namespace Play.Contracts.Responses;

public record DeviceRejected : ResponseWrapper<DeviceRejectPayload>
{
    public const string TypeValue = "device_rejected";

    public DeviceRejected(DeviceRejectPayload payload)
        : base(TypeValue, payload) { }
}