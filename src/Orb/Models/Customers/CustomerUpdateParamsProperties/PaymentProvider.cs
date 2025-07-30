using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.CustomerUpdateParamsProperties;

/// <summary>
/// This is used for creating charges or invoices in an external system via Orb. When
/// not in test mode: - the connection must first be configured in the Orb webapp.
///  - if the provider is an invoicing provider (`stripe_invoice`, `quickbooks`, `bill.com`,
/// `netsuite`), any product mappings must first be configured with the Orb team.
/// </summary>
[JsonConverter(typeof(EnumConverter<PaymentProvider, string>))]
public sealed record class PaymentProvider(string value) : IEnum<PaymentProvider, string>
{
    public static readonly PaymentProvider Quickbooks = new("quickbooks");

    public static readonly PaymentProvider BillCom = new("bill.com");

    public static readonly PaymentProvider StripeCharge = new("stripe_charge");

    public static readonly PaymentProvider StripeInvoice = new("stripe_invoice");

    public static readonly PaymentProvider Netsuite = new("netsuite");

    readonly string _value = value;

    public enum Value
    {
        Quickbooks,
        BillCom,
        StripeCharge,
        StripeInvoice,
        Netsuite,
    }

    public Value Known() =>
        _value switch
        {
            "quickbooks" => Value.Quickbooks,
            "bill.com" => Value.BillCom,
            "stripe_charge" => Value.StripeCharge,
            "stripe_invoice" => Value.StripeInvoice,
            "netsuite" => Value.Netsuite,
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
