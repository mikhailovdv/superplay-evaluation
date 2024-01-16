using System.Net.WebSockets;
using System.Text;
using Play.Contracts.Extensions;
using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;
using Serilog;

namespace Play.Client;

public class PlayApiClient
{
    private readonly ClientWebSocket _clientWebSocket
        = new();
    private readonly CancellationTokenSource _cancellationTokenSource
        = new();
    
    private readonly Uri _uri;

    public PlayApiClient(string uri)
        => _uri = new Uri(uri);

    public Task ConnectAsync()
        => _clientWebSocket.ConnectAsync(_uri, _cancellationTokenSource.Token);
    
    public Task DisconnectAsync()
        => _clientWebSocket.CloseAsync(
            WebSocketCloseStatus.NormalClosure,
            "Closed",
            _cancellationTokenSource.Token);

    public Task SendAsync<TMessage>(
        TMessage request)
        where TMessage : IRequestWrapper<IRequestPayload>
        => _clientWebSocket.SendAsync(request, _cancellationTokenSource.Token);
    
    public async Task ReceiveAsync()
    {
        Log.Information("Receiving ...");
        
        var buffer = new byte[4096];
        await _clientWebSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer),
            _cancellationTokenSource.Token);
        
        Log.Information("Received");
        
        var json = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        
        Log.Information("Got {@Json}", json);
    }
}