using System;
using System.Text.Json.Serialization;

namespace Orb.Models.TransformPriceFilterProperties;

/// <summary>
/// Should prices that match the filter be included or excluded.
/// </summary>
[JsonConverter(typeof(EnumConverter<Operator, string>))]
public sealed record class Operator(string value) : IEnum<Operator, string>
{
    public static readonly Operator Includes = new("includes");

    public static readonly Operator Excludes = new("excludes");

    readonly string _value = value;

    public enum Value
    {
        Includes,
        Excludes,
    }

    public Value Known() =>
        _value switch
        {
            "includes" => Value.Includes,
            "excludes" => Value.Excludes,
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

    public static Operator FromRaw(string value)
    {
        return new(value);
    }
}
