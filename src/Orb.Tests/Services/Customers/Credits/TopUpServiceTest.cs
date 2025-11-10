using System.Threading.Tasks;

namespace Orb.Tests.Services.Customers.Credits;

public class TopUpServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var topUp = await this.client.Customers.Credits.TopUps.Create(
            new()
            {
                CustomerID = "customer_id",
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
            }
        );
        topUp.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.Credits.TopUps.List(
            new() { CustomerID = "customer_id" }
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Customers.Credits.TopUps.Delete(
            new() { CustomerID = "customer_id", TopUpID = "top_up_id" }
        );
    }

    [Fact]
    public async Task CreateByExternalID_Works()
    {
        var response = await this.client.Customers.Credits.TopUps.CreateByExternalID(
            new()
            {
                ExternalCustomerID = "external_customer_id",
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
            }
        );
        response.Validate();
    }

    [Fact]
    public async Task DeleteByExternalID_Works()
    {
        await this.client.Customers.Credits.TopUps.DeleteByExternalID(
            new() { ExternalCustomerID = "external_customer_id", TopUpID = "top_up_id" }
        );
    }

    [Fact]
    public async Task ListByExternalID_Works()
    {
        var page = await this.client.Customers.Credits.TopUps.ListByExternalID(
            new() { ExternalCustomerID = "external_customer_id" }
        );
        page.Validate();
    }
}
