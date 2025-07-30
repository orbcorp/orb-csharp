using System;
using System.Text.Json.Serialization;

namespace Orb.Models.InvoiceProperties.PaymentAttemptProperties;

/// <summary>
/// The payment provider that attempted to collect the payment.
/// </summary>
[JsonConverter(typeof(EnumConverter<PaymentProvider, string>))]
public sealed record class PaymentProvider(string value) : IEnum<PaymentProvider, string>
{
    public static readonly PaymentProvider Stripe = new("stripe");

    readonly string _value = value;

    public enum Value
    {
        Stripe,
    }

    public Value Known() =>
        _value switch
        {
            "stripe" => Value.Stripe,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static PaymentProvider FromRaw(string value)
    {
        return new(value);
    }
}
