using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.NewPlanMatrixWithDisplayNamePriceProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : Orb::IEnum<ModelType, string>
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

    public static ModelType FromRaw(string value)
    {
        return new(value);
    }
}
