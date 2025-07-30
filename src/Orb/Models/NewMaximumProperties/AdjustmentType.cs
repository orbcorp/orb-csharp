using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewMaximumProperties;

[JsonConverter(typeof(EnumConverter<AdjustmentType, string>))]
public sealed record class AdjustmentType(string value) : IEnum<AdjustmentType, string>
{
    public static readonly AdjustmentType Maximum = new("maximum");

    readonly string _value = value;

    public enum Value
    {
        Maximum,
    }

    public Value Known() =>
        _value switch
        {
            "maximum" => Value.Maximum,
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
