namespace Play.Core.Error;

public record PlayerAlreadyConnected(
    string DeviceUDID,
    long PlayerId)
    : IPlayServiceError;

public record DeviceNotFound(
    string DeviceUDID)
    : IPlayServiceError;