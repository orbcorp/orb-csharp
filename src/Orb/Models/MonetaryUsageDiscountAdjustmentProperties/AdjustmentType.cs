using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.MonetaryUsageDiscountAdjustmentProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<AdjustmentType, string>))]
public sealed record class AdjustmentType(string value) : Orb::IEnum<AdjustmentType, string>
{
    public static readonly AdjustmentType UsageDiscount = new("usage_discount");

    readonly string _value = value;

    public enum Value
    {
        UsageDiscount,
    }

    public Value Known() =>
        _value switch
        {
            "usage_discount" => Value.UsageDiscount,
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

    public static AdjustmentType FromRaw(string value)
    {
        return new(value);
    }
}
