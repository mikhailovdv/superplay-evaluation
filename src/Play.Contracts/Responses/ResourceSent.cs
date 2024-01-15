using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Ok;

namespace Play.Contracts.Responses;

public record ResourceSent : ResponseWrapper<TransferResourcePayload>
{
    public const string TypeValue = "resource_sent";

    public ResourceSent(TransferResourcePayload payload)
        : base(TypeValue, payload) { }
}