using DimensionalPriceGroups = Orb.Models.DimensionalPriceGroups;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.DimensionalPriceGroups;

public class DimensionalPriceGroupServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var dimensionalPriceGroup = await this.client.DimensionalPriceGroups.Create(
            new DimensionalPriceGroups::DimensionalPriceGroupCreateParams()
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
            new DimensionalPriceGroups::DimensionalPriceGroupRetrieveParams()
            {
                DimensionalPriceGroupID = "dimensional_price_group_id",
            }
        );
        dimensionalPriceGroup.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.DimensionalPriceGroups.List(
            new DimensionalPriceGroups::DimensionalPriceGroupListParams()
            {
                Cursor = "cursor",
                Limit = 1,
            }
        );
        page.Validate();
    }
}
