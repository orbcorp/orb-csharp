using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewMaximumProperties;

[JsonConverter(typeof(AdjustmentTypeConverter))]
public enum AdjustmentType
{
    Maximum,
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
            "maximum" => AdjustmentType.Maximum,
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
                AdjustmentType.Maximum => "maximum",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
