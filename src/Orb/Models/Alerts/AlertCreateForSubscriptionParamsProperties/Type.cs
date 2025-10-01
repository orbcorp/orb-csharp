using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Alerts.AlertCreateForSubscriptionParamsProperties;

/// <summary>
/// The type of alert to create. This must be a valid alert type.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    UsageExceeded,
    CostExceeded,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage_exceeded" => AlertCreateForSubscriptionParamsProperties.Type.UsageExceeded,
            "cost_exceeded" => AlertCreateForSubscriptionParamsProperties.Type.CostExceeded,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlertCreateForSubscriptionParamsProperties.Type.UsageExceeded => "usage_exceeded",
                AlertCreateForSubscriptionParamsProperties.Type.CostExceeded => "cost_exceeded",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
