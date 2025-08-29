using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanScalableMatrixWithTieredPricingPriceProperties;

[JsonConverter(typeof(ModelTypeConverter))]
public enum ModelType
{
    ScalableMatrixWithTieredPricing,
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
            "scalable_matrix_with_tiered_pricing" => ModelType.ScalableMatrixWithTieredPricing,
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
                ModelType.ScalableMatrixWithTieredPricing => "scalable_matrix_with_tiered_pricing",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
