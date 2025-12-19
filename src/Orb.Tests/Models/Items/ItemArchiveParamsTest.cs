using Orb.Models.Items;

namespace Orb.Tests.Models.Items;

public class ItemArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemArchiveParams { ItemID = "item_id" };

        string expectedItemID = "item_id";

        Assert.Equal(expectedItemID, parameters.ItemID);
    }
}
