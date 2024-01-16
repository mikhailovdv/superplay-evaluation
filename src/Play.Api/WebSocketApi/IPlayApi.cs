using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads;

namespace Play.Api.WebSocketApi;

public interface IPlayApi
{
    Task<IResponseWrapper<IResponsePayload>?> HandleAsync(
        IRequestWrapper<IRequestPayload>? request);
}