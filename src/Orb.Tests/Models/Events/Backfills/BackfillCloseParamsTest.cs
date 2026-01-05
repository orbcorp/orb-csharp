using System;
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

    [Fact]
    public void Url_Works()
    {
        BackfillCloseParams parameters = new() { BackfillID = "backfill_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/events/backfills/backfill_id/close"), url);
    }
}
