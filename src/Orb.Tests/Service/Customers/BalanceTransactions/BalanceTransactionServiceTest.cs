using System;
using System.Threading.Tasks;
using BalanceTransactionCreateParamsProperties = Orb.Models.Customers.BalanceTransactions.BalanceTransactionCreateParamsProperties;

namespace Orb.Tests.Service.Customers.BalanceTransactions;

public class BalanceTransactionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var balanceTransaction = await this.client.Customers.BalanceTransactions.Create(
            new()
            {
                CustomerID = "customer_id",
                Amount = "amount",
                Type = BalanceTransactionCreateParamsProperties::Type.Increment,
                Description = "description",
            }
        );
        balanceTransaction.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.BalanceTransactions.List(
            new()
            {
                CustomerID = "customer_id",
                Cursor = "cursor",
                Limit = 1,
                OperationTimeGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                OperationTimeGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                OperationTimeLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                OperationTimeLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        page.Validate();
    }
}
