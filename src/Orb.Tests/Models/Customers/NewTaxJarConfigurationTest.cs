using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewTaxJarConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewTaxJarConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewTaxJarConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
            AutomaticTaxEnabled = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewTaxJarConfiguration>(element);
        Assert.NotNull(deserialized);

        bool expectedTaxExempt = true;
        ApiEnum<string, NewTaxJarConfigurationTaxProvider> expectedTaxProvider =
            NewTaxJarConfigurationTaxProvider.Taxjar;
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, deserialized.TaxExempt);
        Assert.Equal(expectedTaxProvider, deserialized.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, deserialized.AutomaticTaxEnabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewTaxJarConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
            AutomaticTaxEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewTaxJarConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
        };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewTaxJarConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewTaxJarConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,

            AutomaticTaxEnabled = null,
        };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.True(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewTaxJarConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}

public class NewTaxJarConfigurationTaxProviderTest : TestBase
{
    [Theory]
    [InlineData(NewTaxJarConfigurationTaxProvider.Taxjar)]
    public void Validation_Works(NewTaxJarConfigurationTaxProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewTaxJarConfigurationTaxProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewTaxJarConfigurationTaxProvider>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewTaxJarConfigurationTaxProvider.Taxjar)]
    public void SerializationRoundtrip_Works(NewTaxJarConfigurationTaxProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewTaxJarConfigurationTaxProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewTaxJarConfigurationTaxProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewTaxJarConfigurationTaxProvider>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewTaxJarConfigurationTaxProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
