using Orb.Core;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class NewTaxJarConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewTaxJarConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        ApiEnum<string, NewTaxJarConfigurationTaxProvider> expectedTaxProvider =
            NewTaxJarConfigurationTaxProvider.Taxjar;
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.Equal(expectedTaxProvider, model.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}
