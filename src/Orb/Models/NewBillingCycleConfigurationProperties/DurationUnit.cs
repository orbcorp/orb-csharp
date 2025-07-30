using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewBillingCycleConfigurationProperties;

/// <summary>
/// The unit of billing period duration.
/// </summary>
[JsonConverter(typeof(EnumConverter<DurationUnit, string>))]
public sealed record class DurationUnit(string value) : IEnum<DurationUnit, string>
{
    public static readonly DurationUnit Day = new("day");

    public static readonly DurationUnit Month = new("month");

    readonly string _value = value;

    public enum Value
    {
        Day,
        Month,
    }

    public Value Known() =>
        _value switch
        {
            "day" => Value.Day,
            "month" => Value.Month,
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

    public static DurationUnit FromRaw(string value)
    {
        return new(value);
    }
}
