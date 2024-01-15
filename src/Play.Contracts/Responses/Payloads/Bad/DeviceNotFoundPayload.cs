namespace Play.Contracts.Responses.Payloads.Bad;

public record DeviceNotFoundPayload : IResponsePayload
{
    public string NotFoundDeviceUDID { get; init; } = string.Empty;
    
    public static DeviceNotFoundPayload From(
        string notFoundDeviceUDID)
        => new () {
            NotFoundDeviceUDID = notFoundDeviceUDID
        };
}