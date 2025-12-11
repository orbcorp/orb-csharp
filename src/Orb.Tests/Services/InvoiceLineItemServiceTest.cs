using System;
using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class InvoiceLineItemServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var invoiceLineItem = await this.client.InvoiceLineItems.Create(
            new()
            {
                Amount = "12.00",
                EndDate =
#if NET
                DateOnly
#else
                DateTimeOffset
#endif
                .Parse("2023-09-22"),
                InvoiceID = "4khy3nwzktxv7",
                Quantity = 1,
                StartDate =
#if NET
                DateOnly
#else
                DateTimeOffset
#endif
                .Parse("2023-09-22"),
            },
            TestContext.Current.CancellationToken
        );
        invoiceLineItem.Validate();
    }
}
