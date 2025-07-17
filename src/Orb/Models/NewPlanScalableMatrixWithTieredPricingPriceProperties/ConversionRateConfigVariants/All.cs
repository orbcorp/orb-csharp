using Models = Orb.Models;
using NewPlanScalableMatrixWithTieredPricingPriceProperties = Orb.Models.NewPlanScalableMatrixWithTieredPricingPriceProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.NewPlanScalableMatrixWithTieredPricingPriceProperties.ConversionRateConfigVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<UnitConversionRateConfig, Models::UnitConversionRateConfig>)
)]
public sealed record class UnitConversionRateConfig(Models::UnitConversionRateConfig Value)
    : NewPlanScalableMatrixWithTieredPricingPriceProperties::ConversionRateConfig,
        Orb::IVariant<UnitConversionRateConfig, Models::UnitConversionRateConfig>
{
    public static UnitConversionRateConfig From(Models::UnitConversionRateConfig value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<TieredConversionRateConfig, Models::TieredConversionRateConfig>)
)]
public sealed record class TieredConversionRateConfig(Models::TieredConversionRateConfig Value)
    : NewPlanScalableMatrixWithTieredPricingPriceProperties::ConversionRateConfig,
        Orb::IVariant<TieredConversionRateConfig, Models::TieredConversionRateConfig>
{
    public static TieredConversionRateConfig From(Models::TieredConversionRateConfig value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
