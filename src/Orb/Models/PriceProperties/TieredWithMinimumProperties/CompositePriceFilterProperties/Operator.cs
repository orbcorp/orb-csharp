using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.PriceProperties.TieredWithMinimumProperties.CompositePriceFilterProperties;

/// <summary>
/// Should prices that match the filter be included or excluded.
/// </summary>
[JsonConverter(typeof(OperatorConverter))]
public enum Operator
{
    Includes,
    Excludes,
}

sealed class OperatorConverter : JsonConverter<Operator>
{
    public override Operator Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Operator.Includes,
            "excludes" => Operator.Excludes,
            _ => (Operator)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Operator value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator.Includes => "includes",
                Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
