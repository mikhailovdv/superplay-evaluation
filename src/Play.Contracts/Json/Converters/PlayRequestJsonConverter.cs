using System.Collections.ObjectModel;
using System.Text.Json;
using Play.Contracts.Requests;
using Play.Contracts.Requests.Abstract;
using Play.Contracts.Requests.Payloads;

namespace Play.Contracts.Json.Converters;

internal class PlayRequestJsonConverter : BaseJsonConverter<IRequestWrapper<IRequestPayload>>
{
    protected override ReadOnlyDictionary<string, Func<JsonDocument, JsonSerializerOptions, IRequestWrapper<IRequestPayload>?>> Mappers
        => new(new Dictionary<string, Func<JsonDocument, JsonSerializerOptions, IRequestWrapper<IRequestPayload>?>>
        {
            { LoginDevice.TypeValue,
              (document, options) => document.Deserialize<LoginDevice>(options)
            },
            { SendGift.TypeValue,
                (document, options) => document.Deserialize<SendGift>(options)
            },
            { UpdateResource.TypeValue,
                (document, options) => document.Deserialize<UpdateResource>(options)
            },
        });
}