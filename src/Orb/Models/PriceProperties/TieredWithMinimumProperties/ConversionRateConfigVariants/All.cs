using Orb.Core;
using Models = Orb.Models;

namespace Orb.Models.PriceProperties.TieredWithMinimumProperties.ConversionRateConfigVariants;

public sealed record class UnitConversionRateConfig(Models::UnitConversionRateConfig Value)
    : ConversionRateConfig,
        IVariant<UnitConversionRateConfig, Models::UnitConversionRateConfig>
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

public sealed record class TieredConversionRateConfig(Models::TieredConversionRateConfig Value)
    : ConversionRateConfig,
        IVariant<TieredConversionRateConfig, Models::TieredConversionRateConfig>
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
