namespace Play.Contracts.Responses.Abstract;

public interface IResponseWrapper<out TResponse>
{
    string Type { get; }
    
    TResponse Payload { get; }
}