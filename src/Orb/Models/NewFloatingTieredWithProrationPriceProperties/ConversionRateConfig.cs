using ConversionRateConfigVariants = Orb.Models.NewFloatingTieredWithProrationPriceProperties.ConversionRateConfigVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingTieredWithProrationPriceProperties;

/// <summary>
/// The configuration for the rate of the price currency to the invoicing currency.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<ConversionRateConfig>))]
public abstract record class ConversionRateConfig
{
    internal ConversionRateConfig() { }

    public static ConversionRateConfigVariants::UnitConversionRateConfig Create(
        Models::UnitConversionRateConfig value
    ) => new(value);

    public static ConversionRateConfigVariants::TieredConversionRateConfig Create(
        Models::TieredConversionRateConfig value
    ) => new(value);

    public abstract void Validate();
}
