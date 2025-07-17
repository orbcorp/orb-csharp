using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.InvoiceProperties.PaymentAttemptProperties;

/// <summary>
/// The payment provider that attempted to collect the payment.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::EnumConverter<PaymentProvider, string>))]
public sealed record class PaymentProvider(string value) : Orb::IEnum<PaymentProvider, string>
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
            _ => throw new System::ArgumentOutOfRangeException(nameof(_value)),
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
