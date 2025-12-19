using Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Tests.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

public class ExternalDimensionalPriceGroupIDRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalDimensionalPriceGroupIDRetrieveParams
        {
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };

        string expectedExternalDimensionalPriceGroupID = "external_dimensional_price_group_id";

        Assert.Equal(
            expectedExternalDimensionalPriceGroupID,
            parameters.ExternalDimensionalPriceGroupID
        );
    }
}
