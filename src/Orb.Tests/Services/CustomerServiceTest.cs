using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class CustomerServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var customer = await this.client.Customers.Create(
            new() { Email = "dev@stainless.com", Name = "x" }
        );
        customer.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var customer = await this.client.Customers.Update("customer_id");
        customer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.List();
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Customers.Delete("customer_id");
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var customer = await this.client.Customers.Fetch("customer_id");
        customer.Validate();
    }

    [Fact]
    public async Task FetchByExternalID_Works()
    {
        var customer = await this.client.Customers.FetchByExternalID("external_customer_id");
        customer.Validate();
    }

    [Fact]
    public async Task SyncPaymentMethodsFromGateway_Works()
    {
        await this.client.Customers.SyncPaymentMethodsFromGateway("customer_id");
    }

    [Fact]
    public async Task SyncPaymentMethodsFromGatewayByExternalCustomerID_Works()
    {
        await this.client.Customers.SyncPaymentMethodsFromGatewayByExternalCustomerID(
            "external_customer_id"
        );
    }

    [Fact]
    public async Task UpdateByExternalID_Works()
    {
        var customer = await this.client.Customers.UpdateByExternalID("external_customer_id");
        customer.Validate();
    }
}
