using System.Text.Json;

namespace Play.Contracts.Json.Converters;

internal static class Extensions
{
    internal const string TypePropertyName = "type";
    
    internal static string? ExtractContractTypeValueOrDefault(this JsonDocument document)
        => document
            .RootElement
            .TryGetProperty(TypePropertyName, out var jsonElement)
                ? jsonElement.Deserialize<string?>()
                : null;
}