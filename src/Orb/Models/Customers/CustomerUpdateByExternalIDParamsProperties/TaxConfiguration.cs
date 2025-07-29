using Customers = Orb.Models.Customers;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using TaxConfigurationVariants = Orb.Models.Customers.CustomerUpdateByExternalIDParamsProperties.TaxConfigurationVariants;

namespace Orb.Models.Customers.CustomerUpdateByExternalIDParamsProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<TaxConfiguration>))]
public abstract record class TaxConfiguration
{
    internal TaxConfiguration() { }

    public static implicit operator TaxConfiguration(Customers::NewAvalaraTaxConfiguration value) =>
        new TaxConfigurationVariants::NewAvalaraTaxConfiguration(value);

    public static implicit operator TaxConfiguration(Customers::NewTaxJarConfiguration value) =>
        new TaxConfigurationVariants::NewTaxJarConfiguration(value);

    public static implicit operator TaxConfiguration(Customers::NewSphereConfiguration value) =>
        new TaxConfigurationVariants::NewSphereConfiguration(value);

    public abstract void Validate();
}
