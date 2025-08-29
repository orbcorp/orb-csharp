using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.NewTaxJarConfigurationProperties;

[JsonConverter(typeof(TaxProviderConverter))]
public enum TaxProvider
{
    Taxjar,
}

sealed class TaxProviderConverter : JsonConverter<TaxProvider>
{
    public override TaxProvider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "taxjar" => TaxProvider.Taxjar,
            _ => (TaxProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TaxProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TaxProvider.Taxjar => "taxjar",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
