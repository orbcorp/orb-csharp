using System.Threading.Tasks;

namespace Orb.Tests.Services.Customers;

public class CreditServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.Credits.List("customer_id");
        page.Validate();
    }

    [Fact]
    public async Task ListByExternalID_Works()
    {
        var page = await this.client.Customers.Credits.ListByExternalID("external_customer_id");
        page.Validate();
    }
}
