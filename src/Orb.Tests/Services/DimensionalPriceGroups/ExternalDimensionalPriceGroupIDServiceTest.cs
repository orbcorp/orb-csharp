using System.Threading.Tasks;

namespace Orb.Tests.Services.DimensionalPriceGroups;

public class ExternalDimensionalPriceGroupIDServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var dimensionalPriceGroup =
            await this.client.DimensionalPriceGroups.ExternalDimensionalPriceGroupID.Retrieve(
                "external_dimensional_price_group_id"
            );
        dimensionalPriceGroup.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var dimensionalPriceGroup =
            await this.client.DimensionalPriceGroups.ExternalDimensionalPriceGroupID.Update(
                "external_dimensional_price_group_id"
            );
        dimensionalPriceGroup.Validate();
    }
}
