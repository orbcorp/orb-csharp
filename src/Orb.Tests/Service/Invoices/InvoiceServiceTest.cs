using InvoiceListParamsProperties = Orb.Models.Invoices.InvoiceListParamsProperties;
using LineItemProperties = Orb.Models.Invoices.InvoiceCreateParamsProperties.LineItemProperties;
using Models = Orb.Models;
using PercentageDiscountProperties = Orb.Models.PercentageDiscountProperties;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;
using TransformPriceFilterProperties = Orb.Models.TransformPriceFilterProperties;

namespace Orb.Tests.Service.Invoices;

public class InvoiceServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var invoice = await this.client.Invoices.Create(
            new()
            {
                Currency = "USD",
                InvoiceDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                LineItems =
                [
                    new()
                    {
                        EndDate = System::DateOnly.Parse("2023-09-22"),
                        ItemID = "4khy3nwzktxv7",
                        ModelType = LineItemProperties::ModelType.Unit,
                        Name = "Line Item Name",
                        Quantity = 1,
                        StartDate = System::DateOnly.Parse("2023-09-22"),
                        UnitConfig = new() { UnitAmount = "unit_amount" },
                    },
                ],
                CustomerID = "4khy3nwzktxv7",
                Discount = new Models::PercentageDiscount()
                {
                    DiscountType = PercentageDiscountProperties::DiscountType.Percentage,
                    PercentageDiscount1 = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = TransformPriceFilterProperties::Field.PriceID,
                            Operator = TransformPriceFilterProperties::Operator.Includes,
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
    public async Tasks::Task Update_Works()
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
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Invoices.List(
            new()
            {
                Amount = "amount",
                AmountGt = "amount[gt]",
                AmountLt = "amount[lt]",
                Cursor = "cursor",
                CustomerID = "customer_id",
                DateType = InvoiceListParamsProperties::DateType.DueDate,
                DueDate = System::DateOnly.Parse("2019-12-27"),
                DueDateWindow = "due_date_window",
                DueDateGt = System::DateOnly.Parse("2019-12-27"),
                DueDateLt = System::DateOnly.Parse("2019-12-27"),
                ExternalCustomerID = "external_customer_id",
                InvoiceDateGt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceDateGte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceDateLt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceDateLte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                IsRecurring = true,
                Limit = 1,
                Status = [InvoiceListParamsProperties::Status.Draft],
                SubscriptionID = "subscription_id",
            }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var invoice = await this.client.Invoices.Fetch(new() { InvoiceID = "invoice_id" });
        invoice.Validate();
    }

    [Fact]
    public async Tasks::Task FetchUpcoming_Works()
    {
        var response = await this.client.Invoices.FetchUpcoming(
            new() { SubscriptionID = "subscription_id" }
        );
        response.Validate();
    }

    [Fact]
    public async Tasks::Task Issue_Works()
    {
        var invoice = await this.client.Invoices.Issue(
            new() { InvoiceID = "invoice_id", Synchronous = true }
        );
        invoice.Validate();
    }

    [Fact]
    public async Tasks::Task MarkPaid_Works()
    {
        var invoice = await this.client.Invoices.MarkPaid(
            new()
            {
                InvoiceID = "invoice_id",
                PaymentReceivedDate = System::DateOnly.Parse("2023-09-22"),
                ExternalID = "external_payment_id_123",
                Notes = "notes",
            }
        );
        invoice.Validate();
    }

    [Fact]
    public async Tasks::Task Pay_Works()
    {
        var invoice = await this.client.Invoices.Pay(new() { InvoiceID = "invoice_id" });
        invoice.Validate();
    }

    [Fact]
    public async Tasks::Task Void_Works()
    {
        var invoice = await this.client.Invoices.Void(new() { InvoiceID = "invoice_id" });
        invoice.Validate();
    }
}
