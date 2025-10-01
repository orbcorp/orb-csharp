using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.PriceProperties.UnitProperties;

[JsonConverter(typeof(PriceTypeConverter))]
public enum PriceType
{
    UsagePrice,
    FixedPrice,
    CompositePrice,
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
            "composite_price" => PriceType.CompositePrice,
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
                PriceType.CompositePrice => "composite_price",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
