using System;
using System.Threading.Tasks;
using Orb.Models.Customers.Costs.CostListParamsProperties;
using CostListByExternalIDParamsProperties = Orb.Models.Customers.Costs.CostListByExternalIDParamsProperties;

namespace Orb.Tests.Service.Customers.Costs;

public class CostServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var costs = await this.client.Customers.Costs.List(
            new()
            {
                CustomerID = "customer_id",
                Currency = "currency",
                TimeframeEnd = DateTime.Parse("2022-03-01T05:00:00Z"),
                TimeframeStart = DateTime.Parse("2022-02-01T05:00:00Z"),
                ViewMode = ViewMode.Periodic,
            }
        );
        costs.Validate();
    }

    [Fact]
    public async Task ListByExternalID_Works()
    {
        var response = await this.client.Customers.Costs.ListByExternalID(
            new()
            {
                ExternalCustomerID = "external_customer_id",
                Currency = "currency",
                TimeframeEnd = DateTime.Parse("2022-03-01T05:00:00Z"),
                TimeframeStart = DateTime.Parse("2022-02-01T05:00:00Z"),
                ViewMode = CostListByExternalIDParamsProperties::ViewMode.Periodic,
            }
        );
        response.Validate();
    }
}
