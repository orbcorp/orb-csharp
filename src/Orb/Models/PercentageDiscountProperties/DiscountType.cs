using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.PercentageDiscountProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<DiscountType, string>))]
public sealed record class DiscountType(string value) : Orb::IEnum<DiscountType, string>
{
    public static readonly DiscountType Percentage = new("percentage");

    readonly string _value = value;

    public enum Value
    {
        Percentage,
    }

    public Value Known() =>
        _value switch
        {
            "percentage" => Value.Percentage,
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

    public static DiscountType FromRaw(string value)
    {
        return new(value);
    }
}
