using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            CustomerID = "customer_id",
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
            AdditionalEmails = ["string"],
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
            Email = "dev@stainless.com",
            EmailDelivery = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                ChildCustomerIds = ["string"],
                ParentCustomerID = "parent_customer_id",
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "name",
            PaymentConfiguration = new()
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
            },
            PaymentProvider = CustomerUpdateParamsPaymentProvider.Quickbooks,
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
                Country = Country.Ad,
                Type = CustomerTaxIDType.AdNrt,
                Value = "value",
            },
        };

        string expectedCustomerID = "customer_id";
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
        List<string> expectedAdditionalEmails = ["string"];
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
        string expectedEmail = "dev@stainless.com";
        bool expectedEmailDelivery = true;
        string expectedExternalCustomerID = "external_customer_id";
        CustomerHierarchyConfig expectedHierarchy = new()
        {
            ChildCustomerIds = ["string"],
            ParentCustomerID = "parent_customer_id",
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        CustomerUpdateParamsPaymentConfiguration expectedPaymentConfiguration = new()
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
        ApiEnum<string, CustomerUpdateParamsPaymentProvider> expectedPaymentProvider =
            CustomerUpdateParamsPaymentProvider.Quickbooks;
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
        CustomerUpdateParamsTaxConfiguration expectedTaxConfiguration =
            new NewAvalaraTaxConfiguration()
            {
                TaxExempt = true,
                TaxProvider = TaxProvider.Avalara,
                AutomaticTaxEnabled = true,
                TaxExemptionCode = "tax_exemption_code",
            };
        CustomerTaxID expectedTaxID = new()
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
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
        Assert.Equal(expectedEmail, parameters.Email);
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
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPaymentConfiguration, parameters.PaymentConfiguration);
        Assert.Equal(expectedPaymentProvider, parameters.PaymentProvider);
        Assert.Equal(expectedPaymentProviderID, parameters.PaymentProviderID);
        Assert.Equal(expectedReportingConfiguration, parameters.ReportingConfiguration);
        Assert.Equal(expectedShippingAddress, parameters.ShippingAddress);
        Assert.Equal(expectedTaxConfiguration, parameters.TaxConfiguration);
        Assert.Equal(expectedTaxID, parameters.TaxID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerUpdateParams { CustomerID = "customer_id" };

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
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.EmailDelivery);
        Assert.False(parameters.RawBodyData.ContainsKey("email_delivery"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.Hierarchy);
        Assert.False(parameters.RawBodyData.ContainsKey("hierarchy"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
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
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            CustomerID = "customer_id",

            AccountingSyncConfiguration = null,
            AdditionalEmails = null,
            AutoCollection = null,
            AutoIssuance = null,
            BillingAddress = null,
            Currency = null,
            Email = null,
            EmailDelivery = null,
            ExternalCustomerID = null,
            Hierarchy = null,
            Metadata = null,
            Name = null,
            PaymentConfiguration = null,
            PaymentProvider = null,
            PaymentProviderID = null,
            ReportingConfiguration = null,
            ShippingAddress = null,
            TaxConfiguration = null,
            TaxID = null,
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
        Assert.Null(parameters.Email);
        Assert.True(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.EmailDelivery);
        Assert.True(parameters.RawBodyData.ContainsKey("email_delivery"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.Hierarchy);
        Assert.True(parameters.RawBodyData.ContainsKey("hierarchy"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
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
    }

    [Fact]
    public void Url_Works()
    {
        CustomerUpdateParams parameters = new() { CustomerID = "customer_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/customers/customer_id"), url);
    }
}

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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("numeral");
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
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("numeral");
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
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("anrok");
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
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("anrok");
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
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("stripe");
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
        JsonElement expectedTaxProvider = JsonSerializer.SerializeToElement("stripe");
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
