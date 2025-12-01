using Orb.Models;

namespace Orb.Tests.Models;

public class PaginationMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaginationMetadata { HasMore = true, NextCursor = "next_cursor" };

        bool expectedHasMore = true;
        string expectedNextCursor = "next_cursor";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }
}
