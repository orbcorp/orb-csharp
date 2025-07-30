using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Costs.CostListParamsProperties;

/// <summary>
/// Controls whether Orb returns cumulative costs since the start of the billing period,
/// or incremental day-by-day costs. If your customer has minimums or discounts, it's
/// strongly recommended that you use the default cumulative behavior.
/// </summary>
[JsonConverter(typeof(EnumConverter<ViewMode, string>))]
public sealed record class ViewMode(string value) : IEnum<ViewMode, string>
{
    public static readonly ViewMode Periodic = new("periodic");

    public static readonly ViewMode Cumulative = new("cumulative");

    readonly string _value = value;

    public enum Value
    {
        Periodic,
        Cumulative,
    }

    public Value Known() =>
        _value switch
        {
            "periodic" => Value.Periodic,
            "cumulative" => Value.Cumulative,
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

    public static ViewMode FromRaw(string value)
    {
        return new(value);
    }
}
