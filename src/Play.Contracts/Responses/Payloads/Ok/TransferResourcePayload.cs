namespace Play.Contracts.Responses.Payloads.Ok;

public record TransferResourcePayload : ResourcePayload
{
    public long SenderPlayerId { get; init; }
    
    public static TransferResourcePayload From(
        long senderPlayerId)
        => new () {
            SenderPlayerId = senderPlayerId
        };
}