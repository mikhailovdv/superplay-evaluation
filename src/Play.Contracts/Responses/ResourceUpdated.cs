using System.Text.Json.Serialization;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Ok;

namespace Play.Contracts.Responses;

public record ResourceUpdated : ResponseWrapper<ResourcePayload>
{
    public const string TypeValue = "resource_updated";

    [JsonConstructor]
    public ResourceUpdated(
        string type,
        ResourcePayload payload)
        : base(type, payload) { }
    
    public ResourceUpdated(ResourcePayload payload)
        : this(TypeValue, payload) { }
}