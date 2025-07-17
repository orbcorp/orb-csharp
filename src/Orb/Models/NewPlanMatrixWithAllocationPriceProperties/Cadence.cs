using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.NewPlanMatrixWithAllocationPriceProperties;

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::EnumConverter<Cadence, string>))]
public sealed record class Cadence(string value) : Orb::IEnum<Cadence, string>
{
    public static readonly Cadence Annual = new("annual");

    public static readonly Cadence SemiAnnual = new("semi_annual");

    public static readonly Cadence Monthly = new("monthly");

    public static readonly Cadence Quarterly = new("quarterly");

    public static readonly Cadence OneTime = new("one_time");

    public static readonly Cadence Custom = new("custom");

    readonly string _value = value;

    public enum Value
    {
        Annual,
        SemiAnnual,
        Monthly,
        Quarterly,
        OneTime,
        Custom,
    }

    public Value Known() =>
        _value switch
        {
            "annual" => Value.Annual,
            "semi_annual" => Value.SemiAnnual,
            "monthly" => Value.Monthly,
            "quarterly" => Value.Quarterly,
            "one_time" => Value.OneTime,
            "custom" => Value.Custom,
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

    public static Cadence FromRaw(string value)
    {
        return new(value);
    }
}
