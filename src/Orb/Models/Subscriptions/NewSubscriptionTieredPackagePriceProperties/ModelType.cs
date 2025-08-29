using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionTieredPackagePriceProperties;

[JsonConverter(typeof(ModelTypeConverter))]
public enum ModelType
{
    TieredPackage,
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
            "tiered_package" => ModelType.TieredPackage,
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
                ModelType.TieredPackage => "tiered_package",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
