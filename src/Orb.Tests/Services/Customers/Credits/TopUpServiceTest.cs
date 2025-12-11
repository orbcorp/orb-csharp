using System.Threading.Tasks;

namespace Orb.Tests.Services.Customers.Credits;

public class TopUpServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var topUp = await this.client.Customers.Credits.TopUps.Create(
            "customer_id",
            new()
            {
                Amount = "amount",
                Currency = "currency",
                InvoiceSettings = new()
                {
                    AutoCollection = true,
                    NetTerms = 0,
                    Memo = "memo",
                    RequireSuccessfulPayment = true,
                },
                PerUnitCostBasis = "per_unit_cost_basis",
                Threshold = "threshold",
            },
            TestContext.Current.CancellationToken
        );
        topUp.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.Credits.TopUps.List(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Customers.Credits.TopUps.Delete(
            "top_up_id",
            new() { CustomerID = "customer_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task CreateByExternalID_Works()
    {
        var response = await this.client.Customers.Credits.TopUps.CreateByExternalID(
            "external_customer_id",
            new()
            {
                Amount = "amount",
                Currency = "currency",
                InvoiceSettings = new()
                {
                    AutoCollection = true,
                    NetTerms = 0,
                    Memo = "memo",
                    RequireSuccessfulPayment = true,
                },
                PerUnitCostBasis = "per_unit_cost_basis",
                Threshold = "threshold",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task DeleteByExternalID_Works()
    {
        await this.client.Customers.Credits.TopUps.DeleteByExternalID(
            "top_up_id",
            new() { ExternalCustomerID = "external_customer_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task ListByExternalID_Works()
    {
        var page = await this.client.Customers.Credits.TopUps.ListByExternalID(
            "external_customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
