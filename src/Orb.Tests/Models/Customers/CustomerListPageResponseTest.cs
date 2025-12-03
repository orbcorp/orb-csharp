using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListPageResponse
        {
            Data =
            [
                new()
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
                        Children =
                        [
                            new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        ],
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
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Customer> expectedData =
        [
            new()
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
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, model.PaginationMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListPageResponse
        {
            Data =
            [
                new()
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
                        Children =
                        [
                            new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        ],
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
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListPageResponse
        {
            Data =
            [
                new()
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
                        Children =
                        [
                            new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        ],
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
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerListPageResponse>(json);
        Assert.NotNull(deserialized);

        List<Customer> expectedData =
        [
            new()
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
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, deserialized.PaginationMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListPageResponse
        {
            Data =
            [
                new()
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
                        Children =
                        [
                            new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        ],
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
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
