using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Customers.Credits;

public class CreditServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Customers.Credits.List(
            new()
            {
                CustomerID = "customer_id",
                Currency = "currency",
                Cursor = "cursor",
                IncludeAllBlocks = true,
                Limit = 1,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task ListByExternalID_Works()
    {
        var page = await this.client.Customers.Credits.ListByExternalID(
            new()
            {
                ExternalCustomerID = "external_customer_id",
                Currency = "currency",
                Cursor = "cursor",
                IncludeAllBlocks = true,
                Limit = 1,
            }
        );
        page.Validate();
    }
}
