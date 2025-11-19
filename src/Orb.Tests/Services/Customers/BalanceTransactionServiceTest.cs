using System.Threading.Tasks;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Tests.Services.Customers;

public class BalanceTransactionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var balanceTransaction = await this.client.Customers.BalanceTransactions.Create(
            "customer_id",
            new() { Amount = "amount", Type = Type.Increment }
        );
        balanceTransaction.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.BalanceTransactions.List("customer_id");
        page.Validate();
    }
}
