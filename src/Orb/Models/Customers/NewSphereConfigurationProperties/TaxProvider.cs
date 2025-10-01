using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

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
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
