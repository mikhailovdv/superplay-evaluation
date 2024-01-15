namespace Play.Contracts.Responses.Payloads.Ok;

public record PlayerPayload : IResponsePayload
{
    public long PlayerId { get; init; }
    
    public static PlayerPayload From(long playerId)
        => new() {
            PlayerId = playerId
        };
}