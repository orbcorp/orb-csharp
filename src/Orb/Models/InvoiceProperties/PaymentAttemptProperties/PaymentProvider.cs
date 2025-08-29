using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.InvoiceProperties.PaymentAttemptProperties;

/// <summary>
/// The payment provider that attempted to collect the payment.
/// </summary>
[JsonConverter(typeof(PaymentProviderConverter))]
public enum PaymentProvider
{
    Stripe,
}

sealed class PaymentProviderConverter : JsonConverter<PaymentProvider>
{
    public override PaymentProvider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => PaymentProvider.Stripe,
            _ => (PaymentProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentProvider.Stripe => "stripe",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
