using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.MatrixSubLineItemProperties;

[JsonConverter(typeof(EnumConverter<Type, string>))]
public sealed record class Type(string value) : IEnum<Type, string>
{
    public static readonly Type Matrix = new("matrix");

    readonly string _value = value;

    public enum Value
    {
        Matrix,
    }

    public Value Known() =>
        _value switch
        {
            "matrix" => Value.Matrix,
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
