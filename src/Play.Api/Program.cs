using Play.Api.WebSocketApi;
using Play.Core;
using Play.Persistence;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddTransient<IPlayApi, PlayApi>();
builder.Services.AddTransient<PlayWebSocketMiddleware>();
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