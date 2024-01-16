using Play.Core.Domain.Abstract;

namespace Play.Core.Domain;

public record Player(long PlayerId, Dictionary<ResourceType, int> Resources)
    : IEntity<long>
{
    public long Id => PlayerId;
}

public enum ResourceType
{
    Coin,
    Roll
}