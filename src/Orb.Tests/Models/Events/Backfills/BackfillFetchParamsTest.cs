using Orb.Models.Events.Backfills;

namespace Orb.Tests.Models.Events.Backfills;

public class BackfillFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BackfillFetchParams { BackfillID = "backfill_id" };

        string expectedBackfillID = "backfill_id";

        Assert.Equal(expectedBackfillID, parameters.BackfillID);
    }
}
