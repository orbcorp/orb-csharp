using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.UsageDiscountProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<DiscountType, string>))]
public sealed record class DiscountType(string value) : Orb::IEnum<DiscountType, string>
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
