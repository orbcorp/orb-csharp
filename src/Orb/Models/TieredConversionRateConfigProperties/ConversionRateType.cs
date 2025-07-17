using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.TieredConversionRateConfigProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ConversionRateType, string>))]
public sealed record class ConversionRateType(string value) : Orb::IEnum<ConversionRateType, string>
{
    public static readonly ConversionRateType Tiered = new("tiered");

    readonly string _value = value;

    public enum Value
    {
        Tiered,
    }

    public Value Known() =>
        _value switch
        {
            "tiered" => Value.Tiered,
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

    public static ConversionRateType FromRaw(string value)
    {
        return new(value);
    }
}
