using Customers = Orb.Models.Customers;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using TaxConfigurationVariants = Orb.Models.Customers.CustomerCreateParamsProperties.TaxConfigurationVariants;

namespace Orb.Models.Customers.CustomerCreateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<TaxConfiguration>))]
public abstract record class TaxConfiguration
{
    internal TaxConfiguration() { }

    public static TaxConfigurationVariants::NewAvalaraTaxConfiguration Create(
        Customers::NewAvalaraTaxConfiguration value
    ) => new(value);

    public static TaxConfigurationVariants::NewTaxJarConfiguration Create(
        Customers::NewTaxJarConfiguration value
    ) => new(value);

    public static TaxConfigurationVariants::NewSphereConfiguration Create(
        Customers::NewSphereConfiguration value
    ) => new(value);

    public abstract void Validate();
}
