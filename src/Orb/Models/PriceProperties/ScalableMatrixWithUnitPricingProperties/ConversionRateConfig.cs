using ConversionRateConfigVariants = Orb.Models.PriceProperties.ScalableMatrixWithUnitPricingProperties.ConversionRateConfigVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.PriceProperties.ScalableMatrixWithUnitPricingProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<ConversionRateConfig>))]
public abstract record class ConversionRateConfig
{
    internal ConversionRateConfig() { }

    public static implicit operator ConversionRateConfig(Models::UnitConversionRateConfig value) =>
        new ConversionRateConfigVariants::UnitConversionRateConfig(value);

    public static implicit operator ConversionRateConfig(
        Models::TieredConversionRateConfig value
    ) => new ConversionRateConfigVariants::TieredConversionRateConfig(value);

    public abstract void Validate();
}
