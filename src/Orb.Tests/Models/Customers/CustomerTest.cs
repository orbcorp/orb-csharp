using System;
using System.Collections.Generic;
using Orb.Core;
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
                        ProviderType = ProviderType.Quickbooks,
                    },
                ],
                Excluded = true,
            },
            AutomaticTaxEnabled = true,
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
                    ProviderType = ProviderType.Quickbooks,
                },
            ],
            Excluded = true,
        };
        bool expectedAutomaticTaxEnabled = true;
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
        Assert.Equal(expectedReportingConfiguration, model.ReportingConfiguration);
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
                    ProviderType = ProviderType.Quickbooks,
                },
            ],
            Excluded = true,
        };

        List<AccountingProvider> expectedAccountingProviders =
        [
            new()
            {
                ExternalProviderID = "external_provider_id",
                ProviderType = ProviderType.Quickbooks,
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
}

public class AccountingProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountingProvider
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = ProviderType.Quickbooks,
        };

        string expectedExternalProviderID = "external_provider_id";
        ApiEnum<string, ProviderType> expectedProviderType = ProviderType.Quickbooks;

        Assert.Equal(expectedExternalProviderID, model.ExternalProviderID);
        Assert.Equal(expectedProviderType, model.ProviderType);
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
}
