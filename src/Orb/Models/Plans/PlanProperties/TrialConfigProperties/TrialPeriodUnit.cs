using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanProperties.TrialConfigProperties;

[JsonConverter(typeof(TrialPeriodUnitConverter))]
public enum TrialPeriodUnit
{
    Days,
}

sealed class TrialPeriodUnitConverter : JsonConverter<TrialPeriodUnit>
{
    public override TrialPeriodUnit Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "days" => TrialPeriodUnit.Days,
            _ => (TrialPeriodUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrialPeriodUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrialPeriodUnit.Days => "days",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
