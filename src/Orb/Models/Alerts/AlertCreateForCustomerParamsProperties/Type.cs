using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Alerts.AlertCreateForCustomerParamsProperties;

/// <summary>
/// The type of alert to create. This must be a valid alert type.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::EnumConverter<Type, string>))]
public sealed record class Type(string value) : Orb::IEnum<Type, string>
{
    public static readonly Type CreditBalanceDepleted = new("credit_balance_depleted");

    public static readonly Type CreditBalanceDropped = new("credit_balance_dropped");

    public static readonly Type CreditBalanceRecovered = new("credit_balance_recovered");

    readonly string _value = value;

    public enum Value
    {
        CreditBalanceDepleted,
        CreditBalanceDropped,
        CreditBalanceRecovered,
    }

    public Value Known() =>
        _value switch
        {
            "credit_balance_depleted" => Value.CreditBalanceDepleted,
            "credit_balance_dropped" => Value.CreditBalanceDropped,
            "credit_balance_recovered" => Value.CreditBalanceRecovered,
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

    public static Type FromRaw(string value)
    {
        return new(value);
    }
}
