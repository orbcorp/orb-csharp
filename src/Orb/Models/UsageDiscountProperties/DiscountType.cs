using System;
using System.Text.Json.Serialization;

namespace Orb.Models.UsageDiscountProperties;

[JsonConverter(typeof(EnumConverter<DiscountType, string>))]
public sealed record class DiscountType(string value) : IEnum<DiscountType, string>
{
    public static readonly DiscountType Usage = new("usage");

    readonly string _value = value;

    public enum Value
    {
        Usage,
    }

    public Value Known() =>
        _value switch
        {
            "usage" => Value.Usage,
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
