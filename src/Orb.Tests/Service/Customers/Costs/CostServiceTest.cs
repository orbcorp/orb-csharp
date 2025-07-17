using CostListByExternalIDParamsProperties = Orb.Models.Customers.Costs.CostListByExternalIDParamsProperties;
using CostListParamsProperties = Orb.Models.Customers.Costs.CostListParamsProperties;
using Costs = Orb.Models.Customers.Costs;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Customers.Costs;

public class CostServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task List_Works()
    {
        var costs = await this.client.Customers.Costs.List(
            new Costs::CostListParams()
            {
                CustomerID = "customer_id",
                Currency = "currency",
                TimeframeEnd = System::DateTime.Parse("2022-03-01T05:00:00Z"),
                TimeframeStart = System::DateTime.Parse("2022-02-01T05:00:00Z"),
                ViewMode = CostListParamsProperties::ViewMode.Periodic,
            }
        );
        costs.Validate();
    }

    [Fact]
    public async Tasks::Task ListByExternalID_Works()
    {
        var response = await this.client.Customers.Costs.ListByExternalID(
            new Costs::CostListByExternalIDParams()
            {
                ExternalCustomerID = "external_customer_id",
                Currency = "currency",
                TimeframeEnd = System::DateTime.Parse("2022-03-01T05:00:00Z"),
                TimeframeStart = System::DateTime.Parse("2022-02-01T05:00:00Z"),
                ViewMode = CostListByExternalIDParamsProperties::ViewMode.Periodic,
            }
        );
        response.Validate();
    }
}
