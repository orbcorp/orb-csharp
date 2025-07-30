using System.Text.Json.Serialization;
using ConversionRateConfigVariants = Orb.Models.NewFloatingMaxGroupTieredPackagePriceProperties.ConversionRateConfigVariants;

namespace Orb.Models.NewFloatingMaxGroupTieredPackagePriceProperties;

/// <summary>
/// The configuration for the rate of the price currency to the invoicing currency.
/// </summary>
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
