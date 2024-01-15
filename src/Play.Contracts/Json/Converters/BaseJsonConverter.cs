using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Play.Contracts.Json.Converters;

internal abstract class BaseJsonConverter<T> : JsonConverter<T>
{
    protected abstract ReadOnlyDictionary<string, Func<JsonDocument, JsonSerializerOptions, T?>> Mappers { get; }

    public override T? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType is not JsonTokenType.StartObject) {
            throw new JsonException($"Expected {nameof(JsonTokenType.StartObject)} but got {reader.TokenType}");
        }
        var document = JsonDocument.ParseValue(ref reader);
        var contractTypeValue = document.ExtractContractTypeValueOrDefault();
        if (contractTypeValue is null) {
            throw new JsonException($"There is no {Extensions.TypePropertyName} property in the JSON document");
        }
        var isConverterExist = Mappers.ContainsKey(contractTypeValue);
        if (!isConverterExist) {
            throw new JsonException($"There is no converter for {contractTypeValue} contract type");
        }
        return Mappers[contractTypeValue](document, options);
    }

    public override void Write(
        Utf8JsonWriter writer,
        T value,
        JsonSerializerOptions options)
    {
        if (value is null) {
            writer.WriteNullValue();
        }
        else {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}