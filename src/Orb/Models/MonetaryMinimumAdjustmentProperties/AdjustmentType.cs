using System;
using System.Text.Json.Serialization;

namespace Orb.Models.MonetaryMinimumAdjustmentProperties;

[JsonConverter(typeof(EnumConverter<AdjustmentType, string>))]
public sealed record class AdjustmentType(string value) : IEnum<AdjustmentType, string>
{
    public static readonly AdjustmentType Minimum = new("minimum");

    readonly string _value = value;

    public enum Value
    {
        Minimum,
    }

    public Value Known() =>
        _value switch
        {
            "minimum" => Value.Minimum,
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
