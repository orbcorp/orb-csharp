using InvoiceLineItems = Orb.Models.InvoiceLineItems;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.InvoiceLineItems;

public class InvoiceLineItemServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var invoiceLineItem = await this.client.InvoiceLineItems.Create(
            new InvoiceLineItems::InvoiceLineItemCreateParams()
            {
                Amount = "12.00",
                EndDate = System::DateOnly.Parse("2023-09-22"),
                InvoiceID = "4khy3nwzktxv7",
                Name = "Item Name",
                Quantity = 1,
                StartDate = System::DateOnly.Parse("2023-09-22"),
            }
        );
        invoiceLineItem.Validate();
    }
}
