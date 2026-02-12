using System;
using Orb.Models.CreditBlocks;

namespace Orb.Tests.Models.CreditBlocks;

public class CreditBlockListInvoicesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditBlockListInvoicesParams { BlockID = "block_id" };

        string expectedBlockID = "block_id";

        Assert.Equal(expectedBlockID, parameters.BlockID);
    }

    [Fact]
    public void Url_Works()
    {
        CreditBlockListInvoicesParams parameters = new() { BlockID = "block_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/credit_blocks/block_id/invoices"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditBlockListInvoicesParams { BlockID = "block_id" };

        CreditBlockListInvoicesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
