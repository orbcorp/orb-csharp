using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties.UngroupedSubscriptionUsageProperties.DataProperties;

[JsonConverter(typeof(ViewModeConverter))]
public enum ViewMode
{
    Periodic,
    Cumulative,
}

sealed class ViewModeConverter : JsonConverter<ViewMode>
{
    public override ViewMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "periodic" => ViewMode.Periodic,
            "cumulative" => ViewMode.Cumulative,
            _ => (ViewMode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, ViewMode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewMode.Periodic => "periodic",
                ViewMode.Cumulative => "cumulative",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
