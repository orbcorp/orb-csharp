using System.Text.Json;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class NumeralTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Numeral
        {
            TaxExempt = true,
            TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\""),
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, model.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}

public class AnrokTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Anrok
        {
            TaxExempt = true,
            TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"anrok\""),
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.Deserialize<JsonElement>("\"anrok\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, model.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}

public class StripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Stripe
        {
            TaxExempt = true,
            TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"stripe\""),
            AutomaticTaxEnabled = true,
        };

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.Deserialize<JsonElement>("\"stripe\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, model.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }
}
