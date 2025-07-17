using CreditNoteCreateParamsProperties = Orb.Models.CreditNotes.CreditNoteCreateParamsProperties;
using CreditNotes = Orb.Models.CreditNotes;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.CreditNotes;

public class CreditNoteServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var creditNote = await this.client.CreditNotes.Create(
            new CreditNotes::CreditNoteCreateParams()
            {
                LineItems =
                [
                    new CreditNoteCreateParamsProperties::LineItem()
                    {
                        Amount = "amount",
                        InvoiceLineItemID = "4khy3nwzktxv7",
                        EndDate = System::DateOnly.Parse("2023-09-22"),
                        StartDate = System::DateOnly.Parse("2023-09-22"),
                    },
                ],
                Reason = CreditNoteCreateParamsProperties::Reason.Duplicate,
                EndDate = System::DateOnly.Parse("2023-09-22"),
                Memo = "An optional memo for my credit note.",
                StartDate = System::DateOnly.Parse("2023-09-22"),
            }
        );
        creditNote.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.CreditNotes.List(
            new CreditNotes::CreditNoteListParams()
            {
                CreatedAtGt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                Limit = 1,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var creditNote = await this.client.CreditNotes.Fetch(
            new CreditNotes::CreditNoteFetchParams() { CreditNoteID = "credit_note_id" }
        );
        creditNote.Validate();
    }
}
