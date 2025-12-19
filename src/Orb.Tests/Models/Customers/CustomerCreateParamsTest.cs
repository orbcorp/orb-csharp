using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class PaymentConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType = ProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        List<PaymentProvider> expectedPaymentProviders =
        [
            new() { ProviderType = ProviderType.Stripe, ExcludedPaymentMethodTypes = ["string"] },
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
        var model = new PaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType = ProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType = ProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentConfiguration>(element);
        Assert.NotNull(deserialized);

        List<PaymentProvider> expectedPaymentProviders =
        [
            new() { ProviderType = ProviderType.Stripe, ExcludedPaymentMethodTypes = ["string"] },
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
        var model = new PaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType = ProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaymentConfiguration { };

        Assert.Null(model.PaymentProviders);
        Assert.False(model.RawData.ContainsKey("payment_providers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PaymentConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PaymentConfiguration
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
        var model = new PaymentConfiguration
        {
            // Null should be interpreted as omitted for these properties
            PaymentProviders = null,
        };

        model.Validate();
    }
}

public class PaymentProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentProvider
        {
            ProviderType = ProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        ApiEnum<string, ProviderType> expectedProviderType = ProviderType.Stripe;
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
        var model = new PaymentProvider
        {
            ProviderType = ProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentProvider>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentProvider
        {
            ProviderType = ProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentProvider>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, ProviderType> expectedProviderType = ProviderType.Stripe;
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
        var model = new PaymentProvider
        {
            ProviderType = ProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaymentProvider { ProviderType = ProviderType.Stripe };

        Assert.Null(model.ExcludedPaymentMethodTypes);
        Assert.False(model.RawData.ContainsKey("excluded_payment_method_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PaymentProvider { ProviderType = ProviderType.Stripe };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PaymentProvider
        {
            ProviderType = ProviderType.Stripe,

            // Null should be interpreted as omitted for these properties
            ExcludedPaymentMethodTypes = null,
        };

        Assert.Null(model.ExcludedPaymentMethodTypes);
        Assert.False(model.RawData.ContainsKey("excluded_payment_method_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PaymentProvider
        {
            ProviderType = ProviderType.Stripe,

            // Null should be interpreted as omitted for these properties
            ExcludedPaymentMethodTypes = null,
        };

        model.Validate();
    }
}

public class ProviderTypeTest : TestBase
{
    [Theory]
    [InlineData(ProviderType.Stripe)]
    public void Validation_Works(ProviderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProviderType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProviderType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProviderType.Stripe)]
    public void SerializationRoundtrip_Works(ProviderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProviderType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProviderType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProviderType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProviderType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CustomerCreateParamsPaymentProviderTest : TestBase
{
    [Theory]
    [InlineData(CustomerCreateParamsPaymentProvider.Quickbooks)]
    [InlineData(CustomerCreateParamsPaymentProvider.BillCom)]
    [InlineData(CustomerCreateParamsPaymentProvider.StripeCharge)]
    [InlineData(CustomerCreateParamsPaymentProvider.StripeInvoice)]
    [InlineData(CustomerCreateParamsPaymentProvider.Netsuite)]
    public void Validation_Works(CustomerCreateParamsPaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerCreateParamsPaymentProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerCreateParamsPaymentProvider>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerCreateParamsPaymentProvider.Quickbooks)]
    [InlineData(CustomerCreateParamsPaymentProvider.BillCom)]
    [InlineData(CustomerCreateParamsPaymentProvider.StripeCharge)]
    [InlineData(CustomerCreateParamsPaymentProvider.StripeInvoice)]
    [InlineData(CustomerCreateParamsPaymentProvider.Netsuite)]
    public void SerializationRoundtrip_Works(CustomerCreateParamsPaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerCreateParamsPaymentProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerCreateParamsPaymentProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerCreateParamsPaymentProvider>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerCreateParamsPaymentProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TaxConfigurationTest : TestBase
{
    [Fact]
    public void NewAvalaraValidationWorks()
    {
        TaxConfiguration value = new(
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
        TaxConfiguration value = new(
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
        TaxConfiguration value = new(
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
        TaxConfiguration value = new(
            new Numeral() { TaxExempt = true, AutomaticTaxEnabled = true }
        );
        value.Validate();
    }

    [Fact]
    public void AnrokValidationWorks()
    {
        TaxConfiguration value = new(new Anrok() { TaxExempt = true, AutomaticTaxEnabled = true });
        value.Validate();
    }

    [Fact]
    public void StripeValidationWorks()
    {
        TaxConfiguration value = new(new Stripe() { TaxExempt = true, AutomaticTaxEnabled = true });
        value.Validate();
    }

    [Fact]
    public void NewAvalaraSerializationRoundtripWorks()
    {
        TaxConfiguration value = new(
            new NewAvalaraTaxConfiguration()
            {
                TaxExempt = true,
                TaxProvider = TaxProvider.Avalara,
                AutomaticTaxEnabled = true,
                TaxExemptionCode = "tax_exemption_code",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewTaxJarSerializationRoundtripWorks()
    {
        TaxConfiguration value = new(
            new NewTaxJarConfiguration()
            {
                TaxExempt = true,
                TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
                AutomaticTaxEnabled = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSphereSerializationRoundtripWorks()
    {
        TaxConfiguration value = new(
            new NewSphereConfiguration()
            {
                TaxExempt = true,
                TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
                AutomaticTaxEnabled = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NumeralSerializationRoundtripWorks()
    {
        TaxConfiguration value = new(
            new Numeral() { TaxExempt = true, AutomaticTaxEnabled = true }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnrokSerializationRoundtripWorks()
    {
        TaxConfiguration value = new(new Anrok() { TaxExempt = true, AutomaticTaxEnabled = true });
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StripeSerializationRoundtripWorks()
    {
        TaxConfiguration value = new(new Stripe() { TaxExempt = true, AutomaticTaxEnabled = true });
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(element);

        Assert.Equal(value, deserialized);
    }
}

public class NumeralTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Numeral { TaxExempt = true, AutomaticTaxEnabled = true };

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
        var model = new Numeral { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Numeral>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Numeral { TaxExempt = true, AutomaticTaxEnabled = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Numeral>(element);
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
        var model = new Numeral { TaxExempt = true, AutomaticTaxEnabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Numeral { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Numeral { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Numeral
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
        var model = new Numeral
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}

public class AnrokTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Anrok { TaxExempt = true, AutomaticTaxEnabled = true };

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
        var model = new Anrok { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Anrok>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Anrok { TaxExempt = true, AutomaticTaxEnabled = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Anrok>(element);
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
        var model = new Anrok { TaxExempt = true, AutomaticTaxEnabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Anrok { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Anrok { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Anrok
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
        var model = new Anrok
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}

public class StripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Stripe { TaxExempt = true, AutomaticTaxEnabled = true };

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
        var model = new Stripe { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Stripe>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Stripe { TaxExempt = true, AutomaticTaxEnabled = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Stripe>(element);
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
        var model = new Stripe { TaxExempt = true, AutomaticTaxEnabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Stripe { TaxExempt = true };

        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Stripe { TaxExempt = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Stripe
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
        var model = new Stripe
        {
            TaxExempt = true,

            AutomaticTaxEnabled = null,
        };

        model.Validate();
    }
}
