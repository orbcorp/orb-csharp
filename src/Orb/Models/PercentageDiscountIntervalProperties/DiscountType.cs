using System;
using System.Text.Json.Serialization;

namespace Orb.Models.PercentageDiscountIntervalProperties;

[JsonConverter(typeof(EnumConverter<DiscountType, string>))]
public sealed record class DiscountType(string value) : IEnum<DiscountType, string>
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

    public static DiscountType FromRaw(string value)
    {
        return new(value);
    }
}
