using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionFetchUsageParamsProperties;

/// <summary>
/// This determines the windowing of usage reporting.
/// </summary>
[JsonConverter(typeof(GranularityConverter))]
public enum Granularity
{
    Day,
}

sealed class GranularityConverter : JsonConverter<Granularity>
{
    public override Granularity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => Granularity.Day,
            _ => (Granularity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Granularity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Granularity.Day => "day",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
