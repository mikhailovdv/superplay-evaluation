using Play.Contracts.Requests.Payloads;

namespace Play.Contracts.Requests.Abstract;

public abstract record RequestWrapper<TRequest>(
    string Type,
    TRequest Payload) : IRequestWrapper<TRequest>
    where TRequest : class, IRequestPayload;