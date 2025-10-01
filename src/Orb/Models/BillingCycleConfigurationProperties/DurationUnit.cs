using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.BillingCycleConfigurationProperties;

[JsonConverter(typeof(DurationUnitConverter))]
public enum DurationUnit
{
    Day,
    Month,
}

sealed class DurationUnitConverter : JsonConverter<DurationUnit>
{
    public override DurationUnit Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => DurationUnit.Day,
            "month" => DurationUnit.Month,
            _ => (DurationUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DurationUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DurationUnit.Day => "day",
                DurationUnit.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
