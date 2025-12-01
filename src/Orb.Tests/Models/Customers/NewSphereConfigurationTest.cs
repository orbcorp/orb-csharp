using Orb.Core;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class NewSphereConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewSphereConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        ApiEnum<string, NewSphereConfigurationTaxProvider> expectedTaxProvider =
            NewSphereConfigurationTaxProvider.Sphere;
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.Equal(expectedTaxProvider, model.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}
