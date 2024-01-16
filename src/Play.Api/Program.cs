using Play.Api.WebSocketApi;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<PlayWebSocketMiddleware>();
builder.Services.AddTransient<IPlayApi, PlayApi>();
builder.WebHost.UseUrls(
    builder.Configuration.GetSection("ApiSettings:Url").Value);

var app = builder.Build();
app.UseWebSockets(new WebSocketOptions {
    KeepAliveInterval = TimeSpan.FromSeconds(60)
});

app.MapGet("/", ()
    => "Play WebSocket APIs is running...");

app.Map("/play", httpContext
    => httpContext.RequestServices.GetRequiredService<PlayWebSocketMiddleware>()
        .InvokeAsync(httpContext));

await app.RunAsync();