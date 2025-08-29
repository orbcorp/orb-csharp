using Customers = Orb.Models.Customers;

namespace Orb.Models.Customers.CustomerUpdateParamsProperties.TaxConfigurationVariants;

public sealed record class NewAvalaraTaxConfiguration(Customers::NewAvalaraTaxConfiguration Value)
    : TaxConfiguration,
        IVariant<NewAvalaraTaxConfiguration, Customers::NewAvalaraTaxConfiguration>
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

public sealed record class NewTaxJarConfiguration(Customers::NewTaxJarConfiguration Value)
    : TaxConfiguration,
        IVariant<NewTaxJarConfiguration, Customers::NewTaxJarConfiguration>
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

public sealed record class NewSphereConfiguration(Customers::NewSphereConfiguration Value)
    : TaxConfiguration,
        IVariant<NewSphereConfiguration, Customers::NewSphereConfiguration>
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
