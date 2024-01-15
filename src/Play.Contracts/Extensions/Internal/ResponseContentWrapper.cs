using System.Net.WebSockets;
using System.Text;

namespace Play.Contracts.Extensions.Internal;

public class ResponseContentWrapper
{
    public WebSocketMessageType MessageType { get; }
    
    public ArraySegment<byte> BytesContent { get; }

    public bool EndOfMessage
        => true;

    public ResponseContentWrapper(
        string jsonContent)
    {
        MessageType = WebSocketMessageType.Text;
        BytesContent = new ArraySegment<byte>(
            array: GetBytesContent(jsonContent));
    }
    
    
    private static byte[] GetBytesContent(
        string json)
        => Encoding.UTF8.GetBytes(json);
}