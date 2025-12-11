using System.Threading.Tasks;

namespace Orb.Tests.Services.Customers;

public class CostServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var costs = await this.client.Customers.Costs.List(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        costs.Validate();
    }

    [Fact]
    public async Task ListByExternalID_Works()
    {
        var response = await this.client.Customers.Costs.ListByExternalID(
            "external_customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
