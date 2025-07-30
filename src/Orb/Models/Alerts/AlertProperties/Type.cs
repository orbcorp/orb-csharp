using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Alerts.AlertProperties;

/// <summary>
/// The type of alert. This must be a valid alert type.
/// </summary>
[JsonConverter(typeof(EnumConverter<Type, string>))]
public sealed record class Type(string value) : IEnum<Type, string>
{
    public static readonly Type CreditBalanceDepleted = new("credit_balance_depleted");

    public static readonly Type CreditBalanceDropped = new("credit_balance_dropped");

    public static readonly Type CreditBalanceRecovered = new("credit_balance_recovered");

    public static readonly Type UsageExceeded = new("usage_exceeded");

    public static readonly Type CostExceeded = new("cost_exceeded");

    readonly string _value = value;

    public enum Value
    {
        CreditBalanceDepleted,
        CreditBalanceDropped,
        CreditBalanceRecovered,
        UsageExceeded,
        CostExceeded,
    }

    public Value Known() =>
        _value switch
        {
            "credit_balance_depleted" => Value.CreditBalanceDepleted,
            "credit_balance_dropped" => Value.CreditBalanceDropped,
            "credit_balance_recovered" => Value.CreditBalanceRecovered,
            "usage_exceeded" => Value.UsageExceeded,
            "cost_exceeded" => Value.CostExceeded,
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
