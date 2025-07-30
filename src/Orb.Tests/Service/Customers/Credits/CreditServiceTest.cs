using System.Threading.Tasks;

namespace Orb.Tests.Service.Customers.Credits;

public class CreditServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
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
    public async Task ListByExternalID_Works()
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
