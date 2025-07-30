using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Items.ItemUpdateParamsProperties.ExternalConnectionProperties;

[JsonConverter(typeof(EnumConverter<ExternalConnectionName, string>))]
public sealed record class ExternalConnectionName(string value)
    : IEnum<ExternalConnectionName, string>
{
    public static readonly ExternalConnectionName Stripe = new("stripe");

    public static readonly ExternalConnectionName Quickbooks = new("quickbooks");

    public static readonly ExternalConnectionName BillCom = new("bill.com");

    public static readonly ExternalConnectionName Netsuite = new("netsuite");

    public static readonly ExternalConnectionName Taxjar = new("taxjar");

    public static readonly ExternalConnectionName Avalara = new("avalara");

    public static readonly ExternalConnectionName Anrok = new("anrok");

    readonly string _value = value;

    public enum Value
    {
        Stripe,
        Quickbooks,
        BillCom,
        Netsuite,
        Taxjar,
        Avalara,
        Anrok,
    }

    public Value Known() =>
        _value switch
        {
            "stripe" => Value.Stripe,
            "quickbooks" => Value.Quickbooks,
            "bill.com" => Value.BillCom,
            "netsuite" => Value.Netsuite,
            "taxjar" => Value.Taxjar,
            "avalara" => Value.Avalara,
            "anrok" => Value.Anrok,
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

    public static ExternalConnectionName FromRaw(string value)
    {
        return new(value);
    }
}
