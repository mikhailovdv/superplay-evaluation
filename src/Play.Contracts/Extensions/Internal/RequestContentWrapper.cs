using System.Net.WebSockets;
using System.Text;

namespace Play.Contracts.Extensions.Internal;

public record RequestContentWrapper
{
    public bool CloseConnection { get;}
    
    public string JsonContent { get; }
    
    
    public RequestContentWrapper(
        WebSocketReceiveResult receiveResult,
        byte[] content)
    {
        switch (receiveResult) {
            case { MessageType: WebSocketMessageType.Text }:
                CloseConnection = false;
                JsonContent = GetStringContent(receiveResult, content);
                break;
            case { MessageType: WebSocketMessageType.Close }:
                CloseConnection = true;
                JsonContent = string.Empty;
                break;
            default:
                CloseConnection = false;
                JsonContent = string.Empty;
                break;
        }
    }
    
    private static string GetStringContent(
        WebSocketReceiveResult receiveResult,
        byte[] bytesContent)
        => Encoding.UTF8.GetString(bytesContent, 0, receiveResult.Count);
}