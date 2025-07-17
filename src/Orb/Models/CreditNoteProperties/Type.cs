using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CreditNoteProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Type, string>))]
public sealed record class Type(string value) : Orb::IEnum<Type, string>
{
    public static readonly Type Refund = new("refund");

    public static readonly Type Adjustment = new("adjustment");

    readonly string _value = value;

    public enum Value
    {
        Refund,
        Adjustment,
    }

    public Value Known() =>
        _value switch
        {
            "refund" => Value.Refund,
            "adjustment" => Value.Adjustment,
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
