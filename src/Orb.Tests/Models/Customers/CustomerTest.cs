using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customer
        {
            ID = "id",
            AdditionalEmails = ["string"],
            AutoCollection = true,
            AutoIssuance = true,
            Balance = "balance",
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Email = "email",
            EmailDelivery = true,
            ExemptFromAutomatedTax = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
                Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PaymentProvider = CustomerPaymentProvider.Quickbooks,
            PaymentProviderID = "payment_provider_id",
            PortalURL = "portal_url",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            TaxID = new()
            {
                Country = Country.Ad,
                Type = CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Timezone = "timezone",
            AccountingSyncConfiguration = new()
            {
                AccountingProviders =
                [
                    new()
                    {
                        ExternalProviderID = "external_provider_id",
                        ProviderType = AccountingProviderProviderType.Quickbooks,
                    },
                ],
                Excluded = true,
            },
            AutomaticTaxEnabled = true,
            PaymentConfiguration = new()
            {
                PaymentProviders =
                [
                    new()
                    {
                        ProviderType =
                            CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                        ExcludedPaymentMethodTypes = ["string"],
                    },
                ],
            },
            ReportingConfiguration = new(true),
        };

        string expectedID = "id";
        List<string> expectedAdditionalEmails = ["string"];
        bool expectedAutoCollection = true;
        bool expectedAutoIssuance = true;
        string expectedBalance = "balance";
        Address expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedEmail = "email";
        bool expectedEmailDelivery = true;
        bool expectedExemptFromAutomatedTax = true;
        string expectedExternalCustomerID = "external_customer_id";
        Hierarchy expectedHierarchy = new()
        {
            Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
            Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        ApiEnum<string, CustomerPaymentProvider> expectedPaymentProvider =
            CustomerPaymentProvider.Quickbooks;
        string expectedPaymentProviderID = "payment_provider_id";
        string expectedPortalURL = "portal_url";
        Address expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        CustomerTaxID expectedTaxID = new()
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };
        string expectedTimezone = "timezone";
        AccountingSyncConfiguration expectedAccountingSyncConfiguration = new()
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = AccountingProviderProviderType.Quickbooks,
                },
            ],
            Excluded = true,
        };
        bool expectedAutomaticTaxEnabled = true;
        CustomerPaymentConfiguration expectedPaymentConfiguration = new()
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };
        ReportingConfiguration expectedReportingConfiguration = new(true);

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdditionalEmails.Count, model.AdditionalEmails.Count);
        for (int i = 0; i < expectedAdditionalEmails.Count; i++)
        {
            Assert.Equal(expectedAdditionalEmails[i], model.AdditionalEmails[i]);
        }
        Assert.Equal(expectedAutoCollection, model.AutoCollection);
        Assert.Equal(expectedAutoIssuance, model.AutoIssuance);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedEmailDelivery, model.EmailDelivery);
        Assert.Equal(expectedExemptFromAutomatedTax, model.ExemptFromAutomatedTax);
        Assert.Equal(expectedExternalCustomerID, model.ExternalCustomerID);
        Assert.Equal(expectedHierarchy, model.Hierarchy);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPaymentProvider, model.PaymentProvider);
        Assert.Equal(expectedPaymentProviderID, model.PaymentProviderID);
        Assert.Equal(expectedPortalURL, model.PortalURL);
        Assert.Equal(expectedShippingAddress, model.ShippingAddress);
        Assert.Equal(expectedTaxID, model.TaxID);
        Assert.Equal(expectedTimezone, model.Timezone);
        Assert.Equal(expectedAccountingSyncConfiguration, model.AccountingSyncConfiguration);
        Assert.Equal(expectedAutomaticTaxEnabled, model.AutomaticTaxEnabled);
        Assert.Equal(expectedPaymentConfiguration, model.PaymentConfiguration);
        Assert.Equal(expectedReportingConfiguration, model.ReportingConfiguration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Customer
        {
            ID = "id",
            AdditionalEmails = ["string"],
            AutoCollection = true,
            AutoIssuance = true,
            Balance = "balance",
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Email = "email",
            EmailDelivery = true,
            ExemptFromAutomatedTax = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
                Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PaymentProvider = CustomerPaymentProvider.Quickbooks,
            PaymentProviderID = "payment_provider_id",
            PortalURL = "portal_url",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            TaxID = new()
            {
                Country = Country.Ad,
                Type = CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Timezone = "timezone",
            AccountingSyncConfiguration = new()
            {
                AccountingProviders =
                [
                    new()
                    {
                        ExternalProviderID = "external_provider_id",
                        ProviderType = AccountingProviderProviderType.Quickbooks,
                    },
                ],
                Excluded = true,
            },
            AutomaticTaxEnabled = true,
            PaymentConfiguration = new()
            {
                PaymentProviders =
                [
                    new()
                    {
                        ProviderType =
                            CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                        ExcludedPaymentMethodTypes = ["string"],
                    },
                ],
            },
            ReportingConfiguration = new(true),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Customer>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customer
        {
            ID = "id",
            AdditionalEmails = ["string"],
            AutoCollection = true,
            AutoIssuance = true,
            Balance = "balance",
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Email = "email",
            EmailDelivery = true,
            ExemptFromAutomatedTax = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
                Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PaymentProvider = CustomerPaymentProvider.Quickbooks,
            PaymentProviderID = "payment_provider_id",
            PortalURL = "portal_url",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            TaxID = new()
            {
                Country = Country.Ad,
                Type = CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Timezone = "timezone",
            AccountingSyncConfiguration = new()
            {
                AccountingProviders =
                [
                    new()
                    {
                        ExternalProviderID = "external_provider_id",
                        ProviderType = AccountingProviderProviderType.Quickbooks,
                    },
                ],
                Excluded = true,
            },
            AutomaticTaxEnabled = true,
            PaymentConfiguration = new()
            {
                PaymentProviders =
                [
                    new()
                    {
                        ProviderType =
                            CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                        ExcludedPaymentMethodTypes = ["string"],
                    },
                ],
            },
            ReportingConfiguration = new(true),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Customer>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<string> expectedAdditionalEmails = ["string"];
        bool expectedAutoCollection = true;
        bool expectedAutoIssuance = true;
        string expectedBalance = "balance";
        Address expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedEmail = "email";
        bool expectedEmailDelivery = true;
        bool expectedExemptFromAutomatedTax = true;
        string expectedExternalCustomerID = "external_customer_id";
        Hierarchy expectedHierarchy = new()
        {
            Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
            Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        ApiEnum<string, CustomerPaymentProvider> expectedPaymentProvider =
            CustomerPaymentProvider.Quickbooks;
        string expectedPaymentProviderID = "payment_provider_id";
        string expectedPortalURL = "portal_url";
        Address expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        CustomerTaxID expectedTaxID = new()
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };
        string expectedTimezone = "timezone";
        AccountingSyncConfiguration expectedAccountingSyncConfiguration = new()
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = AccountingProviderProviderType.Quickbooks,
                },
            ],
            Excluded = true,
        };
        bool expectedAutomaticTaxEnabled = true;
        CustomerPaymentConfiguration expectedPaymentConfiguration = new()
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };
        ReportingConfiguration expectedReportingConfiguration = new(true);

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdditionalEmails.Count, deserialized.AdditionalEmails.Count);
        for (int i = 0; i < expectedAdditionalEmails.Count; i++)
        {
            Assert.Equal(expectedAdditionalEmails[i], deserialized.AdditionalEmails[i]);
        }
        Assert.Equal(expectedAutoCollection, deserialized.AutoCollection);
        Assert.Equal(expectedAutoIssuance, deserialized.AutoIssuance);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedEmailDelivery, deserialized.EmailDelivery);
        Assert.Equal(expectedExemptFromAutomatedTax, deserialized.ExemptFromAutomatedTax);
        Assert.Equal(expectedExternalCustomerID, deserialized.ExternalCustomerID);
        Assert.Equal(expectedHierarchy, deserialized.Hierarchy);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPaymentProvider, deserialized.PaymentProvider);
        Assert.Equal(expectedPaymentProviderID, deserialized.PaymentProviderID);
        Assert.Equal(expectedPortalURL, deserialized.PortalURL);
        Assert.Equal(expectedShippingAddress, deserialized.ShippingAddress);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
        Assert.Equal(expectedAccountingSyncConfiguration, deserialized.AccountingSyncConfiguration);
        Assert.Equal(expectedAutomaticTaxEnabled, deserialized.AutomaticTaxEnabled);
        Assert.Equal(expectedPaymentConfiguration, deserialized.PaymentConfiguration);
        Assert.Equal(expectedReportingConfiguration, deserialized.ReportingConfiguration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Customer
        {
            ID = "id",
            AdditionalEmails = ["string"],
            AutoCollection = true,
            AutoIssuance = true,
            Balance = "balance",
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Email = "email",
            EmailDelivery = true,
            ExemptFromAutomatedTax = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
                Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PaymentProvider = CustomerPaymentProvider.Quickbooks,
            PaymentProviderID = "payment_provider_id",
            PortalURL = "portal_url",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            TaxID = new()
            {
                Country = Country.Ad,
                Type = CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Timezone = "timezone",
            AccountingSyncConfiguration = new()
            {
                AccountingProviders =
                [
                    new()
                    {
                        ExternalProviderID = "external_provider_id",
                        ProviderType = AccountingProviderProviderType.Quickbooks,
                    },
                ],
                Excluded = true,
            },
            AutomaticTaxEnabled = true,
            PaymentConfiguration = new()
            {
                PaymentProviders =
                [
                    new()
                    {
                        ProviderType =
                            CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                        ExcludedPaymentMethodTypes = ["string"],
                    },
                ],
            },
            ReportingConfiguration = new(true),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Customer
        {
            ID = "id",
            AdditionalEmails = ["string"],
            AutoCollection = true,
            AutoIssuance = true,
            Balance = "balance",
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Email = "email",
            EmailDelivery = true,
            ExemptFromAutomatedTax = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
                Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PaymentProvider = CustomerPaymentProvider.Quickbooks,
            PaymentProviderID = "payment_provider_id",
            PortalURL = "portal_url",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            TaxID = new()
            {
                Country = Country.Ad,
                Type = CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Timezone = "timezone",
        };

        Assert.Null(model.AccountingSyncConfiguration);
        Assert.False(model.RawData.ContainsKey("accounting_sync_configuration"));
        Assert.Null(model.AutomaticTaxEnabled);
        Assert.False(model.RawData.ContainsKey("automatic_tax_enabled"));
        Assert.Null(model.PaymentConfiguration);
        Assert.False(model.RawData.ContainsKey("payment_configuration"));
        Assert.Null(model.ReportingConfiguration);
        Assert.False(model.RawData.ContainsKey("reporting_configuration"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Customer
        {
            ID = "id",
            AdditionalEmails = ["string"],
            AutoCollection = true,
            AutoIssuance = true,
            Balance = "balance",
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Email = "email",
            EmailDelivery = true,
            ExemptFromAutomatedTax = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
                Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PaymentProvider = CustomerPaymentProvider.Quickbooks,
            PaymentProviderID = "payment_provider_id",
            PortalURL = "portal_url",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            TaxID = new()
            {
                Country = Country.Ad,
                Type = CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Timezone = "timezone",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Customer
        {
            ID = "id",
            AdditionalEmails = ["string"],
            AutoCollection = true,
            AutoIssuance = true,
            Balance = "balance",
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Email = "email",
            EmailDelivery = true,
            ExemptFromAutomatedTax = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
                Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PaymentProvider = CustomerPaymentProvider.Quickbooks,
            PaymentProviderID = "payment_provider_id",
            PortalURL = "portal_url",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            TaxID = new()
            {
                Country = Country.Ad,
                Type = CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Timezone = "timezone",

            AccountingSyncConfiguration = null,
            AutomaticTaxEnabled = null,
            PaymentConfiguration = null,
            ReportingConfiguration = null,
        };

        Assert.Null(model.AccountingSyncConfiguration);
        Assert.True(model.RawData.ContainsKey("accounting_sync_configuration"));
        Assert.Null(model.AutomaticTaxEnabled);
        Assert.True(model.RawData.ContainsKey("automatic_tax_enabled"));
        Assert.Null(model.PaymentConfiguration);
        Assert.True(model.RawData.ContainsKey("payment_configuration"));
        Assert.Null(model.ReportingConfiguration);
        Assert.True(model.RawData.ContainsKey("reporting_configuration"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Customer
        {
            ID = "id",
            AdditionalEmails = ["string"],
            AutoCollection = true,
            AutoIssuance = true,
            Balance = "balance",
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Email = "email",
            EmailDelivery = true,
            ExemptFromAutomatedTax = true,
            ExternalCustomerID = "external_customer_id",
            Hierarchy = new()
            {
                Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
                Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PaymentProvider = CustomerPaymentProvider.Quickbooks,
            PaymentProviderID = "payment_provider_id",
            PortalURL = "portal_url",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            TaxID = new()
            {
                Country = Country.Ad,
                Type = CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Timezone = "timezone",

            AccountingSyncConfiguration = null,
            AutomaticTaxEnabled = null,
            PaymentConfiguration = null,
            ReportingConfiguration = null,
        };

        model.Validate();
    }
}

public class HierarchyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Hierarchy
        {
            Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
            Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
        };

        List<CustomerMinified> expectedChildren =
        [
            new() { ID = "id", ExternalCustomerID = "external_customer_id" },
        ];
        CustomerMinified expectedParent = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };

        Assert.Equal(expectedChildren.Count, model.Children.Count);
        for (int i = 0; i < expectedChildren.Count; i++)
        {
            Assert.Equal(expectedChildren[i], model.Children[i]);
        }
        Assert.Equal(expectedParent, model.Parent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Hierarchy
        {
            Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
            Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Hierarchy>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Hierarchy
        {
            Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
            Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Hierarchy>(element);
        Assert.NotNull(deserialized);

        List<CustomerMinified> expectedChildren =
        [
            new() { ID = "id", ExternalCustomerID = "external_customer_id" },
        ];
        CustomerMinified expectedParent = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };

        Assert.Equal(expectedChildren.Count, deserialized.Children.Count);
        for (int i = 0; i < expectedChildren.Count; i++)
        {
            Assert.Equal(expectedChildren[i], deserialized.Children[i]);
        }
        Assert.Equal(expectedParent, deserialized.Parent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Hierarchy
        {
            Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
            Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
        };

        model.Validate();
    }
}

public class CustomerPaymentProviderTest : TestBase
{
    [Theory]
    [InlineData(CustomerPaymentProvider.Quickbooks)]
    [InlineData(CustomerPaymentProvider.BillCom)]
    [InlineData(CustomerPaymentProvider.StripeCharge)]
    [InlineData(CustomerPaymentProvider.StripeInvoice)]
    [InlineData(CustomerPaymentProvider.Netsuite)]
    public void Validation_Works(CustomerPaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerPaymentProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomerPaymentProvider>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerPaymentProvider.Quickbooks)]
    [InlineData(CustomerPaymentProvider.BillCom)]
    [InlineData(CustomerPaymentProvider.StripeCharge)]
    [InlineData(CustomerPaymentProvider.StripeInvoice)]
    [InlineData(CustomerPaymentProvider.Netsuite)]
    public void SerializationRoundtrip_Works(CustomerPaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerPaymentProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CustomerPaymentProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomerPaymentProvider>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CustomerPaymentProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AccountingSyncConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountingSyncConfiguration
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = AccountingProviderProviderType.Quickbooks,
                },
            ],
            Excluded = true,
        };

        List<AccountingProvider> expectedAccountingProviders =
        [
            new()
            {
                ExternalProviderID = "external_provider_id",
                ProviderType = AccountingProviderProviderType.Quickbooks,
            },
        ];
        bool expectedExcluded = true;

        Assert.Equal(expectedAccountingProviders.Count, model.AccountingProviders.Count);
        for (int i = 0; i < expectedAccountingProviders.Count; i++)
        {
            Assert.Equal(expectedAccountingProviders[i], model.AccountingProviders[i]);
        }
        Assert.Equal(expectedExcluded, model.Excluded);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountingSyncConfiguration
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = AccountingProviderProviderType.Quickbooks,
                },
            ],
            Excluded = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AccountingSyncConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountingSyncConfiguration
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = AccountingProviderProviderType.Quickbooks,
                },
            ],
            Excluded = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AccountingSyncConfiguration>(element);
        Assert.NotNull(deserialized);

        List<AccountingProvider> expectedAccountingProviders =
        [
            new()
            {
                ExternalProviderID = "external_provider_id",
                ProviderType = AccountingProviderProviderType.Quickbooks,
            },
        ];
        bool expectedExcluded = true;

        Assert.Equal(expectedAccountingProviders.Count, deserialized.AccountingProviders.Count);
        for (int i = 0; i < expectedAccountingProviders.Count; i++)
        {
            Assert.Equal(expectedAccountingProviders[i], deserialized.AccountingProviders[i]);
        }
        Assert.Equal(expectedExcluded, deserialized.Excluded);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountingSyncConfiguration
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = AccountingProviderProviderType.Quickbooks,
                },
            ],
            Excluded = true,
        };

        model.Validate();
    }
}

