using Orb.Models.Events.Backfills;

namespace Orb.Tests.Models.Events.Backfills;

public class BackfillCloseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BackfillCloseParams { BackfillID = "backfill_id" };

        string expectedBackfillID = "backfill_id";

        Assert.Equal(expectedBackfillID, parameters.BackfillID);
    }
}
