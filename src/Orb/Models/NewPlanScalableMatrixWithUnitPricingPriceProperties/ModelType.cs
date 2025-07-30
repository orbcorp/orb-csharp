using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanScalableMatrixWithUnitPricingPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType ScalableMatrixWithUnitPricing = new(
        "scalable_matrix_with_unit_pricing"
    );

    readonly string _value = value;

    public enum Value
    {
        ScalableMatrixWithUnitPricing,
    }

    public Value Known() =>
        _value switch
        {
            "scalable_matrix_with_unit_pricing" => Value.ScalableMatrixWithUnitPricing,
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
