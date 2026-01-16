using System;
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

    [Fact]
    public void Url_Works()
    {
        BackfillFetchParams parameters = new() { BackfillID = "backfill_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/events/backfills/backfill_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BackfillFetchParams { BackfillID = "backfill_id" };

        BackfillFetchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
