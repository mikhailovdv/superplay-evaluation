using Play.Core.Domain;
using Play.Core.Error;

namespace Play.Core;

public class PlayService : IPlayService
{
    private readonly IRepository<Device, string>  _devicesRepo;
    private readonly IRepository<Connection, string>  _connectionsRepo;

    public PlayService(
        IRepository<Device, string> devicesRepo,
        IRepository<Connection, string> connectionsRepo)
    {
        _devicesRepo = devicesRepo;
        _connectionsRepo = connectionsRepo;
    }

    public PlayServiceResult<Device, string, IPlayServiceError> LoginDevice(
        string deviceUDID)
    {
        var device = _devicesRepo.Find(deviceUDID);
        if (device is null)
        {
            return new(
                Content: null,
                Error: new DeviceNotFound(deviceUDID));
        }
        
        var connection = _connectionsRepo.Find(deviceUDID);
        if (connection is { IsOnline: true })
        {
            return new(
                Content: null,
                Error: new PlayerAlreadyConnected(
                    deviceUDID,
                    device.PlayerId));
        }
        connection = new(deviceUDID, true, DateTime.UtcNow);
        if (connection is { IsOnline: false })
        {
            _connectionsRepo.Update(connection);
        }
        else
        {
            _connectionsRepo.Add(connection);
        }
        return new(
            Content: device,
            Error: null);
    }
}