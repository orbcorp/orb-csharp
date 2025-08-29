using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionBulkBPSPriceProperties;

[JsonConverter(typeof(ModelTypeConverter))]
public enum ModelType
{
    BulkBPS,
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
            "bulk_bps" => ModelType.BulkBPS,
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
                ModelType.BulkBPS => "bulk_bps",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
