using System.Text.Json.Serialization;
using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;

namespace Play.Contracts.Requests;

public record LoginDevice : RequestWrapper<LoginDevicePayload>
{
    public const string TypeValue = "login_device";
    
    [JsonConstructor]
    public LoginDevice(
        string type,
        LoginDevicePayload payload)
        : base(type, payload) { }
    
    public LoginDevice(
        string currentDeviceUDID)
        : this(TypeValue, LoginDevicePayload.From(currentDeviceUDID)) { }
}