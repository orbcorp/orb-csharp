using System.Text.Json.Serialization;

namespace Orb.Models.Customers.CustomerCreateParamsProperties.TaxConfigurationVariants;

[JsonConverter(
    typeof(VariantConverter<NewAvalaraTaxConfigurationVariant, NewAvalaraTaxConfiguration>)
)]
public sealed record class NewAvalaraTaxConfigurationVariant(NewAvalaraTaxConfiguration Value)
    : TaxConfiguration,
        IVariant<NewAvalaraTaxConfigurationVariant, NewAvalaraTaxConfiguration>
{
    public static NewAvalaraTaxConfigurationVariant From(NewAvalaraTaxConfiguration value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewTaxJarConfigurationVariant, NewTaxJarConfiguration>))]
public sealed record class NewTaxJarConfigurationVariant(NewTaxJarConfiguration Value)
    : TaxConfiguration,
        IVariant<NewTaxJarConfigurationVariant, NewTaxJarConfiguration>
{
    public static NewTaxJarConfigurationVariant From(NewTaxJarConfiguration value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewSphereConfigurationVariant, NewSphereConfiguration>))]
public sealed record class NewSphereConfigurationVariant(NewSphereConfiguration Value)
    : TaxConfiguration,
        IVariant<NewSphereConfigurationVariant, NewSphereConfiguration>
{
    public static NewSphereConfigurationVariant From(NewSphereConfiguration value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
