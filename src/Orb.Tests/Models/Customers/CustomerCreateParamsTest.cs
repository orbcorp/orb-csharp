using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers;
using Models = Orb.Models;

namespace Orb.Tests.Models.Customers;

public class CustomerCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerCreateParams
        {
            Email = "dev@stainless.com",
            Name = "x",
            AccountingSyncConfiguration = new()
            {
                AccountingProviders =
                [
                    new()
                    {
                        ExternalProviderID = "external_provider_id",
                        ProviderType = "provider_type",
                    },
                ],
                Excluded = true,
            },
            AdditionalEmails = ["dev@stainless.com"],
            AutoCollection = true,
            AutoIssuance = true,
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            Currency = "currency",
            EmailDelivery = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                ChildCustomerIds = ["string"],
                ParentCustomerID = "parent_customer_id",
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PaymentConfiguration = new()
            {
                PaymentProviders =
                [
                    new()
                    {
                        ProviderType = ProviderType.Stripe,
                        ExcludedPaymentMethodTypes = ["string"],
                    },
                ],
            },
            PaymentProvider = CustomerCreateParamsPaymentProvider.Quickbooks,
            PaymentProviderID = "payment_provider_id",
            ReportingConfiguration = new(true),
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            TaxConfiguration = new NewAvalaraTaxConfiguration()
            {
                TaxExempt = true,
                TaxProvider = TaxProvider.Avalara,
                AutomaticTaxEnabled = true,
                TaxExemptionCode = "tax_exemption_code",
            },
            TaxID = new()
            {
                Country = Models::Country.Ad,
                Type = Models::CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Timezone = "timezone",
        };

        string expectedEmail = "dev@stainless.com";
        string expectedName = "x";
        NewAccountingSyncConfiguration expectedAccountingSyncConfiguration = new()
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = "provider_type",
                },
            ],
            Excluded = true,
        };
        List<string> expectedAdditionalEmails = ["dev@stainless.com"];
        bool expectedAutoCollection = true;
        bool expectedAutoIssuance = true;
        AddressInput expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        string expectedCurrency = "currency";
        bool expectedEmailDelivery = true;
        string expectedExternalCustomerID = "external_customer_id";
        CustomerHierarchyConfig expectedHierarchy = new()
        {
            ChildCustomerIds = ["string"],
            ParentCustomerID = "parent_customer_id",
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        PaymentConfiguration expectedPaymentConfiguration = new()
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
        ApiEnum<string, CustomerCreateParamsPaymentProvider> expectedPaymentProvider =
            CustomerCreateParamsPaymentProvider.Quickbooks;
        string expectedPaymentProviderID = "payment_provider_id";
        NewReportingConfiguration expectedReportingConfiguration = new(true);
        AddressInput expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        TaxConfiguration expectedTaxConfiguration = new NewAvalaraTaxConfiguration()
        {
            TaxExempt = true,
            TaxProvider = TaxProvider.Avalara,
            AutomaticTaxEnabled = true,
            TaxExemptionCode = "tax_exemption_code",
        };
        Models::CustomerTaxID expectedTaxID = new()
        {
            Country = Models::Country.Ad,
            Type = Models::CustomerTaxIDType.AdNrt,
            Value = "value",
        };
        string expectedTimezone = "timezone";

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedAccountingSyncConfiguration, parameters.AccountingSyncConfiguration);
        Assert.NotNull(parameters.AdditionalEmails);
        Assert.Equal(expectedAdditionalEmails.Count, parameters.AdditionalEmails.Count);
        for (int i = 0; i < expectedAdditionalEmails.Count; i++)
        {
            Assert.Equal(expectedAdditionalEmails[i], parameters.AdditionalEmails[i]);
        }
        Assert.Equal(expectedAutoCollection, parameters.AutoCollection);
        Assert.Equal(expectedAutoIssuance, parameters.AutoIssuance);
        Assert.Equal(expectedBillingAddress, parameters.BillingAddress);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedEmailDelivery, parameters.EmailDelivery);
        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
        Assert.Equal(expectedHierarchy, parameters.Hierarchy);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentConfiguration, parameters.PaymentConfiguration);
        Assert.Equal(expectedPaymentProvider, parameters.PaymentProvider);
        Assert.Equal(expectedPaymentProviderID, parameters.PaymentProviderID);
        Assert.Equal(expectedReportingConfiguration, parameters.ReportingConfiguration);
        Assert.Equal(expectedShippingAddress, parameters.ShippingAddress);
        Assert.Equal(expectedTaxConfiguration, parameters.TaxConfiguration);
        Assert.Equal(expectedTaxID, parameters.TaxID);
        Assert.Equal(expectedTimezone, parameters.Timezone);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerCreateParams { Email = "dev@stainless.com", Name = "x" };

        Assert.Null(parameters.AccountingSyncConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("accounting_sync_configuration"));
        Assert.Null(parameters.AdditionalEmails);
        Assert.False(parameters.RawBodyData.ContainsKey("additional_emails"));
        Assert.Null(parameters.AutoCollection);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_collection"));
        Assert.Null(parameters.AutoIssuance);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_issuance"));
        Assert.Null(parameters.BillingAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.EmailDelivery);
        Assert.False(parameters.RawBodyData.ContainsKey("email_delivery"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.Hierarchy);
        Assert.False(parameters.RawBodyData.ContainsKey("hierarchy"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_configuration"));
        Assert.Null(parameters.PaymentProvider);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_provider"));
        Assert.Null(parameters.PaymentProviderID);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_provider_id"));
        Assert.Null(parameters.ReportingConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("reporting_configuration"));
        Assert.Null(parameters.ShippingAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("shipping_address"));
        Assert.Null(parameters.TaxConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_configuration"));
        Assert.Null(parameters.TaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_id"));
        Assert.Null(parameters.Timezone);
        Assert.False(parameters.RawBodyData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CustomerCreateParams
        {
            Email = "dev@stainless.com",
            Name = "x",

            AccountingSyncConfiguration = null,
            AdditionalEmails = null,
            AutoCollection = null,
            AutoIssuance = null,
            BillingAddress = null,
            Currency = null,
            EmailDelivery = null,
            ExternalCustomerID = null,
            Hierarchy = null,
            Metadata = null,
            PaymentConfiguration = null,
            PaymentProvider = null,
            PaymentProviderID = null,
            ReportingConfiguration = null,
            ShippingAddress = null,
            TaxConfiguration = null,
            TaxID = null,
            Timezone = null,
        };

        Assert.Null(parameters.AccountingSyncConfiguration);
        Assert.True(parameters.RawBodyData.ContainsKey("accounting_sync_configuration"));
        Assert.Null(parameters.AdditionalEmails);
        Assert.True(parameters.RawBodyData.ContainsKey("additional_emails"));
        Assert.Null(parameters.AutoCollection);
        Assert.True(parameters.RawBodyData.ContainsKey("auto_collection"));
        Assert.Null(parameters.AutoIssuance);
        Assert.True(parameters.RawBodyData.ContainsKey("auto_issuance"));
        Assert.Null(parameters.BillingAddress);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.EmailDelivery);
        Assert.True(parameters.RawBodyData.ContainsKey("email_delivery"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.Hierarchy);
        Assert.True(parameters.RawBodyData.ContainsKey("hierarchy"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentConfiguration);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_configuration"));
        Assert.Null(parameters.PaymentProvider);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_provider"));
        Assert.Null(parameters.PaymentProviderID);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_provider_id"));
        Assert.Null(parameters.ReportingConfiguration);
        Assert.True(parameters.RawBodyData.ContainsKey("reporting_configuration"));
        Assert.Null(parameters.ShippingAddress);
        Assert.True(parameters.RawBodyData.ContainsKey("shipping_address"));
        Assert.Null(parameters.TaxConfiguration);
        Assert.True(parameters.RawBodyData.ContainsKey("tax_configuration"));
        Assert.Null(parameters.TaxID);
        Assert.True(parameters.RawBodyData.ContainsKey("tax_id"));
        Assert.Null(parameters.Timezone);
        Assert.True(parameters.RawBodyData.ContainsKey("timezone"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerCreateParams parameters = new() { Email = "dev@stainless.com", Name = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/customers"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerCreateParams
        {
            Email = "dev@stainless.com",
            Name = "x",
            AccountingSyncConfiguration = new()
            {
                AccountingProviders =
                [
                    new()
                    {
                        ExternalProviderID = "external_provider_id",
                        ProviderType = "provider_type",
                    },
                ],
                Excluded = true,
            },
            AdditionalEmails = ["dev@stainless.com"],
            AutoCollection = true,
            AutoIssuance = true,
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            Currency = "currency",
            EmailDelivery = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                ChildCustomerIds = ["string"],
                ParentCustomerID = "parent_customer_id",
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PaymentConfiguration = new()
            {
                PaymentProviders =
                [
                    new()
                    {
                        ProviderType = ProviderType.Stripe,
                        ExcludedPaymentMethodTypes = ["string"],
                    },
                ],
            },
            PaymentProvider = CustomerCreateParamsPaymentProvider.Quickbooks,
            PaymentProviderID = "payment_provider_id",
            ReportingConfiguration = new(true),
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            TaxConfiguration = new NewAvalaraTaxConfiguration()
            {
                TaxExempt = true,
                TaxProvider = TaxProvider.Avalara,
                AutomaticTaxEnabled = true,
                TaxExemptionCode = "tax_exemption_code",
            },
            TaxID = new()
            {
                Country = Models::Country.Ad,
                Type = Models::CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Timezone = "timezone",
        };

        CustomerCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentProvider>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentProvider>(
            element,
            ModelBase.SerializerOptions
        );
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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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
        TaxConfiguration value = new NewAvalaraTaxConfiguration()
        {
            TaxExempt = true,
            TaxProvider = TaxProvider.Avalara,
            AutomaticTaxEnabled = true,
            TaxExemptionCode = "tax_exemption_code",
        };
        value.Validate();
    }

    [Fact]
    public void NewTaxJarValidationWorks()
    {
        TaxConfiguration value = new NewTaxJarConfiguration()
        {
            TaxExempt = true,
            TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
            AutomaticTaxEnabled = true,
        };
        value.Validate();
    }

    [Fact]
    public void NewSphereValidationWorks()
    {
        TaxConfiguration value = new NewSphereConfiguration()
        {
            TaxExempt = true,
            TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
            AutomaticTaxEnabled = true,
        };
        value.Validate();
    }

    [Fact]
    public void NumeralValidationWorks()
    {
        TaxConfiguration value = new Numeral() { TaxExempt = true, AutomaticTaxEnabled = true };
        value.Validate();
    }

    [Fact]
    public void AnrokValidationWorks()
    {
        TaxConfiguration value = new Anrok() { TaxExempt = true, AutomaticTaxEnabled = true };
        value.Validate();
    }

    [Fact]
    public void StripeValidationWorks()
    {
        TaxConfiguration value = new Stripe() { TaxExempt = true, AutomaticTaxEnabled = true };
        value.Validate();
    }

    [Fact]
    public void NewAvalaraSerializationRoundtripWorks()
    {
        TaxConfiguration value = new NewAvalaraTaxConfiguration()
        {
            TaxExempt = true,
            TaxProvider = TaxProvider.Avalara,
            AutomaticTaxEnabled = true,
            TaxExemptionCode = "tax_exemption_code",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewTaxJarSerializationRoundtripWorks()
    {
        TaxConfiguration value = new NewTaxJarConfiguration()
        {
            TaxExempt = true,
            TaxProvider = NewTaxJarConfigurationTaxProvider.Taxjar,
            AutomaticTaxEnabled = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSphereSerializationRoundtripWorks()
    {
        TaxConfiguration value = new NewSphereConfiguration()
        {
            TaxExempt = true,
            TaxProvider = NewSphereConfigurationTaxProvider.Sphere,
            AutomaticTaxEnabled = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NumeralSerializationRoundtripWorks()
    {
        TaxConfiguration value = new Numeral() { TaxExempt = true, AutomaticTaxEnabled = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnrokSerializationRoundtripWorks()
    {
        TaxConfiguration value = new Anrok() { TaxExempt = true, AutomaticTaxEnabled = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StripeSerializationRoundtripWorks()
    {
        TaxConfiguration value = new Stripe() { TaxExempt = true, AutomaticTaxEnabled = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

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
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("numeral");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, model.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Numeral { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Numeral>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Numeral { TaxExempt = true, AutomaticTaxEnabled = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Numeral>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("numeral");
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
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("anrok");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, model.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Anrok { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Anrok>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Anrok { TaxExempt = true, AutomaticTaxEnabled = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Anrok>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("anrok");
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
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("stripe");
        bool expectedAutomaticTaxEnabled = true;

        Assert.Equal(expectedTaxExempt, model.TaxExempt);
        Assert.True(JsonElement.DeepEquals(expectedTaxProvider, model.TaxProvider));
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Stripe { TaxExempt = true, AutomaticTaxEnabled = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stripe>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Stripe { TaxExempt = true, AutomaticTaxEnabled = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stripe>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedTaxExempt = true;
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("stripe");
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
