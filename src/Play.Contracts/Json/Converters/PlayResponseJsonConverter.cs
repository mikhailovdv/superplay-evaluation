using System.Collections.ObjectModel;
using System.Text.Json;
using Play.Contracts.Responses;
using Play.Contracts.Responses.Abstract;
using Play.Contracts.Responses.Payloads;

namespace Play.Contracts.Json.Converters;

internal class PlayResponseJsonConverter : BaseJsonConverter<IResponseWrapper<IResponsePayload>>
{
    protected override ReadOnlyDictionary<string, Func<JsonDocument, JsonSerializerOptions, IResponseWrapper<IResponsePayload>?>> Mappers
        => new(new Dictionary<string, Func<JsonDocument, JsonSerializerOptions, IResponseWrapper<IResponsePayload>?>>
        {
            { DeviceJoined.TypeValue,
                (document, options) => document.Deserialize<DeviceJoined>(options)
            },
            { DeviceNotFound.TypeValue,
                (document, options) => document.Deserialize<DeviceNotFound>(options)
            },
            { DeviceRejected.TypeValue,
                (document, options) => document.Deserialize<DeviceRejected>(options)
            },
            { ResourceSent.TypeValue,
                (document, options) => document.Deserialize<ResourceSent>(options)
            },
            { ResourceUpdated.TypeValue,
                (document, options) => document.Deserialize<ResourceUpdated>(options)
            },
        });
}