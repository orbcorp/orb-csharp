using Orb.Models;

namespace Orb.Tests.Models;

public class TaxAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxAmount
        {
            Amount = "amount",
            TaxRateDescription = "tax_rate_description",
            TaxRatePercentage = "tax_rate_percentage",
        };

        string expectedAmount = "amount";
        string expectedTaxRateDescription = "tax_rate_description";
        string expectedTaxRatePercentage = "tax_rate_percentage";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedTaxRateDescription, model.TaxRateDescription);
        Assert.Equal(expectedTaxRatePercentage, model.TaxRatePercentage);
    }
}
