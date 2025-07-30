using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanCreateParamsProperties.PlanPhaseProperties;

[JsonConverter(typeof(EnumConverter<DurationUnit, string>))]
public sealed record class DurationUnit(string value) : IEnum<DurationUnit, string>
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
