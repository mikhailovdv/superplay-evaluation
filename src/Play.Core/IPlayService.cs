using Play.Core.Domain;
using Play.Core.Error;

namespace Play.Core;

public interface IPlayService
{
    PlayServiceResult<Device, string, IPlayServiceError> LoginDevice(
        string deviceUDID);
}