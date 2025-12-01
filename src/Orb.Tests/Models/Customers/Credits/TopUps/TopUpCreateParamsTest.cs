using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Tests.Models.Customers.Credits.TopUps;

public class InvoiceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };

        bool expectedAutoCollection = true;
        long expectedNetTerms = 0;
        string expectedMemo = "memo";
        bool expectedRequireSuccessfulPayment = true;

        Assert.Equal(expectedAutoCollection, model.AutoCollection);
        Assert.Equal(expectedNetTerms, model.NetTerms);
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedRequireSuccessfulPayment, model.RequireSuccessfulPayment);
    }
}
