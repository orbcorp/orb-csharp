using System;
using System.Text.Json.Serialization;

namespace Orb.Models.MonetaryPercentageDiscountAdjustmentProperties;

[JsonConverter(typeof(EnumConverter<AdjustmentType, string>))]
public sealed record class AdjustmentType(string value) : IEnum<AdjustmentType, string>
{
    public static readonly AdjustmentType PercentageDiscount = new("percentage_discount");

    readonly string _value = value;

    public enum Value
    {
        PercentageDiscount,
    }

    public Value Known() =>
        _value switch
        {
            "percentage_discount" => Value.PercentageDiscount,
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

    public static AdjustmentType FromRaw(string value)
    {
        return new(value);
    }
}
