using Orb.Models.DimensionalPriceGroups;

namespace Orb.Tests.Models.DimensionalPriceGroups;

public class DimensionalPriceGroupRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DimensionalPriceGroupRetrieveParams
        {
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        string expectedDimensionalPriceGroupID = "dimensional_price_group_id";

        Assert.Equal(expectedDimensionalPriceGroupID, parameters.DimensionalPriceGroupID);
    }
}
