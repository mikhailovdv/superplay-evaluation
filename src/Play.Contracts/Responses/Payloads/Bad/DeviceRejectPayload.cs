﻿namespace Play.Contracts.Responses.Payloads.Bad;

public record DeviceRejectPayload : IResponsePayload
{
    public string AlreadyConnectedDeviceUDID { get; init; } = string.Empty;
    
    public long PlayerId { get; init; }
    
    public static DeviceRejectPayload From(
        string alreadyConnectedDeviceUDID,
        long playerId)
        => new () {
            AlreadyConnectedDeviceUDID = alreadyConnectedDeviceUDID,
            PlayerId = playerId
        };
}