using Play.Contracts.Requests.Payloads;

namespace Play.Contracts.Requests.Abstract;

public interface IRequestWrapper<out TRequest>
    where TRequest : class, IRequestPayload
{
    string Type { get; }
    
    TRequest Payload { get; }
}