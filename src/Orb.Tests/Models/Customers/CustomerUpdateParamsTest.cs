using System.Text.Json;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class TaxConfigurationModelNumeralTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxConfigurationModelNumeral
        {
            TaxExempt = true,
            TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\""),
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        TaxConfigurationModelNumeralTaxProvider expectedTaxProvider =
            JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.Equal(expectedTaxProvider, model.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}

public class TaxConfigurationModelAnrokTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxConfigurationModelAnrok
        {
            TaxExempt = true,
            TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"anrok\""),
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        TaxConfigurationModelAnrokTaxProvider expectedTaxProvider =
            JsonSerializer.Deserialize<JsonElement>("\"anrok\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.Equal(expectedTaxProvider, model.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}

public class TaxConfigurationModelStripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxConfigurationModelStripe
        {
            TaxExempt = true,
            TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"stripe\""),
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        TaxConfigurationModelStripeTaxProvider expectedTaxProvider =
            JsonSerializer.Deserialize<JsonElement>("\"stripe\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.Equal(expectedTaxProvider, model.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}
