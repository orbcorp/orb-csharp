using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Beta.PlanVersionPhaseProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<DurationUnit, string>))]
public sealed record class DurationUnit(string value) : Orb::IEnum<DurationUnit, string>
{
    public static readonly DurationUnit Daily = new("daily");

    public static readonly DurationUnit Monthly = new("monthly");

    public static readonly DurationUnit Quarterly = new("quarterly");

    public static readonly DurationUnit SemiAnnual = new("semi_annual");

    public static readonly DurationUnit Annual = new("annual");

    readonly string _value = value;

    public enum Value
    {
        Daily,
        Monthly,
        Quarterly,
        SemiAnnual,
        Annual,
    }

    public Value Known() =>
        _value switch
        {
            "daily" => Value.Daily,
            "monthly" => Value.Monthly,
            "quarterly" => Value.Quarterly,
            "semi_annual" => Value.SemiAnnual,
            "annual" => Value.Annual,
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

    public static DurationUnit FromRaw(string value)
    {
        return new(value);
    }
}
