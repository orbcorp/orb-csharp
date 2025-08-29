using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.SubscriptionChanges.MutatedSubscriptionProperties;

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Ended,
    Upcoming,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "ended" => Status.Ended,
            "upcoming" => Status.Upcoming,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Ended => "ended",
                Status.Upcoming => "upcoming",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
