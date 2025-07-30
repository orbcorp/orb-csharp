using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionScalableMatrixWithTieredPricingPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType ScalableMatrixWithTieredPricing = new(
        "scalable_matrix_with_tiered_pricing"
    );

    readonly string _value = value;

    public enum Value
    {
        ScalableMatrixWithTieredPricing,
    }

    public Value Known() =>
        _value switch
        {
            "scalable_matrix_with_tiered_pricing" => Value.ScalableMatrixWithTieredPricing,
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
