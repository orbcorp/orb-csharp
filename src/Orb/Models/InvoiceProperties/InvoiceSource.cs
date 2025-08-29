using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.InvoiceProperties;

[JsonConverter(typeof(InvoiceSourceConverter))]
public enum InvoiceSource
{
    Subscription,
    Partial,
    OneOff,
}

sealed class InvoiceSourceConverter : JsonConverter<InvoiceSource>
{
    public override InvoiceSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription" => InvoiceSource.Subscription,
            "partial" => InvoiceSource.Partial,
            "one_off" => InvoiceSource.OneOff,
            _ => (InvoiceSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceSource.Subscription => "subscription",
                InvoiceSource.Partial => "partial",
                InvoiceSource.OneOff => "one_off",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
