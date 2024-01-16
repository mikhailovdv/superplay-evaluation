using Play.Api.WebSocketApi.Abstract;
using Play.Contracts.Extensions;
using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads;

namespace Play.Api.WebSocketApi;

public class PlayWebSocketMiddleware : BaseWebSocketApiHandler
{
    private readonly IPlayApi _playApi;

    public PlayWebSocketMiddleware(
        IPlayApi playApi)
    {
        _playApi = playApi;
    }
    
    public override async Task InvokeAsync(
        HttpContext context)
    {
        if (!context.WebSockets.IsWebSocketRequest) {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }
        
        var webSocket = await context.WebSockets.AcceptWebSocketAsync();

        await webSocket
            .InteractAsync<IRequestWrapper<IRequestPayload>, IResponseWrapper<IResponsePayload>>(
                _playApi.HandleAsync,
                context.RequestAborted);
    }
}