using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerUpdateByExternalIDParamsPaymentConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType =
                        CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        List<CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider> expectedPaymentProviders =
        [
            new()
            {
                ProviderType =
                    CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                ExcludedPaymentMethodTypes = ["string"],
            },
        ];

        Assert.Equal(expectedPaymentProviders.Count, model.PaymentProviders.Count);
        for (int i = 0; i < expectedPaymentProviders.Count; i++)
        {
            Assert.Equal(expectedPaymentProviders[i], model.PaymentProviders[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType =
                        CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsPaymentConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType =
                        CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsPaymentConfiguration>(json);
        Assert.NotNull(deserialized);

        List<CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider> expectedPaymentProviders =
        [
            new()
            {
                ProviderType =
                    CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                ExcludedPaymentMethodTypes = ["string"],
            },
        ];

        Assert.Equal(expectedPaymentProviders.Count, deserialized.PaymentProviders.Count);
        for (int i = 0; i < expectedPaymentProviders.Count; i++)
        {
            Assert.Equal(expectedPaymentProviders[i], deserialized.PaymentProviders[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType =
                        CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfiguration { };

        Assert.Null(model.PaymentProviders);
        Assert.False(model.RawData.ContainsKey("payment_providers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfiguration
        {
            // Null should be interpreted as omitted for these properties
            PaymentProviders = null,
        };

        Assert.Null(model.PaymentProviders);
        Assert.False(model.RawData.ContainsKey("payment_providers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfiguration
        {
            // Null should be interpreted as omitted for these properties
            PaymentProviders = null,
        };

        model.Validate();
    }
}

public class CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        ApiEnum<
            string,
            CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType
        > expectedProviderType =
            CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe;
        List<string> expectedExcludedPaymentMethodTypes = ["string"];

        Assert.Equal(expectedProviderType, model.ProviderType);
        Assert.Equal(
            expectedExcludedPaymentMethodTypes.Count,
            model.ExcludedPaymentMethodTypes.Count
        );
        for (int i = 0; i < expectedExcludedPaymentMethodTypes.Count; i++)
        {
            Assert.Equal(
                expectedExcludedPaymentMethodTypes[i],
                model.ExcludedPaymentMethodTypes[i]
            );
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType
        > expectedProviderType =
            CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe;
        List<string> expectedExcludedPaymentMethodTypes = ["string"];

        Assert.Equal(expectedProviderType, deserialized.ProviderType);
        Assert.Equal(
            expectedExcludedPaymentMethodTypes.Count,
            deserialized.ExcludedPaymentMethodTypes.Count
        );
        for (int i = 0; i < expectedExcludedPaymentMethodTypes.Count; i++)
        {
            Assert.Equal(
                expectedExcludedPaymentMethodTypes[i],
                deserialized.ExcludedPaymentMethodTypes[i]
            );
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
        };

        Assert.Null(model.ExcludedPaymentMethodTypes);
        Assert.False(model.RawData.ContainsKey("excluded_payment_method_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,

            // Null should be interpreted as omitted for these properties
            ExcludedPaymentMethodTypes = null,
        };

        Assert.Null(model.ExcludedPaymentMethodTypes);
        Assert.False(model.RawData.ContainsKey("excluded_payment_method_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,

            // Null should be interpreted as omitted for these properties
            ExcludedPaymentMethodTypes = null,
        };

        model.Validate();
    }
}

public class CustomerUpdateByExternalIDParamsTaxConfigurationNumeralTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationNumeral
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

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
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationNumeral
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsTaxConfigurationNumeral>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationNumeral
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsTaxConfigurationNumeral>(
                json
            );
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
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationNumeral
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationNumeral
        {
            TaxExempt = true,
        };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationNumeral
        {
            TaxExempt = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationNumeral
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
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationNumeral
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}

public class CustomerUpdateByExternalIDParamsTaxConfigurationAnrokTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationAnrok
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

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
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationAnrok
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsTaxConfigurationAnrok>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationAnrok
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsTaxConfigurationAnrok>(json);
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
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationAnrok
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationAnrok { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationAnrok { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationAnrok
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
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationAnrok
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}

public class CustomerUpdateByExternalIDParamsTaxConfigurationStripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationStripe
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

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
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationStripe
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsTaxConfigurationStripe>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationStripe
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsTaxConfigurationStripe>(
                json
            );
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
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationStripe
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationStripe { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationStripe { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationStripe
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
        var model = new CustomerUpdateByExternalIDParamsTaxConfigurationStripe
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}
