using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewSphereConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewSphereConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewSphereConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
            AutomaticTaxEnabled = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewSphereConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedTaxExempt = true;
        ApiEnum<string, NewSphereConfigurationTaxProvider> expectedTaxProvider =
            NewSphereConfigurationTaxProvider.Sphere;
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, deserialized.TaxExempt);
        Assert.Equal(expectedTaxProvider, deserialized.TaxProvider);
        Assert.Equal(expectedAutomaticTaxEnabled, deserialized.AutomaticTaxEnabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewSphereConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
            AutomaticTaxEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewSphereConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
        };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewSphereConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewSphereConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewSphereConfigurationTaxProvider.Sphere,

            AutomaticTaxEnabled = null,
        };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.True(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewSphereConfiguration
        {
            TaxExempt = true,
            TaxProvider = NewSphereConfigurationTaxProvider.Sphere,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}

public class NewSphereConfigurationTaxProviderTest : TestBase
{
    [Theory]
    [InlineData(NewSphereConfigurationTaxProvider.Sphere)]
    public void Validation_Works(NewSphereConfigurationTaxProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewSphereConfigurationTaxProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewSphereConfigurationTaxProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewSphereConfigurationTaxProvider.Sphere)]
    public void SerializationRoundtrip_Works(NewSphereConfigurationTaxProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewSphereConfigurationTaxProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewSphereConfigurationTaxProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewSphereConfigurationTaxProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewSphereConfigurationTaxProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
