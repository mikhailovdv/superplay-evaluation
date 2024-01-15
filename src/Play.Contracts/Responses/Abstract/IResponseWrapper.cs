namespace Play.Contracts.Responses.Abstract;

public interface IResponseWrapper<TResponse>
{
    string Type { get; init; }
    
    TResponse Payload { get; init; }
}