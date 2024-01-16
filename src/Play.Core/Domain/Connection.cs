using Play.Core.Domain.Abstract;

namespace Play.Core.Domain;

public record Connection(
    string ConnectionId,
    string DeviceUDID,
    bool IsOnline,
    DateTime ConnectedAtUtc): IEntity<string>
{
    public string Id => ConnectionId;
}