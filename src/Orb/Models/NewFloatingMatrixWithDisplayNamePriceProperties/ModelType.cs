using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingMatrixWithDisplayNamePriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType MatrixWithDisplayName = new("matrix_with_display_name");

    readonly string _value = value;

    public enum Value
    {
        MatrixWithDisplayName,
    }

    public Value Known() =>
        _value switch
        {
            "matrix_with_display_name" => Value.MatrixWithDisplayName,
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

    public static ModelType FromRaw(string value)
    {
        return new(value);
    }
}
