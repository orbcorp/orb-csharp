using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanProperties.TrialConfigProperties;

[JsonConverter(typeof(EnumConverter<TrialPeriodUnit, string>))]
public sealed record class TrialPeriodUnit(string value) : IEnum<TrialPeriodUnit, string>
{
    public static readonly TrialPeriodUnit Days = new("days");

    readonly string _value = value;

    public enum Value
    {
        Days,
    }

    public Value Known() =>
        _value switch
        {
            "days" => Value.Days,
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

    public static TrialPeriodUnit FromRaw(string value)
    {
        return new(value);
    }
}
