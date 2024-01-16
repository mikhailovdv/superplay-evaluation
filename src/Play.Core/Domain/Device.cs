using Play.Core.Domain.Abstract;

namespace Play.Core.Domain;

public record Device(
    string DeviceUDID,
    long PlayerId)
    : IEntity<string>
{
    public string Id => DeviceUDID;
}