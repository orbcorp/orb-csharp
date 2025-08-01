using System;
using System.Threading.Tasks;
using Orb.Models;
using Orb.Models.Invoices.InvoiceCreateParamsProperties.LineItemProperties;
using Orb.Models.Invoices.InvoiceListParamsProperties;
using Orb.Models.PercentageDiscountProperties;
using Orb.Models.TransformPriceFilterProperties;

namespace Orb.Tests.Services.Invoices;

public class InvoiceServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var invoice = await this.client.Invoices.Create(
            new()
            {
                Currency = "USD",
                InvoiceDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                LineItems =
                [
                    new()
                    {
                        EndDate = DateOnly.Parse("2023-09-22"),
                        ItemID = "4khy3nwzktxv7",
                        ModelType = ModelType.Unit,
                        Name = "Line Item Name",
                        Quantity = 1,
                        StartDate = DateOnly.Parse("2023-09-22"),
                        UnitConfig = new("unit_amount"),
                    },
                ],
                CustomerID = "4khy3nwzktxv7",
                Discount = new PercentageDiscount()
                {
                    DiscountType = DiscountType.Percentage,
                    PercentageDiscount1 = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = Field.PriceID,
                            Operator = Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    Reason = "reason",
                },
                ExternalCustomerID = "external-customer-id",
                Memo = "An optional memo for my invoice.",
                Metadata = new() { { "foo", "string" } },
                NetTerms = 0,
                WillAutoIssue = false,
            }
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var invoice = await this.client.Invoices.Update(
            new()
            {
                InvoiceID = "invoice_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        invoice.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Invoices.List(
            new()
            {
                Amount = "amount",
                AmountGt = "amount[gt]",
                AmountLt = "amount[lt]",
                Cursor = "cursor",
                CustomerID = "customer_id",
                DateType = DateType.DueDate,
                DueDate = DateOnly.Parse("2019-12-27"),
                DueDateWindow = "due_date_window",
                DueDateGt = DateOnly.Parse("2019-12-27"),
                DueDateLt = DateOnly.Parse("2019-12-27"),
                ExternalCustomerID = "external_customer_id",
                InvoiceDateGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceDateGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceDateLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceDateLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                IsRecurring = true,
                Limit = 1,
                Status = [Status.Draft],
                SubscriptionID = "subscription_id",
            }
        );
        page.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var invoice = await this.client.Invoices.Fetch(new() { InvoiceID = "invoice_id" });
        invoice.Validate();
    }

    [Fact]
    public async Task FetchUpcoming_Works()
    {
        var response = await this.client.Invoices.FetchUpcoming(
            new() { SubscriptionID = "subscription_id" }
        );
        response.Validate();
    }

    [Fact]
    public async Task Issue_Works()
    {
        var invoice = await this.client.Invoices.Issue(
            new() { InvoiceID = "invoice_id", Synchronous = true }
        );
        invoice.Validate();
    }

    [Fact]
    public async Task MarkPaid_Works()
    {
        var invoice = await this.client.Invoices.MarkPaid(
            new()
            {
                InvoiceID = "invoice_id",
                PaymentReceivedDate = DateOnly.Parse("2023-09-22"),
                ExternalID = "external_payment_id_123",
                Notes = "notes",
            }
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Pay_Works()
    {
        var invoice = await this.client.Invoices.Pay(new() { InvoiceID = "invoice_id" });
        invoice.Validate();
    }

    [Fact]
    public async Task Void_Works()
    {
        var invoice = await this.client.Invoices.Void(new() { InvoiceID = "invoice_id" });
        invoice.Validate();
    }
}
