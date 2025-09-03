using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanBulkPriceProperties;

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(ModelTypeConverter))]
public enum ModelType
{
    Bulk,
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
            "bulk" => ModelType.Bulk,
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
                ModelType.Bulk => "bulk",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
