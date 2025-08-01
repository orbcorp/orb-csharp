using System;
using System.Threading.Tasks;
using Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties;
using Orb.Models.Customers.Credits.Ledger.LedgerListParamsProperties;
using BodyProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties;
using LedgerListByExternalIDParamsProperties = Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDParamsProperties;

namespace Orb.Tests.Services.Customers.Credits.Ledger;

public class LedgerServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.Credits.Ledger.List(
            new()
            {
                CustomerID = "customer_id",
                CreatedAtGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                Cursor = "cursor",
                EntryStatus = EntryStatus.Committed,
                EntryType = EntryType.Increment,
                Limit = 1,
                MinimumAmount = "minimum_amount",
            }
        );
        page.Validate();
    }

    [Fact]
    public async Task CreateEntry_Works()
    {
        var response = await this.client.Customers.Credits.Ledger.CreateEntry(
            new()
            {
                CustomerID = "customer_id",
                Body = new Increment()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                    EffectiveDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        NetTerms = 0,
                        InvoiceDate = DateOnly.Parse("2019-12-27"),
                        Memo = "memo",
                        RequireSuccessfulPayment = true,
                    },
                    Metadata = new() { { "foo", "string" } },
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
            }
        );
        response.Validate();
    }

    [Fact]
    public async Task CreateEntryByExternalID_Works()
    {
        var response = await this.client.Customers.Credits.Ledger.CreateEntryByExternalID(
            new()
            {
                ExternalCustomerID = "external_customer_id",
                Body = new BodyProperties::Increment()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                    EffectiveDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        NetTerms = 0,
                        InvoiceDate = DateOnly.Parse("2019-12-27"),
                        Memo = "memo",
                        RequireSuccessfulPayment = true,
                    },
                    Metadata = new() { { "foo", "string" } },
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
            }
        );
        response.Validate();
    }

    [Fact]
    public async Task ListByExternalID_Works()
    {
        var page = await this.client.Customers.Credits.Ledger.ListByExternalID(
            new()
            {
                ExternalCustomerID = "external_customer_id",
                CreatedAtGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                Cursor = "cursor",
                EntryStatus = LedgerListByExternalIDParamsProperties::EntryStatus.Committed,
                EntryType = LedgerListByExternalIDParamsProperties::EntryType.Increment,
                Limit = 1,
                MinimumAmount = "minimum_amount",
            }
        );
        page.Validate();
    }
}
