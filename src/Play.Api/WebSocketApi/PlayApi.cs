using Play.Contracts.Requests;
using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;
using Play.Contracts.Responses;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads;
using Play.Contracts.Responses.Payloads.Primitives;

namespace Play.Api.WebSocketApi;

public class PlayApi : IPlayApi
{
    public async Task<IResponseWrapper<IResponsePayload>?> HandleAsync(
        IRequestWrapper<IRequestPayload>? request)
        => request switch
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

    private async Task<IResponseWrapper<IResponsePayload>?> HandleAsync(
        LoginDevice request)
    {
        Console.WriteLine("Handling request {0}", request);
        var response =  new DeviceJoined(1);
        Console.WriteLine("Answering with response {0}", response);
        return response;
    }
    
    private async Task<IResponseWrapper<IResponsePayload>?> HandleAsync(
        SendGift request)
    {
        Console.WriteLine("Handling request {0}", request);
        var response =  new ResourceSent(
            senderPlayerId: default,
            type: (ResourceType) request.Payload.Type,
            value: request.Payload.Value);
        Console.WriteLine("Answering with response {0}", response);
        return response;
    }
    
    private async Task<IResponseWrapper<IResponsePayload>?> HandleAsync(
        UpdateResource request)
    {
        Console.WriteLine("Handling request {0}", request);
        var response =  new ResourceUpdated(
            (ResourceType)request.Payload.Type,
            request.Payload.Value);
        Console.WriteLine("Answering with response {0}", response);
        return response;
    }
}