using Orb.Core;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class NewAvalaraTaxConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewAvalaraTaxConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewAvalaraTaxConfigurationTaxProvider.Avalara,
            AutomaticTaxEnabled = true,
            TaxExemptionCode = "tax_exemption_code",
        };

        bool expectedTaxExempt = true;
        ApiEnum<string, NewAvalaraTaxConfigurationTaxProvider> expectedTaxProvider =
            NewAvalaraTaxConfigurationTaxProvider.Avalara;
        bool expectedAutomaticTaxEnabled = true;
        string expectedTaxExemptionCode = "tax_exemption_code";

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.Equal(expectedTaxProvider, model.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
        Assert.Equal(expectedTaxExemptionCode, model.TaxExemptionCode);
    }
}