public class AccountingProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountingProvider
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = AccountingProviderProviderType.Quickbooks,
        };

        string expectedExternalProviderID = "external_provider_id";
        ApiEnum<string, AccountingProviderProviderType> expectedProviderType =
            AccountingProviderProviderType.Quickbooks;

        Assert.Equal(expectedExternalProviderID, model.ExternalProviderID);
        Assert.Equal(expectedProviderType, model.ProviderType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountingProvider
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = AccountingProviderProviderType.Quickbooks,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AccountingProvider>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountingProvider
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = AccountingProviderProviderType.Quickbooks,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AccountingProvider>(element);
        Assert.NotNull(deserialized);

        string expectedExternalProviderID = "external_provider_id";
        ApiEnum<string, AccountingProviderProviderType> expectedProviderType =
            AccountingProviderProviderType.Quickbooks;

        Assert.Equal(expectedExternalProviderID, deserialized.ExternalProviderID);
        Assert.Equal(expectedProviderType, deserialized.ProviderType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountingProvider
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = AccountingProviderProviderType.Quickbooks,
        };

        model.Validate();
    }
}

public class AccountingProviderProviderTypeTest : TestBase
{
    [Theory]
    [InlineData(AccountingProviderProviderType.Quickbooks)]
    [InlineData(AccountingProviderProviderType.Netsuite)]
    public void Validation_Works(AccountingProviderProviderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountingProviderProviderType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountingProviderProviderType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountingProviderProviderType.Quickbooks)]
    [InlineData(AccountingProviderProviderType.Netsuite)]
    public void SerializationRoundtrip_Works(AccountingProviderProviderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountingProviderProviderType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountingProviderProviderType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountingProviderProviderType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountingProviderProviderType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerPaymentConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        List<CustomerPaymentConfigurationPaymentProvider> expectedPaymentProviders =
        [
            new()
            {
                ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
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
        var model = new CustomerPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerPaymentConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerPaymentConfiguration>(element);
        Assert.NotNull(deserialized);

        List<CustomerPaymentConfigurationPaymentProvider> expectedPaymentProviders =
        [
            new()
            {
                ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
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
        var model = new CustomerPaymentConfiguration
        {
            PaymentProviders =
            [
                new()
                {
                    ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                    ExcludedPaymentMethodTypes = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerPaymentConfiguration { };

        Assert.Null(model.PaymentProviders);
        Assert.False(model.RawData.ContainsKey("payment_providers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerPaymentConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerPaymentConfiguration
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
        var model = new CustomerPaymentConfiguration
        {
            // Null should be interpreted as omitted for these properties
            PaymentProviders = null,
        };

        model.Validate();
    }
}

public class CustomerPaymentConfigurationPaymentProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerPaymentConfigurationPaymentProvider
        {
            ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        ApiEnum<
            string,
            CustomerPaymentConfigurationPaymentProviderProviderType
        > expectedProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe;
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
        var model = new CustomerPaymentConfigurationPaymentProvider
        {
            ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerPaymentConfigurationPaymentProvider>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerPaymentConfigurationPaymentProvider
        {
            ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerPaymentConfigurationPaymentProvider>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            CustomerPaymentConfigurationPaymentProviderProviderType
        > expectedProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe;
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
        var model = new CustomerPaymentConfigurationPaymentProvider
        {
            ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
            ExcludedPaymentMethodTypes = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerPaymentConfigurationPaymentProvider
        {
            ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
        };

        Assert.Null(model.ExcludedPaymentMethodTypes);
        Assert.False(model.RawData.ContainsKey("excluded_payment_method_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerPaymentConfigurationPaymentProvider
        {
            ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerPaymentConfigurationPaymentProvider
        {
            ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,

            // Null should be interpreted as omitted for these properties
            ExcludedPaymentMethodTypes = null,
        };

        Assert.Null(model.ExcludedPaymentMethodTypes);
        Assert.False(model.RawData.ContainsKey("excluded_payment_method_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerPaymentConfigurationPaymentProvider
        {
            ProviderType = CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,

            // Null should be interpreted as omitted for these properties
            ExcludedPaymentMethodTypes = null,
        };

        model.Validate();
    }
}

public class CustomerPaymentConfigurationPaymentProviderProviderTypeTest : TestBase
{
    [Theory]
    [InlineData(CustomerPaymentConfigurationPaymentProviderProviderType.Stripe)]
    public void Validation_Works(CustomerPaymentConfigurationPaymentProviderProviderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerPaymentConfigurationPaymentProviderProviderType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerPaymentConfigurationPaymentProviderProviderType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerPaymentConfigurationPaymentProviderProviderType.Stripe)]
    public void SerializationRoundtrip_Works(
        CustomerPaymentConfigurationPaymentProviderProviderType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerPaymentConfigurationPaymentProviderProviderType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerPaymentConfigurationPaymentProviderProviderType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerPaymentConfigurationPaymentProviderProviderType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerPaymentConfigurationPaymentProviderProviderType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReportingConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportingConfiguration { Exempt = true };

        bool expectedExempt = true;

        Assert.Equal(expectedExempt, model.Exempt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportingConfiguration { Exempt = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReportingConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportingConfiguration { Exempt = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReportingConfiguration>(element);
        Assert.NotNull(deserialized);

        bool expectedExempt = true;

        Assert.Equal(expectedExempt, deserialized.Exempt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportingConfiguration { Exempt = true };

        model.Validate();
    }
}
