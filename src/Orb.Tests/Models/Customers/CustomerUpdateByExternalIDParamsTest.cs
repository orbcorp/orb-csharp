using System.Text.Json;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class TaxConfiguration1NumeralTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxConfiguration1Numeral { TaxExempt = true, AutomaticTaxEnabled = true };

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, model.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TaxConfiguration1Numeral { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration1Numeral>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TaxConfiguration1Numeral { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration1Numeral>(json);
        Assert.NotNull(deserialized);

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, deserialized.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, deserialized.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, deserialized.AutomaticTaxEnabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TaxConfiguration1Numeral { TaxExempt = true, AutomaticTaxEnabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TaxConfiguration1Numeral { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TaxConfiguration1Numeral { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TaxConfiguration1Numeral
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.True(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TaxConfiguration1Numeral
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}

public class TaxConfiguration1AnrokTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxConfiguration1Anrok { TaxExempt = true, AutomaticTaxEnabled = true };

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.Deserialize<JsonElement>("\"anrok\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, model.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TaxConfiguration1Anrok { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration1Anrok>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TaxConfiguration1Anrok { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration1Anrok>(json);
        Assert.NotNull(deserialized);

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.Deserialize<JsonElement>("\"anrok\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, deserialized.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, deserialized.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, deserialized.AutomaticTaxEnabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TaxConfiguration1Anrok { TaxExempt = true, AutomaticTaxEnabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TaxConfiguration1Anrok { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TaxConfiguration1Anrok { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TaxConfiguration1Anrok
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.True(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TaxConfiguration1Anrok
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}

public class TaxConfiguration1StripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxConfiguration1Stripe { TaxExempt = true, AutomaticTaxEnabled = true };

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.Deserialize<JsonElement>("\"stripe\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, model.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TaxConfiguration1Stripe { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration1Stripe>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TaxConfiguration1Stripe { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration1Stripe>(json);
        Assert.NotNull(deserialized);

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.Deserialize<JsonElement>("\"stripe\"");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, deserialized.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, deserialized.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, deserialized.AutomaticTaxEnabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TaxConfiguration1Stripe { TaxExempt = true, AutomaticTaxEnabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TaxConfiguration1Stripe { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TaxConfiguration1Stripe { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TaxConfiguration1Stripe
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.True(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TaxConfiguration1Stripe
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}
