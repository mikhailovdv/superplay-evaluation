using System.Text.Json.Serialization;
using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;
using Play.Contracts.Requests.Payloads.Primitives;

namespace Play.Contracts.Requests;

public record UpdateResource : RequestWrapper<UpdateResourcePayload>
{
    public const string TypeValue = "update_resource";
    
    [JsonConstructor]
    public UpdateResource(
        string type,
        UpdateResourcePayload payload)
        : base(type, payload) { }
    
    public UpdateResource(
        ResourceType type,
        int value)
        : this(TypeValue, UpdateResourcePayload.From(type, value)) { }
}