using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerUpdateParamsPaymentConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType =
                        CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        List<CustomerUpdateParamsPaymentConfigurationPaymentProvider> expectedPaymentProviders =
        [
            new()
            {
                ProviderType =
                    CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                ExcludedPaymentMethodTypes = ["string"],
            },
        ];

        Assert.NotNull(model.PaymentProviders);
        Assert.Equal(expectedPaymentProviders.Count, model.PaymentProviders.Count);
        for (int i = 0; i < expectedPaymentProviders.Count; i++)
        {
            Assert.Equal(expectedPaymentProviders[i], model.PaymentProviders[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType =
                        CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsPaymentConfiguration>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType =
                        CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsPaymentConfiguration>(
            element
        );
        Assert.NotNull(deserialized);

        List<CustomerUpdateParamsPaymentConfigurationPaymentProvider> expectedPaymentProviders =
        [
            new()
            {
                ProviderType =
                    CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                ExcludedPaymentMethodTypes = ["string"],
            },
        ];

        Assert.NotNull(deserialized.PaymentProviders);
        Assert.Equal(expectedPaymentProviders.Count, deserialized.PaymentProviders.Count);
        for (int i = 0; i < expectedPaymentProviders.Count; i++)
        {
            Assert.Equal(expectedPaymentProviders[i], deserialized.PaymentProviders[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType =
                        CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfiguration { };

        Assert.Null(model.PaymentProviders);
        Assert.False(model.RawData.ContainsKey("payment_providers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfiguration
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
        var model = new CustomerUpdateParamsPaymentConfiguration
        {
            // Null should be interpreted as omitted for these properties
            PaymentProviders = null,
        };

        model.Validate();
    }
}

public class CustomerUpdateParamsPaymentConfigurationPaymentProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        ApiEnum<
            string,
            CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType
        > expectedProviderType =
            CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe;
        List<string> expectedExcludedPaymentMethodTypes = ["string"];

        Assert.Equal(expectedProviderType, model.ProviderType);
        Assert.NotNull(model.ExcludedPaymentMethodTypes);
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
        var model = new CustomerUpdateParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateParamsPaymentConfigurationPaymentProvider>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<CustomerUpdateParamsPaymentConfigurationPaymentProvider>(
                element
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType
        > expectedProviderType =
            CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe;
        List<string> expectedExcludedPaymentMethodTypes = ["string"];

        Assert.Equal(expectedProviderType, deserialized.ProviderType);
        Assert.NotNull(deserialized.ExcludedPaymentMethodTypes);
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
        var model = new CustomerUpdateParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
        };

        Assert.Null(model.ExcludedPaymentMethodTypes);
        Assert.False(model.RawData.ContainsKey("excluded_payment_method_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,

            // Null should be interpreted as omitted for these properties
            ExcludedPaymentMethodTypes = null,
        };

        Assert.Null(model.ExcludedPaymentMethodTypes);
        Assert.False(model.RawData.ContainsKey("excluded_payment_method_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerUpdateParamsPaymentConfigurationPaymentProvider
        {
            ProviderType =
                CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe,

            // Null should be interpreted as omitted for these properties
            ExcludedPaymentMethodTypes = null,
        };

        model.Validate();
    }
}

public class CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderTypeTest : TestBase
{
    [Theory]
    [InlineData(CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe)]
    public void Validation_Works(
        CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType.Stripe)]
    public void SerializationRoundtrip_Works(
        CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerUpdateParamsPaymentProviderTest : TestBase
{
    [Theory]
    [InlineData(CustomerUpdateParamsPaymentProvider.Quickbooks)]
    [InlineData(CustomerUpdateParamsPaymentProvider.BillCom)]
    [InlineData(CustomerUpdateParamsPaymentProvider.StripeCharge)]
    [InlineData(CustomerUpdateParamsPaymentProvider.StripeInvoice)]
    [InlineData(CustomerUpdateParamsPaymentProvider.Netsuite)]
    public void Validation_Works(CustomerUpdateParamsPaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerUpdateParamsPaymentProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsPaymentProvider>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerUpdateParamsPaymentProvider.Quickbooks)]
    [InlineData(CustomerUpdateParamsPaymentProvider.BillCom)]
    [InlineData(CustomerUpdateParamsPaymentProvider.StripeCharge)]
    [InlineData(CustomerUpdateParamsPaymentProvider.StripeInvoice)]
    [InlineData(CustomerUpdateParamsPaymentProvider.Netsuite)]
    public void SerializationRoundtrip_Works(CustomerUpdateParamsPaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerUpdateParamsPaymentProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsPaymentProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsPaymentProvider>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsPaymentProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerUpdateParamsTaxConfigurationTest : TestBase
{
    [Fact]
    public void NewAvalaraValidationWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new NewAvalaraTaxConfiguration()
            {
                TaxExempt = true,
                TaxProvider = TaxProvider.Avalara,
                AutomaticTaxEnabled = true,
                TaxExemptionCode = "tax_exemption_code",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewTaxJarValidationWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new NewTaxJarConfiguration()
            {
                TaxExempt = true,
                TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
                AutomaticTaxEnabled = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewSphereValidationWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new NewSphereConfiguration()
            {
                TaxExempt = true,
                TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
                AutomaticTaxEnabled = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NumeralValidationWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new CustomerUpdateParamsTaxConfigurationNumeral()
            {
                TaxExempt = true,
                AutomaticTaxEnabled = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void AnrokValidationWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new CustomerUpdateParamsTaxConfigurationAnrok()
            {
                TaxExempt = true,
                AutomaticTaxEnabled = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void StripeValidationWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new CustomerUpdateParamsTaxConfigurationStripe()
            {
                TaxExempt = true,
                AutomaticTaxEnabled = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewAvalaraSerializationRoundtripWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new NewAvalaraTaxConfiguration()
            {
                TaxExempt = true,
                TaxProvider = TaxProvider.Avalara,
                AutomaticTaxEnabled = true,
                TaxExemptionCode = "tax_exemption_code",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfiguration>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewTaxJarSerializationRoundtripWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new NewTaxJarConfiguration()
            {
                TaxExempt = true,
                TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
                AutomaticTaxEnabled = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfiguration>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSphereSerializationRoundtripWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new NewSphereConfiguration()
            {
                TaxExempt = true,
                TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
                AutomaticTaxEnabled = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfiguration>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NumeralSerializationRoundtripWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new CustomerUpdateParamsTaxConfigurationNumeral()
            {
                TaxExempt = true,
                AutomaticTaxEnabled = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfiguration>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnrokSerializationRoundtripWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new CustomerUpdateParamsTaxConfigurationAnrok()
            {
                TaxExempt = true,
                AutomaticTaxEnabled = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfiguration>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StripeSerializationRoundtripWorks()
    {
        CustomerUpdateParamsTaxConfiguration value = new(
            new CustomerUpdateParamsTaxConfigurationStripe()
            {
                TaxExempt = true,
                AutomaticTaxEnabled = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfiguration>(
            element
        );

        Assert.Equal(value, deserialized);
    }
}

public class CustomerUpdateParamsTaxConfigurationNumeralTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationNumeral
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
        var model = new CustomerUpdateParamsTaxConfigurationNumeral
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfigurationNumeral>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationNumeral
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfigurationNumeral>(
            element
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
        var model = new CustomerUpdateParamsTaxConfigurationNumeral
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationNumeral { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationNumeral { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationNumeral
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
        var model = new CustomerUpdateParamsTaxConfigurationNumeral
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}

public class CustomerUpdateParamsTaxConfigurationAnrokTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationAnrok
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
        var model = new CustomerUpdateParamsTaxConfigurationAnrok
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfigurationAnrok>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationAnrok
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfigurationAnrok>(
            element
        );
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
        var model = new CustomerUpdateParamsTaxConfigurationAnrok
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationAnrok { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationAnrok { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationAnrok
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
        var model = new CustomerUpdateParamsTaxConfigurationAnrok
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}

public class CustomerUpdateParamsTaxConfigurationStripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationStripe
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
        var model = new CustomerUpdateParamsTaxConfigurationStripe
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfigurationStripe>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationStripe
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsTaxConfigurationStripe>(
            element
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
        var model = new CustomerUpdateParamsTaxConfigurationStripe
        {
            TaxExempt = true,
            AutomaticTaxEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationStripe { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationStripe { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerUpdateParamsTaxConfigurationStripe
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
        var model = new CustomerUpdateParamsTaxConfigurationStripe
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}
