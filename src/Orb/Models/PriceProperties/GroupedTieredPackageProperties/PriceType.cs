using System;
using System.Text.Json.Serialization;

namespace Orb.Models.PriceProperties.GroupedTieredPackageProperties;

[JsonConverter(typeof(EnumConverter<PriceType, string>))]
public sealed record class PriceType(string value) : IEnum<PriceType, string>
{
    public static readonly PriceType UsagePrice = new("usage_price");

    public static readonly PriceType FixedPrice = new("fixed_price");

    readonly string _value = value;

    public enum Value
    {
        UsagePrice,
        FixedPrice,
    }

    public Value Known() =>
        _value switch
        {
            "usage_price" => Value.UsagePrice,
            "fixed_price" => Value.FixedPrice,
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

    public static PriceType FromRaw(string value)
    {
        return new(value);
    }
}
