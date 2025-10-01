using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Beta.PlanVersionPhaseProperties;

[JsonConverter(typeof(DurationUnitConverter))]
public enum DurationUnit
{
    Daily,
    Monthly,
    Quarterly,
    SemiAnnual,
    Annual,
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
            "daily" => DurationUnit.Daily,
            "monthly" => DurationUnit.Monthly,
            "quarterly" => DurationUnit.Quarterly,
            "semi_annual" => DurationUnit.SemiAnnual,
            "annual" => DurationUnit.Annual,
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
                DurationUnit.Daily => "daily",
                DurationUnit.Monthly => "monthly",
                DurationUnit.Quarterly => "quarterly",
                DurationUnit.SemiAnnual => "semi_annual",
                DurationUnit.Annual => "annual",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
