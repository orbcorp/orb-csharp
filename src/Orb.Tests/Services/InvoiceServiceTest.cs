using System;
using System.Threading.Tasks;
using Orb.Models.Invoices;

namespace Orb.Tests.Services;

public class InvoiceServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var invoice = await this.client.Invoices.Create(
            new()
            {
                Currency = "USD",
                InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LineItems =
                [
                    new()
                    {
                        EndDate = "2023-09-22",
                        ItemID = "4khy3nwzktxv7",
                        ModelType = ModelType.Unit,
                        Name = "Line Item Name",
                        Quantity = 1,
                        StartDate = "2023-09-22",
                        UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var invoice = await this.client.Invoices.Update(
            "invoice_id",
            new(),
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Invoices.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task DeleteLineItem_Works()
    {
        await this.client.Invoices.DeleteLineItem(
            "line_item_id",
            new() { InvoiceID = "invoice_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var invoice = await this.client.Invoices.Fetch(
            "invoice_id",
            new(),
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task FetchUpcoming_Works()
    {
        var response = await this.client.Invoices.FetchUpcoming(
            new() { SubscriptionID = "subscription_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Issue_Works()
    {
        var invoice = await this.client.Invoices.Issue(
            "invoice_id",
            new(),
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task ListSummary_Works()
    {
        var page = await this.client.Invoices.ListSummary(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task MarkPaid_Works()
    {
        var invoice = await this.client.Invoices.MarkPaid(
            "invoice_id",
            new() { PaymentReceivedDate = "2023-09-22" },
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Pay_Works()
    {
        var invoice = await this.client.Invoices.Pay(
            "invoice_id",
            new(),
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }

    [Fact]
    public async Task Void_Works()
    {
        var invoice = await this.client.Invoices.Void(
            "invoice_id",
            new(),
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }
}
