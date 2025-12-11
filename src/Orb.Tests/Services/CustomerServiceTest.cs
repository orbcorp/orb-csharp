using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class CustomerServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var customer = await this.client.Customers.Create(
            new() { Email = "dev@stainless.com", Name = "x" },
            TestContext.Current.CancellationToken
        );
        customer.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var customer = await this.client.Customers.Update(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        customer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Customers.Delete(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var customer = await this.client.Customers.Fetch(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        customer.Validate();
    }

    [Fact]
    public async Task FetchByExternalID_Works()
    {
        var customer = await this.client.Customers.FetchByExternalID(
            "external_customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        customer.Validate();
    }

    [Fact]
    public async Task SyncPaymentMethodsFromGateway_Works()
    {
        await this.client.Customers.SyncPaymentMethodsFromGateway(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task SyncPaymentMethodsFromGatewayByExternalCustomerID_Works()
    {
        await this.client.Customers.SyncPaymentMethodsFromGatewayByExternalCustomerID(
            "external_customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task UpdateByExternalID_Works()
    {
        var customer = await this.client.Customers.UpdateByExternalID(
            "external_customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        customer.Validate();
    }
}
