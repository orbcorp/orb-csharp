using System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingGroupedTieredPackagePriceProperties.ConversionRateConfigVariants;

[JsonConverter(typeof(VariantConverter<UnitConversionRateConfigVariant, UnitConversionRateConfig>))]
public sealed record class UnitConversionRateConfigVariant(UnitConversionRateConfig Value)
    : ConversionRateConfig,
        IVariant<UnitConversionRateConfigVariant, UnitConversionRateConfig>
{
    public static UnitConversionRateConfigVariant From(UnitConversionRateConfig value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<TieredConversionRateConfigVariant, TieredConversionRateConfig>)
)]
public sealed record class TieredConversionRateConfigVariant(TieredConversionRateConfig Value)
    : ConversionRateConfig,
        IVariant<TieredConversionRateConfigVariant, TieredConversionRateConfig>
{
    public static TieredConversionRateConfigVariant From(TieredConversionRateConfig value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
