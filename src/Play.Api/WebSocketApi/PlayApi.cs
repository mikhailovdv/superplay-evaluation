using Play.Contracts.Requests;
using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;
using Play.Contracts.Responses;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads;
using Play.Contracts.Responses.Payloads.Primitives;
using Play.Core;
using Serilog;

namespace Play.Api.WebSocketApi;

public class PlayApi : IPlayApi
{
    private readonly IPlayService _playService;

    public PlayApi(IPlayService playService)
    {
        _playService = playService;
    }

    public async Task<IResponseWrapper<IResponsePayload>?> HandleAsync(
        IRequestWrapper<IRequestPayload>? request)
    {
        Log.Information("-> {@Request}", request);
        
        var response = request switch
        {
            LoginDevice loginDevice
                => await HandleAsync(loginDevice),
            SendGift sendGift
                => await HandleAsync(sendGift),
            UpdateResource updateResource
                => await HandleAsync(updateResource),
            _
                => throw new NotImplementedException()
        };
        
        Log.Information("<- {@Response}", response);
        
        return response;
    }
       

    private async Task<IResponseWrapper<IResponsePayload>?> HandleAsync(
        LoginDevice request)
    {
        var deviceResponse = _playService.LoginDevice(
            request.Payload.CurrentDeviceUDID);
        return deviceResponse switch {
            { Error: { } error } => error switch {
                Play.Core.Error.DeviceNotFound deviceNotFound
                    => new DeviceNotFound(
                        deviceNotFound.DeviceUDID),
                Core.Error.PlayerAlreadyConnected playerAlreadyConnected
                    => new DeviceRejected(
                        playerAlreadyConnected.DeviceUDID,
                        playerAlreadyConnected.PlayerId),
                _
                    => throw new NotImplementedException()
            },
            { Content: { } device }
                => new DeviceJoined(device.PlayerId)
        };
    }
    
    private async Task<IResponseWrapper<IResponsePayload>?> HandleAsync(
        SendGift request)
    {
        var response =  new ResourceSent(
            senderPlayerId: default,
            type: (ResourceType) request.Payload.Type,
            value: request.Payload.Value);
        return response;
    }
    
    private async Task<IResponseWrapper<IResponsePayload>?> HandleAsync(
        UpdateResource request)
    {
        var response =  new ResourceUpdated(
            (ResourceType)request.Payload.Type,
            request.Payload.Value);
        return response;
    }
}