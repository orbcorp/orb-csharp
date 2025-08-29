using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanGroupedWithProratedMinimumPriceProperties;

[JsonConverter(typeof(ModelTypeConverter))]
public enum ModelType
{
    GroupedWithProratedMinimum,
}

sealed class ModelTypeConverter : JsonConverter<ModelType>
{
    public override ModelType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "grouped_with_prorated_minimum" => ModelType.GroupedWithProratedMinimum,
            _ => (ModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelType.GroupedWithProratedMinimum => "grouped_with_prorated_minimum",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
