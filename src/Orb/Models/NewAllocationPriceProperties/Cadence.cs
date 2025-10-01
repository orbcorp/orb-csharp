using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.NewAllocationPriceProperties;

/// <summary>
/// The cadence at which to allocate the amount to the customer.
/// </summary>
[JsonConverter(typeof(CadenceConverter))]
public enum Cadence
{
    OneTime,
    Monthly,
    Quarterly,
    SemiAnnual,
    Annual,
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
            "one_time" => Cadence.OneTime,
            "monthly" => Cadence.Monthly,
            "quarterly" => Cadence.Quarterly,
            "semi_annual" => Cadence.SemiAnnual,
            "annual" => Cadence.Annual,
            _ => (Cadence)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Cadence value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Cadence.OneTime => "one_time",
                Cadence.Monthly => "monthly",
                Cadence.Quarterly => "quarterly",
                Cadence.SemiAnnual => "semi_annual",
                Cadence.Annual => "annual",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
