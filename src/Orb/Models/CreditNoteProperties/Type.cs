using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CreditNoteProperties;

[JsonConverter(typeof(EnumConverter<Type, string>))]
public sealed record class Type(string value) : IEnum<Type, string>
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
