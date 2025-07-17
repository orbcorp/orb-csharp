using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.TransformPriceFilterProperties;

/// <summary>
/// Should prices that match the filter be included or excluded.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::EnumConverter<Operator, string>))]
public sealed record class Operator(string value) : Orb::IEnum<Operator, string>
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

    public static Operator FromRaw(string value)
    {
        return new(value);
    }
}
