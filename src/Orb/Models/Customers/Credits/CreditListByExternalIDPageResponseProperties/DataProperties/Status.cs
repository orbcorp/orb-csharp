using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Customers.Credits.CreditListByExternalIDPageResponseProperties.DataProperties;

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    PendingPayment,
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
            "pending_payment" => Status.PendingPayment,
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
                Status.PendingPayment => "pending_payment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
