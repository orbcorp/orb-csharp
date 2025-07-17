using CustomerCreateParamsProperties = Orb.Models.Customers.CustomerCreateParamsProperties;
using Customers = Orb.Models.Customers;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Customers.CustomerCreateParamsProperties.TaxConfigurationVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewAvalaraTaxConfiguration, Customers::NewAvalaraTaxConfiguration>)
)]
public sealed record class NewAvalaraTaxConfiguration(Customers::NewAvalaraTaxConfiguration Value)
    : CustomerCreateParamsProperties::TaxConfiguration,
        Orb::IVariant<NewAvalaraTaxConfiguration, Customers::NewAvalaraTaxConfiguration>
{
    public static NewAvalaraTaxConfiguration From(Customers::NewAvalaraTaxConfiguration value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewTaxJarConfiguration, Customers::NewTaxJarConfiguration>)
)]
public sealed record class NewTaxJarConfiguration(Customers::NewTaxJarConfiguration Value)
    : CustomerCreateParamsProperties::TaxConfiguration,
        Orb::IVariant<NewTaxJarConfiguration, Customers::NewTaxJarConfiguration>
{
    public static NewTaxJarConfiguration From(Customers::NewTaxJarConfiguration value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewSphereConfiguration, Customers::NewSphereConfiguration>)
)]
public sealed record class NewSphereConfiguration(Customers::NewSphereConfiguration Value)
    : CustomerCreateParamsProperties::TaxConfiguration,
        Orb::IVariant<NewSphereConfiguration, Customers::NewSphereConfiguration>
{
    public static NewSphereConfiguration From(Customers::NewSphereConfiguration value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
