using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewAllocationPriceProperties;

/// <summary>
/// The cadence at which to allocate the amount to the customer.
/// </summary>
[JsonConverter(typeof(EnumConverter<Cadence, string>))]
public sealed record class Cadence(string value) : IEnum<Cadence, string>
{
    public static readonly Cadence OneTime = new("one_time");

    public static readonly Cadence Monthly = new("monthly");

    public static readonly Cadence Quarterly = new("quarterly");

    public static readonly Cadence SemiAnnual = new("semi_annual");

    public static readonly Cadence Annual = new("annual");

    readonly string _value = value;

    public enum Value
    {
        OneTime,
        Monthly,
        Quarterly,
        SemiAnnual,
        Annual,
    }

    public Value Known() =>
        _value switch
        {
            "one_time" => Value.OneTime,
            "monthly" => Value.Monthly,
            "quarterly" => Value.Quarterly,
            "semi_annual" => Value.SemiAnnual,
            "annual" => Value.Annual,
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

    public static Cadence FromRaw(string value)
    {
        return new(value);
    }
}
