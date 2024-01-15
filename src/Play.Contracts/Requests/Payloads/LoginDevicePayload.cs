using System.Text.Json.Serialization;

namespace Play.Contracts.Requests.Payloads;

public record LoginDevicePayload : IRequestPayload
{
    public string CurrentDeviceUDID { get; }

    [JsonConstructor]
    public LoginDevicePayload(
        string currentDeviceUDID)
    {
        CurrentDeviceUDID = currentDeviceUDID;
    }
}