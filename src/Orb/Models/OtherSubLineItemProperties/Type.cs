using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.OtherSubLineItemProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Type, string>))]
public sealed record class Type(string value) : Orb::IEnum<Type, string>
{
    public static readonly Type Null = new("'null'");

    readonly string _value = value;

    public enum Value
    {
        Null,
    }

    public Value Known() =>
        _value switch
        {
            "'null'" => Value.Null,
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
