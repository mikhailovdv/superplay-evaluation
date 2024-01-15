namespace Play.Contracts.Requests.Payloads;

public record LoginDevicePayload : IRequestPayload
{
    public string CurrentDeviceUDID { get; init; }

    public static LoginDevicePayload From(
        string currentDeviceUDID)
        => new () {
            CurrentDeviceUDID = currentDeviceUDID
        };
}