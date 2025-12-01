using System.Text.Json;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class TaxConfiguration1NumeralTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxConfiguration1Numeral
        {
            TaxExempt = true,
            TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\""),
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        TaxConfiguration1NumeralTaxProvider expectedTaxProvider =
            JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.Equal(expectedTaxProvider, model.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}

public class TaxConfiguration1AnrokTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxConfiguration1Anrok
        {
            TaxExempt = true,
            TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"anrok\""),
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        TaxConfiguration1AnrokTaxProvider expectedTaxProvider =
            JsonSerializer.Deserialize<JsonElement>("\"anrok\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.Equal(expectedTaxProvider, model.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}

public class TaxConfiguration1StripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxConfiguration1Stripe
        {
            TaxExempt = true,
            TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"stripe\""),
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        TaxConfiguration1StripeTaxProvider expectedTaxProvider =
            JsonSerializer.Deserialize<JsonElement>("\"stripe\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.Equal(expectedTaxProvider, model.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}
