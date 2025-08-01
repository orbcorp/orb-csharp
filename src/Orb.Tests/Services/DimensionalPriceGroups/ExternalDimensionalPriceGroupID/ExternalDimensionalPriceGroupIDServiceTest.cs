using System.Threading.Tasks;

namespace Orb.Tests.Services.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

public class ExternalDimensionalPriceGroupIDServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var dimensionalPriceGroup =
            await this.client.DimensionalPriceGroups.ExternalDimensionalPriceGroupID.Retrieve(
                new() { ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id" }
            );
        dimensionalPriceGroup.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var dimensionalPriceGroup =
            await this.client.DimensionalPriceGroups.ExternalDimensionalPriceGroupID.Update(
                new()
                {
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID1 = "external_dimensional_price_group_id",
                    Metadata = new() { { "foo", "string" } },
                }
            );
        dimensionalPriceGroup.Validate();
    }
}
