using System;
using System.Text.Json.Serialization;

namespace Orb.Models.UnitConversionRateConfigProperties;

[JsonConverter(typeof(EnumConverter<ConversionRateType, string>))]
public sealed record class ConversionRateType(string value) : IEnum<ConversionRateType, string>
{
    public static readonly ConversionRateType Unit = new("unit");

    readonly string _value = value;

    public enum Value
    {
        Unit,
    }

    public Value Known() =>
        _value switch
        {
            "unit" => Value.Unit,
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

    public static ConversionRateType FromRaw(string value)
    {
        return new(value);
    }
}
