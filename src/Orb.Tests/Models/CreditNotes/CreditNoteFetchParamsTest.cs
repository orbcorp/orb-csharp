using Orb.Models.CreditNotes;

namespace Orb.Tests.Models.CreditNotes;

public class CreditNoteFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditNoteFetchParams { CreditNoteID = "credit_note_id" };

        string expectedCreditNoteID = "credit_note_id";

        Assert.Equal(expectedCreditNoteID, parameters.CreditNoteID);
    }
}
