using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.DiscountOverrideProperties;

[JsonConverter(typeof(EnumConverter<DiscountType, string>))]
public sealed record class DiscountType(string value) : IEnum<DiscountType, string>
{
    public static readonly DiscountType Percentage = new("percentage");

    public static readonly DiscountType Usage = new("usage");

    public static readonly DiscountType Amount = new("amount");

    readonly string _value = value;

    public enum Value
    {
        Percentage,
        Usage,
        Amount,
    }

    public Value Known() =>
        _value switch
        {
            "percentage" => Value.Percentage,
            "usage" => Value.Usage,
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
