using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

public class ExternalDimensionalPriceGroupIDServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Retrieve_Works()
    {
        var dimensionalPriceGroup =
            await this.client.DimensionalPriceGroups.ExternalDimensionalPriceGroupID.Retrieve(
                new() { ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id" }
            );
        dimensionalPriceGroup.Validate();
    }

    [Fact]
    public async Tasks::Task Update_Works()
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
