using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewUsageDiscountProperties;

[JsonConverter(typeof(AdjustmentTypeConverter))]
public enum AdjustmentType
{
    UsageDiscount,
}

sealed class AdjustmentTypeConverter : JsonConverter<AdjustmentType>
{
    public override AdjustmentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage_discount" => AdjustmentType.UsageDiscount,
            _ => (AdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AdjustmentType.UsageDiscount => "usage_discount",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
