using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.NewSphereConfigurationProperties;

[JsonConverter(typeof(TaxProviderConverter))]
public enum TaxProvider
{
    Sphere,
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
            "sphere" => TaxProvider.Sphere,
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
                TaxProvider.Sphere => "sphere",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
