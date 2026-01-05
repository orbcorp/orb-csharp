using System;
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

    [Fact]
    public void Url_Works()
    {
        CreditNoteFetchParams parameters = new() { CreditNoteID = "credit_note_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/credit_notes/credit_note_id"), url);
    }
}
