using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.NewAmountDiscountProperties;

/// <summary>
/// If set, only prices of the specified type will have the adjustment applied.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::EnumConverter<PriceType, string>))]
public sealed record class PriceType(string value) : Orb::IEnum<PriceType, string>
{
    public static readonly PriceType Usage = new("usage");

    public static readonly PriceType FixedInAdvance = new("fixed_in_advance");

    public static readonly PriceType FixedInArrears = new("fixed_in_arrears");

    public static readonly PriceType Fixed = new("fixed");

    public static readonly PriceType InArrears = new("in_arrears");

    readonly string _value = value;

    public enum Value
    {
        Usage,
        FixedInAdvance,
        FixedInArrears,
        Fixed,
        InArrears,
    }

    public Value Known() =>
        _value switch
        {
            "usage" => Value.Usage,
            "fixed_in_advance" => Value.FixedInAdvance,
            "fixed_in_arrears" => Value.FixedInArrears,
            "fixed" => Value.Fixed,
            "in_arrears" => Value.InArrears,
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

    public static PriceType FromRaw(string value)
    {
        return new(value);
    }
}
