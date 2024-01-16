namespace Play.Api.WebSocketApi.Abstract;

public abstract class BaseWebSocketApiHandler
{
    public abstract Task InvokeAsync(HttpContext context);
}