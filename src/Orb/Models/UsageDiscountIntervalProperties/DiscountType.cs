using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.UsageDiscountIntervalProperties;

[JsonConverter(typeof(DiscountTypeConverter))]
public enum DiscountType
{
    Usage,
}

sealed class DiscountTypeConverter : JsonConverter<DiscountType>
{
    public override DiscountType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => DiscountType.Usage,
            _ => (DiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountType.Usage => "usage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
