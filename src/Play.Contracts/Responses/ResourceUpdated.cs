using System.Text.Json.Serialization;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads.Ok;
using Play.Contracts.Responses.Payloads.Primitives;

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
    
    public ResourceUpdated(
        ResourceType type,
        int value)
        : this(TypeValue, ResourcePayload.From(type, value)) { }
}