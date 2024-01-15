using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Ok;

namespace Play.Contracts.Responses;

public record ResourceUpdated : ResponseWrapper<ResourcePayload>
{
    public const string TypeValue = "resource_updated";

    public ResourceUpdated(ResourcePayload payload)
        : base(TypeValue, payload) { }
}