using System.Collections.Generic;
using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Tests.Models.Prices.ExternalPriceID;

public class ExternalPriceIDUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalPriceIDUpdateParams
        {
            ExternalPriceID = "external_price_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string expectedExternalPriceID = "external_price_id";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedExternalPriceID, parameters.ExternalPriceID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalPriceIDUpdateParams { ExternalPriceID = "external_price_id" };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExternalPriceIDUpdateParams
        {
            ExternalPriceID = "external_price_id",

            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }
}
