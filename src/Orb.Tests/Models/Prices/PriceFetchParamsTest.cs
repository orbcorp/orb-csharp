using Orb.Models.Prices;

namespace Orb.Tests.Models.Prices;

public class PriceFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PriceFetchParams { PriceID = "price_id" };

        string expectedPriceID = "price_id";

        Assert.Equal(expectedPriceID, parameters.PriceID);
    }
}
