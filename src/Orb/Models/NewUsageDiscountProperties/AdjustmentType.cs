using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewUsageDiscountProperties;

[JsonConverter(typeof(EnumConverter<AdjustmentType, string>))]
public sealed record class AdjustmentType(string value) : IEnum<AdjustmentType, string>
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
