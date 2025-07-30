using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.DimensionalPriceGroups;

public class DimensionalPriceGroupServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var dimensionalPriceGroup = await this.client.DimensionalPriceGroups.Create(
            new()
            {
                BillableMetricID = "billable_metric_id",
                Dimensions = ["region", "instance_type"],
                Name = "name",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        dimensionalPriceGroup.Validate();
    }

    [Fact]
    public async Tasks::Task Retrieve_Works()
    {
        var dimensionalPriceGroup = await this.client.DimensionalPriceGroups.Retrieve(
            new() { DimensionalPriceGroupID = "dimensional_price_group_id" }
        );
        dimensionalPriceGroup.Validate();
    }

    [Fact]
    public async Tasks::Task Update_Works()
    {
        var dimensionalPriceGroup = await this.client.DimensionalPriceGroups.Update(
            new()
            {
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        dimensionalPriceGroup.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.DimensionalPriceGroups.List(
            new() { Cursor = "cursor", Limit = 1 }
        );
        page.Validate();
    }
}
