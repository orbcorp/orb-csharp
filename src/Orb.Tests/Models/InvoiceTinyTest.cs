using Orb.Models;

namespace Orb.Tests.Models;

public class InvoiceTinyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceTiny { ID = "gXcsPTVyC4YZa3Sc" };

        string expectedID = "gXcsPTVyC4YZa3Sc";

        Assert.Equal(expectedID, model.ID);
    }
}
