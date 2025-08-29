using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewMaximumProperties;

/// <summary>
/// If set, only prices of the specified type will have the adjustment applied.
/// </summary>
[JsonConverter(typeof(PriceTypeConverter))]
public enum PriceType
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class PriceTypeConverter : JsonConverter<PriceType>
{
    public override PriceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => PriceType.Usage,
            "fixed_in_advance" => PriceType.FixedInAdvance,
            "fixed_in_arrears" => PriceType.FixedInArrears,
            "fixed" => PriceType.Fixed,
            "in_arrears" => PriceType.InArrears,
            _ => (PriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceType.Usage => "usage",
                PriceType.FixedInAdvance => "fixed_in_advance",
                PriceType.FixedInArrears => "fixed_in_arrears",
                PriceType.Fixed => "fixed",
                PriceType.InArrears => "in_arrears",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
