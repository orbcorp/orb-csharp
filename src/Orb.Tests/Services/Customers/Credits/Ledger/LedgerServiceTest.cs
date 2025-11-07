using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ledger = Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Services.Customers.Credits.Ledger;

public class LedgerServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.Credits.Ledger.List(
            new() { CustomerID = "customer_id" }
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
                Body = new Ledger::Increment()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                    EffectiveDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = Ledger::Field.ItemID,
                            Operator = Ledger::Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        CustomDueDate = DateOnly.Parse("2019-12-27"),
                        InvoiceDate = DateOnly.Parse("2019-12-27"),
                        ItemID = "item_id",
                        Memo = "memo",
                        NetTerms = 0,
                        RequireSuccessfulPayment = true,
                    },
                    Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
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
                Body = new Ledger::IncrementModel()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                    EffectiveDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = Ledger::FieldModel.ItemID,
                            Operator = Ledger::OperatorModel.Includes,
                            Values = ["string"],
                        },
                    ],
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        CustomDueDate = DateOnly.Parse("2019-12-27"),
                        InvoiceDate = DateOnly.Parse("2019-12-27"),
                        ItemID = "item_id",
                        Memo = "memo",
                        NetTerms = 0,
                        RequireSuccessfulPayment = true,
                    },
                    Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
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
            new() { ExternalCustomerID = "external_customer_id" }
        );
        page.Validate();
    }
}
