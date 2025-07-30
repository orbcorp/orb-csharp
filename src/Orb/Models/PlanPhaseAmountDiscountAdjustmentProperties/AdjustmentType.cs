using System;
using System.Text.Json.Serialization;

namespace Orb.Models.PlanPhaseAmountDiscountAdjustmentProperties;

[JsonConverter(typeof(EnumConverter<AdjustmentType, string>))]
public sealed record class AdjustmentType(string value) : IEnum<AdjustmentType, string>
{
    public static readonly AdjustmentType AmountDiscount = new("amount_discount");

    readonly string _value = value;

    public enum Value
    {
        AmountDiscount,
    }

    public Value Known() =>
        _value switch
        {
            "amount_discount" => Value.AmountDiscount,
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
