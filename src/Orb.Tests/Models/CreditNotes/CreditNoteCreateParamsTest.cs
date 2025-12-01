using System;
using Orb.Models.CreditNotes;

namespace Orb.Tests.Models.CreditNotes;

public class LineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LineItem
        {
            Amount = "amount",
            InvoiceLineItemID = "4khy3nwzktxv7",
            EndDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            StartDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
        };

        string expectedAmount = "amount";
        string expectedInvoiceLineItemID = "4khy3nwzktxv7";

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedEndDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2023-09-22");

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedStartDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2023-09-22");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedInvoiceLineItemID, model.InvoiceLineItemID);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedStartDate, model.StartDate);
    }
}
