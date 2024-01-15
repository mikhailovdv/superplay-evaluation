using Bogus;
using Play.Contracts.Json;
using Play.Contracts.Requests;
using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;
using Play.Contracts.Requests.Payloads.Primitives;

namespace Play.Contracts.Tests.Json;

public class PlayRequestJsonConverterTests
{
    private readonly Faker _faker
        = new();
    private readonly IPlayJson _json
        = new PlayJson().WithPlayRequestJsonConverter();

    [Fact]
    public void LoginDevice_Serialize_ReturnExpectedJson()
    {
        var loginDevice = new LoginDevice(
            _faker.Random.String2(
                _faker.Random.Byte(8, 24)));
        var expectedJson = Json(loginDevice);
        
        var json = _json.Serialize(loginDevice);
        
        Assert.Equal(json, expectedJson);
    }
    
    [Fact]
    public void LoginDevice_Deserialize_ReturnExpectedContract()
    {
        var expectedLoginDevice = new LoginDevice(
            _faker.Random.String2(
                _faker.Random.Byte(8, 24)));
        var json = Json(expectedLoginDevice);
        
        var loginDevice = _json.Deserialize<IRequestWrapper<IRequestPayload>>(json);
        
        Assert.IsType<LoginDevice>(loginDevice);
        Assert.IsType<LoginDevicePayload>(loginDevice.Payload);
        Assert.Equal(LoginDevice.TypeValue, loginDevice.Type);
        Assert.Equal(expectedLoginDevice.Payload, loginDevice.Payload);
    }
    
    [Fact]
    public void SendGift_Serialize_ReturnExpectedJson()
    {
        var sendGift = new SendGift(
            recipientPlayerId: _faker.Random.Long(),
            type: _faker.PickRandom<ResourceType>(),
            value: _faker.Random.Int());
        var expectedJson = Json(sendGift);
        
        var json = _json.Serialize(sendGift);
        
        Assert.Equal(json, expectedJson, ignoreCase: true);
    }
    
    [Fact]
    public void SendGift_Deserialize_ReturnExpectedContract()
    {
        var expectedSendGift = new SendGift(
            recipientPlayerId: _faker.Random.Long(),
            type: _faker.PickRandom<ResourceType>(),
            value: _faker.Random.Int());
        var json = Json(expectedSendGift);
        
        var sendGift = _json.Deserialize<IRequestWrapper<IRequestPayload>>(json);
        
        Assert.IsType<SendGift>(sendGift);
        Assert.IsType<SendGiftPayload>(sendGift.Payload);
        Assert.Equal(SendGift.TypeValue, sendGift.Type);
        Assert.Equal(expectedSendGift.Payload, sendGift.Payload);
    }
    
    [Fact]
    public void UpdateResource_Serialize_ReturnExpectedJson()
    {
        var updateResource = new UpdateResource(
            type: _faker.PickRandom<ResourceType>(),
            value: _faker.Random.Int());
        var expectedJson = Json(updateResource);
        
        var json = _json.Serialize(updateResource);
        
        Assert.Equal(json, expectedJson, ignoreCase: true);
    }
    
    [Fact]
    public void UpdateResource_Deserialize_ReturnExpectedContract()
    {
        var expectedUpdateResource = new UpdateResource(
            type: _faker.PickRandom<ResourceType>(),
            value: _faker.Random.Int());
        var json = Json(expectedUpdateResource);
        
        var updateResource = _json.Deserialize<IRequestWrapper<IRequestPayload>>(json);
        
        Assert.IsType<UpdateResource>(updateResource);
        Assert.IsType<UpdateResourcePayload>(updateResource.Payload);
        Assert.Equal(UpdateResource.TypeValue, updateResource.Type);
        Assert.Equal(expectedUpdateResource.Payload, updateResource.Payload);
    }
    
    private static string Json(LoginDevice loginDevice)
        => $"{{\"type\":\"{LoginDevice.TypeValue}\",\"payload\":{{\"currentDeviceUDID\":\"{loginDevice.Payload.CurrentDeviceUDID}\"}}}}";

    private static string Json(SendGift sendGift)
        => $"{{\"type\":\"{SendGift.TypeValue}\",\"payload\":{{\"recipientPlayerId\":{sendGift.Payload.RecipientPlayerId},\"type\":\"{sendGift.Payload.Type:G}\",\"value\":{sendGift.Payload.Value}}}}}";

    private static string Json(UpdateResource updateResource)
        => $"{{\"type\":\"{UpdateResource.TypeValue}\",\"payload\":{{\"type\":\"{updateResource.Payload.Type:G}\",\"value\":{updateResource.Payload.Value}}}}}";

}