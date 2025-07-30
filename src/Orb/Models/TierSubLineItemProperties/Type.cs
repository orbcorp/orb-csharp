using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.TierSubLineItemProperties;

[JsonConverter(typeof(EnumConverter<Type, string>))]
public sealed record class Type(string value) : IEnum<Type, string>
{
    public static readonly Type Tier = new("tier");

    readonly string _value = value;

    public enum Value
    {
        Tier,
    }

    public Value Known() =>
        _value switch
        {
            "tier" => Value.Tier,
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

    public static Type FromRaw(string value)
    {
        return new(value);
    }
}
