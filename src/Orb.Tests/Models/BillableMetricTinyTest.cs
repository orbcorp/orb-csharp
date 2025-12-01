using Orb.Models;

namespace Orb.Tests.Models;

public class BillableMetricTinyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillableMetricTiny { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }
}
