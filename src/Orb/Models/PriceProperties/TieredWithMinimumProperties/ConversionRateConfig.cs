using System.Text.Json.Serialization;
using ConversionRateConfigVariants = Orb.Models.PriceProperties.TieredWithMinimumProperties.ConversionRateConfigVariants;

namespace Orb.Models.PriceProperties.TieredWithMinimumProperties;

[JsonConverter(typeof(UnionConverter<ConversionRateConfig>))]
public abstract record class ConversionRateConfig
{
    internal ConversionRateConfig() { }

    public static implicit operator ConversionRateConfig(UnitConversionRateConfig value) =>
        new ConversionRateConfigVariants::UnitConversionRateConfigVariant(value);

    public static implicit operator ConversionRateConfig(TieredConversionRateConfig value) =>
        new ConversionRateConfigVariants::TieredConversionRateConfigVariant(value);

    public abstract void Validate();
}
