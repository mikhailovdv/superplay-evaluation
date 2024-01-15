using Bogus;
using Play.Contracts.Json;
using Play.Contracts.Responses;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads;
using Play.Contracts.Responses.Payloads.Bad;
using Play.Contracts.Responses.Payloads.Ok;

namespace Play.Contracts.Tests.Json;

public class PlayResponseJsonConverterTests
{
    private readonly Faker _faker
        = new();
    private readonly IPlayJson _json
        = new PlayJson().WithPlayResponseJsonConverter();

    [Fact]
    public void DeviceJoined_Serialize_ReturnExpectedJson()
    {
        var deviceJoined = new DeviceJoined(
            playerId: _faker.Random.Long());
        var expectedJson = Json(deviceJoined);
        
        var json = _json.Serialize(deviceJoined);
        
        Assert.Equal(json, expectedJson);
    }
    
    [Fact]
    public void DeviceJoined_Deserialize_ReturnExpectedContract()
    {
        var expectedDeviceJoined = new DeviceJoined(
            playerId: _faker.Random.Long());
        var json = Json(expectedDeviceJoined);
        
        var deviceJoined = _json.Deserialize<IResponseWrapper<IResponsePayload>>(json);
        
        Assert.IsType<DeviceJoined>(deviceJoined);
        Assert.IsType<PlayerPayload>(deviceJoined.Payload);
        Assert.Equal(DeviceJoined.TypeValue, deviceJoined.Type);
        Assert.Equal(expectedDeviceJoined.Payload, deviceJoined.Payload);
    }
    
    [Fact]
    public void DeviceNotFound_Serialize_ReturnExpectedJson()
    {
        var deviceNotFound = new DeviceNotFound(
            notFoundDeviceUDID: _faker.System.AndroidId());
        var expectedJson = Json(deviceNotFound);
        
        var json = _json.Serialize(deviceNotFound);
        
        Assert.Equal(json, expectedJson, ignoreCase: true);
    }
    
    [Fact]
    public void DeviceNotFound_Deserialize_ReturnExpectedContract()
    {
        var expectedDeviceNotFound = new DeviceNotFound(
            notFoundDeviceUDID: _faker.System.AndroidId());
        var json = Json(expectedDeviceNotFound);
        
        var deviceNotFound = _json.Deserialize<IResponseWrapper<IResponsePayload>>(json);
        
        Assert.IsType<DeviceNotFound>(deviceNotFound);
        Assert.IsType<DeviceNotFoundPayload>(deviceNotFound.Payload);
        Assert.Equal(DeviceNotFound.TypeValue, deviceNotFound.Type);
        Assert.Equal(expectedDeviceNotFound.Payload, deviceNotFound.Payload);
    }
    
    [Fact]
    public void DeviceRejected_Serialize_ReturnExpectedJson()
    {
        var deviceRejected = new DeviceRejected(
            alreadyConnectedDeviceUDID: _faker.System.AndroidId(),
            playerId: _faker.Random.Long());
        var expectedJson = Json(deviceRejected);
        
        var json = _json.Serialize(deviceRejected);
        
        Assert.Equal(json, expectedJson, ignoreCase: true);
    }
    
    [Fact]
    public void DeviceRejected_Deserialize_ReturnExpectedContract()
    {
        var expectedDeviceRejected = new DeviceRejected(
            alreadyConnectedDeviceUDID: _faker.System.AndroidId(),
            playerId: _faker.Random.Long());
        var json = Json(expectedDeviceRejected);
        
        var deviceRejected = _json.Deserialize<IResponseWrapper<IResponsePayload>>(json);
        
        Assert.IsType<DeviceRejected>(deviceRejected);
        Assert.IsType<DeviceRejectPayload>(deviceRejected.Payload);
        Assert.Equal(DeviceRejected.TypeValue, deviceRejected.Type);
        Assert.Equal(expectedDeviceRejected.Payload, deviceRejected.Payload);
    }
    
    private static string Json(DeviceJoined deviceJoined)
        => $"{{\"type\":\"{DeviceJoined.TypeValue}\",\"payload\":{{\"playerId\":{deviceJoined.Payload.PlayerId}}}}}";

    private static string Json(DeviceNotFound deviceNotFound)
        => $"{{\"type\":\"{DeviceNotFound.TypeValue}\",\"payload\":{{\"notFoundDeviceUDID\":\"{deviceNotFound.Payload.NotFoundDeviceUDID}\"}}}}";

    private static string Json(DeviceRejected deviceRejected)
        => $"{{\"type\":\"{DeviceRejected.TypeValue}\",\"payload\":{{\"AlreadyConnectedDeviceUDID\":\"{deviceRejected.Payload.AlreadyConnectedDeviceUDID}\",\"playerId\":{deviceRejected.Payload.PlayerId}}}}}";

}