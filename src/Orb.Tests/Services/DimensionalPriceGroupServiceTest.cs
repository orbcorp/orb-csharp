using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class DimensionalPriceGroupServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var dimensionalPriceGroup = await this.client.DimensionalPriceGroups.Create(
            new()
            {
                BillableMetricID = "billable_metric_id",
                Dimensions = ["region", "instance_type"],
                Name = "name",
            },
            TestContext.Current.CancellationToken
        );
        dimensionalPriceGroup.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var dimensionalPriceGroup = await this.client.DimensionalPriceGroups.Retrieve(
            "dimensional_price_group_id",
            new(),
            TestContext.Current.CancellationToken
        );
        dimensionalPriceGroup.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var dimensionalPriceGroup = await this.client.DimensionalPriceGroups.Update(
            "dimensional_price_group_id",
            new(),
            TestContext.Current.CancellationToken
        );
        dimensionalPriceGroup.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.DimensionalPriceGroups.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
