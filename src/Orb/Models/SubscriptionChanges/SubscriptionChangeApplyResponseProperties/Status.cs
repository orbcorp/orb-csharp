using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.SubscriptionChanges.SubscriptionChangeApplyResponseProperties;

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Applied,
    Cancelled,
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
            "pending" => Status.Pending,
            "applied" => Status.Applied,
            "cancelled" => Status.Cancelled,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Applied => "applied",
                Status.Cancelled => "cancelled",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
