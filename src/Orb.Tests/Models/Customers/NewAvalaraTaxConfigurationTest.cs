using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
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
            TaxProvider = TaxProvider.Avalara,
            AutomaticTaxEnabled = true,
            TaxExemptionCode = "tax_exemption_code",
        };

        bool expectedTaxExempt = true;
        ApiEnum<string, TaxProvider> expectedTaxProvider = TaxProvider.Avalara;
        bool expectedAutomaticTaxEnabled = true;
        string expectedTaxExemptionCode = "tax_exemption_code";

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.Equal(expectedTaxProvider, model.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
        Assert.Equal(expectedTaxExemptionCode, model.TaxExemptionCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewAvalaraTaxConfiguration
        {
            TaxExempt = true,
            TaxProvider = TaxProvider.Avalara,
            AutomaticTaxEnabled = true,
            TaxExemptionCode = "tax_exemption_code",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewAvalaraTaxConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewAvalaraTaxConfiguration
        {
            TaxExempt = true,
            TaxProvider = TaxProvider.Avalara,
            AutomaticTaxEnabled = true,
            TaxExemptionCode = "tax_exemption_code",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewAvalaraTaxConfiguration>(element);
        Assert.NotNull(deserialized);

        bool expectedTaxExempt = true;
        ApiEnum<string, TaxProvider> expectedTaxProvider = TaxProvider.Avalara;
        bool expectedAutomaticTaxEnabled = true;
        string expectedTaxExemptionCode = "tax_exemption_code";

        Assert.Equal(expectedTaxExempt, deserialized.TaxExempt);
        Assert.Equal(expectedTaxProvider, deserialized.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, deserialized.AutomaticTaxEnabled);
        Assert.Equal(expectedTaxExemptionCode, deserialized.TaxExemptionCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewAvalaraTaxConfiguration
        {
            TaxExempt = true,
            TaxProvider = TaxProvider.Avalara,
            AutomaticTaxEnabled = true,
            TaxExemptionCode = "tax_exemption_code",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewAvalaraTaxConfiguration
        {
            TaxExempt = true,
            TaxProvider = TaxProvider.Avalara,
        };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
        Assert.Null(model.TaxExemptionCode);
        Assert.False(model.RawData.ContainsKey("tax_exemption_code"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewAvalaraTaxConfiguration
        {
            TaxExempt = true,
            TaxProvider = TaxProvider.Avalara,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewAvalaraTaxConfiguration
        {
            TaxExempt = true,
            TaxProvider = TaxProvider.Avalara,

            AutomaticTaxEnabled = null,
            TaxExemptionCode = null,
        };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.True(model.RawData.ContainsKey("automatic_tax_enabled"));
        Assert.Null(model.TaxExemptionCode);
        Assert.True(model.RawData.ContainsKey("tax_exemption_code"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewAvalaraTaxConfiguration
        {
            TaxExempt = true,
            TaxProvider = TaxProvider.Avalara,

            AutomaticTaxEnabled = null,
            TaxExemptionCode = null,
        };

        model.Validate();
    }
}

public class TaxProviderTest : TestBase
{
    [Theory]
    [InlineData(TaxProvider.Avalara)]
    public void Validation_Works(TaxProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TaxProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TaxProvider>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TaxProvider.Avalara)]
    public void SerializationRoundtrip_Works(TaxProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TaxProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TaxProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TaxProvider>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TaxProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
