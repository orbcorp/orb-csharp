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
                        EndDate = "2023-09-22",
                        StartDate = "2023-09-22",
                    },
                ],
                Reason = Reason.Duplicate,
            },
            TestContext.Current.CancellationToken
        );
        creditNote.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CreditNotes.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var creditNote = await this.client.CreditNotes.Fetch(
            "credit_note_id",
            new(),
            TestContext.Current.CancellationToken
        );
        creditNote.Validate();
    }
}
