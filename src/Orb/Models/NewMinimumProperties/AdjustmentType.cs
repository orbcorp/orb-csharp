using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewMinimumProperties;

[JsonConverter(typeof(AdjustmentTypeConverter))]
public enum AdjustmentType
{
    Minimum,
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
            "minimum" => AdjustmentType.Minimum,
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
                AdjustmentType.Minimum => "minimum",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
