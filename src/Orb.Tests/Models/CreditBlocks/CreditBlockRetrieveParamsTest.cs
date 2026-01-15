using System;
using Orb.Models.CreditBlocks;

namespace Orb.Tests.Models.CreditBlocks;

public class CreditBlockRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditBlockRetrieveParams { BlockID = "block_id" };

        string expectedBlockID = "block_id";

        Assert.Equal(expectedBlockID, parameters.BlockID);
    }

    [Fact]
    public void Url_Works()
    {
        CreditBlockRetrieveParams parameters = new() { BlockID = "block_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/credit_blocks/block_id"), url);
    }
}
