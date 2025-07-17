using BalanceTransactionCreateParamsProperties = Orb.Models.Customers.BalanceTransactions.BalanceTransactionCreateParamsProperties;
using BalanceTransactions = Orb.Models.Customers.BalanceTransactions;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Customers.BalanceTransactions;

public class BalanceTransactionServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var balanceTransaction = await this.client.Customers.BalanceTransactions.Create(
            new BalanceTransactions::BalanceTransactionCreateParams()
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
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Customers.BalanceTransactions.List(
            new BalanceTransactions::BalanceTransactionListParams()
            {
                CustomerID = "customer_id",
                Cursor = "cursor",
                Limit = 1,
                OperationTimeGt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                OperationTimeGte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                OperationTimeLt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                OperationTimeLte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        page.Validate();
    }
}
