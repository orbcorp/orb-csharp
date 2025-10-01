using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.NewFloatingThresholdTotalAmountPriceProperties;

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(CadenceConverter))]
public enum Cadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class CadenceConverter : JsonConverter<Cadence>
{
    public override Cadence Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => Cadence.Annual,
            "semi_annual" => Cadence.SemiAnnual,
            "monthly" => Cadence.Monthly,
            "quarterly" => Cadence.Quarterly,
            "one_time" => Cadence.OneTime,
            "custom" => Cadence.Custom,
            _ => (Cadence)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Cadence value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Cadence.Annual => "annual",
                Cadence.SemiAnnual => "semi_annual",
                Cadence.Monthly => "monthly",
                Cadence.Quarterly => "quarterly",
                Cadence.OneTime => "one_time",
                Cadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
