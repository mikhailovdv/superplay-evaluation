using Play.Client;
using Play.Contracts.Requests;
using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;
using Play.Contracts.Requests.Payloads.Primitives;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

const string apiHost = "wss://localhost:7001/play";

var playApiClient = new PlayApiClient(apiHost);

await playApiClient.ConnectAsync();

await Task.Factory.StartNew(async () =>
{
    await playApiClient.ReceiveAsync();
}, TaskCreationOptions.LongRunning);

const string existingDeviceUDID = "device-1";
var loginDevice = new LoginDevice(
    currentDeviceUDID: existingDeviceUDID);

await playApiClient.SendAsync(loginDevice);

await Task.Delay(5000);

while (!Console.KeyAvailable) {
    var sendGift = new SendGift(
        1,
        ResourceType.Coin,
        100);
    await playApiClient.SendAsync(sendGift);
    Log.Information("Sent {@SendGift} ...", sendGift);
    await Task.Delay(5000); 
}

Console.WriteLine("Press any key to exit");

Console.ReadKey();

Console.WriteLine("Disconnecting from {0} ...", apiHost);
await playApiClient.DisconnectAsync();
Console.WriteLine("Disconnected");

Console.WriteLine("Gone");