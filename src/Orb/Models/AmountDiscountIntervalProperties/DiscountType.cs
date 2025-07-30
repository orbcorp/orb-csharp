using System;
using System.Text.Json.Serialization;

namespace Orb.Models.AmountDiscountIntervalProperties;

[JsonConverter(typeof(EnumConverter<DiscountType, string>))]
public sealed record class DiscountType(string value) : IEnum<DiscountType, string>
{
    public static readonly DiscountType Amount = new("amount");

    readonly string _value = value;

    public enum Value
    {
        Amount,
    }

    public Value Known() =>
        _value switch
        {
            "amount" => Value.Amount,
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
