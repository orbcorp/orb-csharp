using System.Text.Json.Serialization;
using TaxConfigurationVariants = Orb.Models.Customers.CustomerCreateParamsProperties.TaxConfigurationVariants;

namespace Orb.Models.Customers.CustomerCreateParamsProperties;

[JsonConverter(typeof(UnionConverter<TaxConfiguration>))]
public abstract record class TaxConfiguration
{
    internal TaxConfiguration() { }

    public static implicit operator TaxConfiguration(NewAvalaraTaxConfiguration value) =>
        new TaxConfigurationVariants::NewAvalaraTaxConfigurationVariant(value);

    public static implicit operator TaxConfiguration(NewTaxJarConfiguration value) =>
        new TaxConfigurationVariants::NewTaxJarConfigurationVariant(value);

    public static implicit operator TaxConfiguration(NewSphereConfiguration value) =>
        new TaxConfigurationVariants::NewSphereConfigurationVariant(value);

    public abstract void Validate();
}
