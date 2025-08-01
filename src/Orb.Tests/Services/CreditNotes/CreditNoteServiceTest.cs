using System;
using System.Threading.Tasks;
using Orb.Models.CreditNotes.CreditNoteCreateParamsProperties;

namespace Orb.Tests.Services.CreditNotes;

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
                        EndDate = DateOnly.Parse("2023-09-22"),
                        StartDate = DateOnly.Parse("2023-09-22"),
                    },
                ],
                Reason = Reason.Duplicate,
                EndDate = DateOnly.Parse("2023-09-22"),
                Memo = "An optional memo for my credit note.",
                StartDate = DateOnly.Parse("2023-09-22"),
            }
        );
        creditNote.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CreditNotes.List(
            new()
            {
                CreatedAtGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                Limit = 1,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var creditNote = await this.client.CreditNotes.Fetch(
            new() { CreditNoteID = "credit_note_id" }
        );
        creditNote.Validate();
    }
}
