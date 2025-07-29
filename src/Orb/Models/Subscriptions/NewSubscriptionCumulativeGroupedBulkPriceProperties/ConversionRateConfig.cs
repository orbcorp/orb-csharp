using ConversionRateConfigVariants = Orb.Models.Subscriptions.NewSubscriptionCumulativeGroupedBulkPriceProperties.ConversionRateConfigVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionCumulativeGroupedBulkPriceProperties;

/// <summary>
/// The configuration for the rate of the price currency to the invoicing currency.
/// </summary>
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
