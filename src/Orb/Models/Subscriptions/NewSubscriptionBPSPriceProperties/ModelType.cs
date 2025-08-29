using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionBPSPriceProperties;

[JsonConverter(typeof(ModelTypeConverter))]
public enum ModelType
{
    BPS,
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
            "bps" => ModelType.BPS,
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
                ModelType.BPS => "bps",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
