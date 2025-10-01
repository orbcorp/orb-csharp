using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Customers.CustomerCreateParamsProperties;

/// <summary>
/// This is used for creating charges or invoices in an external system via Orb. When
/// not in test mode, the connection must first be configured in the Orb webapp.
/// </summary>
[JsonConverter(typeof(PaymentProviderConverter))]
public enum PaymentProvider
{
    Quickbooks,
    BillCom,
    StripeCharge,
    StripeInvoice,
    Netsuite,
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
            "quickbooks" => PaymentProvider.Quickbooks,
            "bill.com" => PaymentProvider.BillCom,
            "stripe_charge" => PaymentProvider.StripeCharge,
            "stripe_invoice" => PaymentProvider.StripeInvoice,
            "netsuite" => PaymentProvider.Netsuite,
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
                PaymentProvider.Quickbooks => "quickbooks",
                PaymentProvider.BillCom => "bill.com",
                PaymentProvider.StripeCharge => "stripe_charge",
                PaymentProvider.StripeInvoice => "stripe_invoice",
                PaymentProvider.Netsuite => "netsuite",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
