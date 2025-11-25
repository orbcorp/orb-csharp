using System;
using System.Threading.Tasks;
using Orb.Models.CreditNotes;

namespace Orb.Tests.Services;

public class CreditNoteServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var creditNote = await this.client.CreditNotes.Create(
            new()
            {
                LineItems =
                [
                    new()
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
                    },
                ],
                Reason = Reason.Duplicate,
            }
        );
        creditNote.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CreditNotes.List();
        page.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var creditNote = await this.client.CreditNotes.Fetch("credit_note_id");
        creditNote.Validate();
    }
}
