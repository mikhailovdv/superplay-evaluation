using System.Net.WebSockets;
using Play.Contracts.Extensions.Internal;
using Play.Contracts.Json;

namespace Play.Contracts.Extensions;

public static class PlayWebSocketExtensions
{
    private const int ContentBufferSize
        = 4096;
    private static readonly IPlayJson Json
        = new PlayJson()
            .WithPlayRequestJsonConverter()
            .WithPlayResponseJsonConverter();
    
    public static async Task SendAsync<T>(
        this WebSocket socket,
        T content,
        CancellationToken ct)
    {
        var message = new ResponseContentWrapper(
            Json.Serialize(content));
        await socket.SendAsync(
            buffer: message.BytesContent,
            messageType: message.MessageType,
            endOfMessage: message.EndOfMessage,
            cancellationToken: ct);
    }
    
    public static async Task InteractAsync<TRequest, TResponse>(
        this WebSocket socket,
        Func<TRequest?, Task<TResponse?>> messageHandler,
        CancellationToken ct)
    {
        try {
            var buffer = new byte[ContentBufferSize];
            while(socket.State is WebSocketState.Open)
            {
                var messageWrapper = await ReadAsync(socket, buffer, ct);
                if (messageWrapper.CloseConnection) {
                    await DisconnectAsync(socket, ct);
                }
                else {
                    var request = Json.Deserialize<TRequest>(
                        json: messageWrapper.JsonContent);
                    
                    var response = await messageHandler(request);
                    if (response is not null) {
                        await socket.SendAsync(response, ct);
                    }
                }
            }
        }
        catch (WebSocketException ex) when (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely) {
            await DisconnectAsync(socket, ct);
        }
    }
    
    
    private static async Task<RequestContentWrapper> ReadAsync(
        WebSocket socket,
        byte[] buffer,
        CancellationToken ct)
        => new (receiveResult: await socket.ReceiveAsync(
                buffer: new ArraySegment<byte>(buffer),
                cancellationToken: ct),
            content: buffer);

    private const string DefaultDisconnectReason = "Closed by the Play API";
    private static Task DisconnectAsync(
        WebSocket socket,
        CancellationToken ct,
        WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure,
        string disconnectReason = DefaultDisconnectReason)
        => socket.CloseAsync(
            closeStatus: closeStatus,
            statusDescription: disconnectReason,
            cancellationToken: ct);
}