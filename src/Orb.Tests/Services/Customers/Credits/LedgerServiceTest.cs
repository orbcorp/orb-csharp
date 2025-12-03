using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Services.Customers.Credits;

public class LedgerServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.Credits.Ledger.List("customer_id");
        page.Validate();
    }

    [Fact]
    public async Task CreateEntry_Works()
    {
        var response = await this.client.Customers.Credits.Ledger.CreateEntry(
            "customer_id",
            new()
            {
                Body = new Increment()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = Field.ItemID,
                            Operator = Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        CustomDueDate =
#if NET
                        DateOnly
#else
                        DateTimeOffset
#endif
                        .Parse("2019-12-27"),
                        InvoiceDate =
#if NET
                        DateOnly
#else
                        DateTimeOffset
#endif
                        .Parse("2019-12-27"),
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
            "external_customer_id",
            new()
            {
                Body = new LedgerCreateEntryByExternalIDParamsBodyIncrement()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field =
                                LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
                            Operator =
                                LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        CustomDueDate =
#if NET
                        DateOnly
#else
                        DateTimeOffset
#endif
                        .Parse("2019-12-27"),
                        InvoiceDate =
#if NET
                        DateOnly
#else
                        DateTimeOffset
#endif
                        .Parse("2019-12-27"),
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
            "external_customer_id"
        );
        page.Validate();
    }
}
