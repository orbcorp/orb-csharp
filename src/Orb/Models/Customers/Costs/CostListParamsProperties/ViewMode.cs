using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Costs.CostListParamsProperties;

/// <summary>
/// Controls whether Orb returns cumulative costs since the start of the billing period,
/// or incremental day-by-day costs. If your customer has minimums or discounts, it's
/// strongly recommended that you use the default cumulative behavior.
/// </summary>
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
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
