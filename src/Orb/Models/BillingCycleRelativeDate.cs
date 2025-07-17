using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<BillingCycleRelativeDate, string>))]
public sealed record class BillingCycleRelativeDate(string value)
    : Orb::IEnum<BillingCycleRelativeDate, string>
{
    public static readonly BillingCycleRelativeDate StartOfTerm = new("start_of_term");

    public static readonly BillingCycleRelativeDate EndOfTerm = new("end_of_term");

    readonly string _value = value;

    public enum Value
    {
        StartOfTerm,
        EndOfTerm,
    }

    public Value Known() =>
        _value switch
        {
            "start_of_term" => Value.StartOfTerm,
            "end_of_term" => Value.EndOfTerm,
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

    public static BillingCycleRelativeDate FromRaw(string value)
    {
        return new(value);
    }
}
