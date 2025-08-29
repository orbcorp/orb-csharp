using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.CustomerProperties.AccountingSyncConfigurationProperties.AccountingProviderProperties;

[JsonConverter(typeof(ProviderTypeConverter))]
public enum ProviderType
{
    Quickbooks,
    Netsuite,
}

sealed class ProviderTypeConverter : JsonConverter<ProviderType>
{
    public override ProviderType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quickbooks" => ProviderType.Quickbooks,
            "netsuite" => ProviderType.Netsuite,
            _ => (ProviderType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProviderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProviderType.Quickbooks => "quickbooks",
                ProviderType.Netsuite => "netsuite",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
