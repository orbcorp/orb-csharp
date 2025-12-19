using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Tests.Models.Prices.ExternalPriceID;

public class ExternalPriceIDFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalPriceIDFetchParams { ExternalPriceID = "external_price_id" };

        string expectedExternalPriceID = "external_price_id";

        Assert.Equal(expectedExternalPriceID, parameters.ExternalPriceID);
    }
}
