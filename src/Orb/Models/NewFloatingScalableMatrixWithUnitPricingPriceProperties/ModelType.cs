using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingScalableMatrixWithUnitPricingPriceProperties;

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(ModelTypeConverter))]
public enum ModelType
{
    ScalableMatrixWithUnitPricing,
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
            "scalable_matrix_with_unit_pricing" => ModelType.ScalableMatrixWithUnitPricing,
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
                ModelType.ScalableMatrixWithUnitPricing => "scalable_matrix_with_unit_pricing",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
