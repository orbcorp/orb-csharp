using System;
using System.Threading.Tasks;
using Orb.Models.Customers;
using Orb.Models.Customers.CustomerCreateParamsProperties;
using Orb.Models.Customers.NewAvalaraTaxConfigurationProperties;
using CustomerTaxIDProperties = Orb.Models.CustomerTaxIDProperties;
using CustomerUpdateByExternalIDParamsProperties = Orb.Models.Customers.CustomerUpdateByExternalIDParamsProperties;
using CustomerUpdateParamsProperties = Orb.Models.Customers.CustomerUpdateParamsProperties;

namespace Orb.Tests.Services.Customers;

public class CustomerServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var customer = await this.client.Customers.Create(
            new()
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
                    ChildCustomerIDs = ["string"],
                    ParentCustomerID = "parent_customer_id",
                },
                Metadata = new() { { "foo", "string" } },
                PaymentProvider = PaymentProvider.Quickbooks,
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
                    TaxExemptionCode = "tax_exemption_code",
                },
                TaxID = new()
                {
                    Country = CustomerTaxIDProperties::Country.Ad,
                    Type = CustomerTaxIDProperties::Type.AdNrt,
                    Value = "value",
                },
                Timezone = "timezone",
            }
        );
        customer.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var customer = await this.client.Customers.Update(
            new()
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
                    ChildCustomerIDs = ["string"],
                    ParentCustomerID = "parent_customer_id",
                },
                Metadata = new() { { "foo", "string" } },
                Name = "name",
                PaymentProvider = CustomerUpdateParamsProperties::PaymentProvider.Quickbooks,
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
                    TaxExemptionCode = "tax_exemption_code",
                },
                TaxID = new()
                {
                    Country = CustomerTaxIDProperties::Country.Ad,
                    Type = CustomerTaxIDProperties::Type.AdNrt,
                    Value = "value",
                },
            }
        );
        customer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.List(
            new()
            {
                CreatedAtGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                Limit = 1,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Customers.Delete(new() { CustomerID = "customer_id" });
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var customer = await this.client.Customers.Fetch(new() { CustomerID = "customer_id" });
        customer.Validate();
    }

    [Fact]
    public async Task FetchByExternalID_Works()
    {
        var customer = await this.client.Customers.FetchByExternalID(
            new() { ExternalCustomerID = "external_customer_id" }
        );
        customer.Validate();
    }

    [Fact]
    public async Task SyncPaymentMethodsFromGateway_Works()
    {
        await this.client.Customers.SyncPaymentMethodsFromGateway(
            new() { CustomerID = "customer_id" }
        );
    }

    [Fact]
    public async Task SyncPaymentMethodsFromGatewayByExternalCustomerID_Works()
    {
        await this.client.Customers.SyncPaymentMethodsFromGatewayByExternalCustomerID(
            new() { ExternalCustomerID = "external_customer_id" }
        );
    }

    [Fact]
    public async Task UpdateByExternalID_Works()
    {
        var customer = await this.client.Customers.UpdateByExternalID(
            new()
            {
                ID = "external_customer_id",
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
                    ChildCustomerIDs = ["string"],
                    ParentCustomerID = "parent_customer_id",
                },
                Metadata = new() { { "foo", "string" } },
                Name = "name",
                PaymentProvider =
                    CustomerUpdateByExternalIDParamsProperties::PaymentProvider.Quickbooks,
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
                    TaxExemptionCode = "tax_exemption_code",
                },
                TaxID = new()
                {
                    Country = CustomerTaxIDProperties::Country.Ad,
                    Type = CustomerTaxIDProperties::Type.AdNrt,
                    Value = "value",
                },
            }
        );
        customer.Validate();
    }
}
