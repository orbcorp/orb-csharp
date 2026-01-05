using System;
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

    [Fact]
    public void Url_Works()
    {
        ItemArchiveParams parameters = new() { ItemID = "item_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/items/item_id/archive"), url);
    }
}
