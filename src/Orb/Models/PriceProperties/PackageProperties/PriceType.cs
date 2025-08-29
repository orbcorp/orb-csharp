using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.PriceProperties.PackageProperties;

[JsonConverter(typeof(PriceTypeConverter))]
public enum PriceType
{
    UsagePrice,
    FixedPrice,
}

sealed class PriceTypeConverter : JsonConverter<PriceType>
{
    public override PriceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage_price" => PriceType.UsagePrice,
            "fixed_price" => PriceType.FixedPrice,
            _ => (PriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceType.UsagePrice => "usage_price",
                PriceType.FixedPrice => "fixed_price",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
