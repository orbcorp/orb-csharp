using BodyProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties;
using BodyProperties1 = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties;
using IncrementProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties.IncrementProperties;
using IncrementProperties1 = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties;
using Ledger = Orb.Models.Customers.Credits.Ledger;
using LedgerListByExternalIDParamsProperties = Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDParamsProperties;
using LedgerListParamsProperties = Orb.Models.Customers.Credits.Ledger.LedgerListParamsProperties;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Customers.Credits.Ledger;

public class LedgerServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Customers.Credits.Ledger.List(
            new Ledger::LedgerListParams()
            {
                CustomerID = "customer_id",
                CreatedAtGt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                Cursor = "cursor",
                EntryStatus = LedgerListParamsProperties::EntryStatus.Committed,
                EntryType = LedgerListParamsProperties::EntryType.Increment,
                Limit = 1,
                MinimumAmount = "minimum_amount",
            }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task CreateEntry_Works()
    {
        var response = await this.client.Customers.Credits.Ledger.CreateEntry(
            new Ledger::LedgerCreateEntryParams()
            {
                CustomerID = "customer_id",
                Body = new BodyProperties::Increment()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                    EffectiveDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceSettings = new IncrementProperties::InvoiceSettings()
                    {
                        AutoCollection = true,
                        NetTerms = 0,
                        InvoiceDate = System::DateOnly.Parse("2019-12-27"),
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
    public async Tasks::Task CreateEntryByExternalID_Works()
    {
        var response = await this.client.Customers.Credits.Ledger.CreateEntryByExternalID(
            new Ledger::LedgerCreateEntryByExternalIDParams()
            {
                ExternalCustomerID = "external_customer_id",
                Body = new BodyProperties1::Increment()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                    EffectiveDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceSettings = new IncrementProperties1::InvoiceSettings()
                    {
                        AutoCollection = true,
                        NetTerms = 0,
                        InvoiceDate = System::DateOnly.Parse("2019-12-27"),
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
    public async Tasks::Task ListByExternalID_Works()
    {
        var page = await this.client.Customers.Credits.Ledger.ListByExternalID(
            new Ledger::LedgerListByExternalIDParams()
            {
                ExternalCustomerID = "external_customer_id",
                CreatedAtGt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
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
