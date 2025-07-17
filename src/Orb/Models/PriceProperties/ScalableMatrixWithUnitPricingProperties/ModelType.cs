using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.PriceProperties.ScalableMatrixWithUnitPricingProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : Orb::IEnum<ModelType, string>
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
