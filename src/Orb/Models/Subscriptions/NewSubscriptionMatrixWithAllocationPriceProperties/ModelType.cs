using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionMatrixWithAllocationPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType MatrixWithAllocation = new("matrix_with_allocation");

    readonly string _value = value;

    public enum Value
    {
        MatrixWithAllocation,
    }

    public Value Known() =>
        _value switch
        {
            "matrix_with_allocation" => Value.MatrixWithAllocation,
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
