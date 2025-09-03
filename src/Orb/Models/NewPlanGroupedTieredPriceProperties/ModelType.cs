using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanGroupedTieredPriceProperties;

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(ModelTypeConverter))]
public enum ModelType
{
    GroupedTiered,
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
            "grouped_tiered" => ModelType.GroupedTiered,
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
                ModelType.GroupedTiered => "grouped_tiered",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
