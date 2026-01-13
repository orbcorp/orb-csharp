using System;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Tests.Models.Customers.BalanceTransactions;

public class BalanceTransactionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BalanceTransactionListParams
        {
            CustomerID = "customer_id",
            Cursor = "cursor",
            Limit = 1,
            OperationTimeGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCustomerID = "customer_id";
        string expectedCursor = "cursor";
        long expectedLimit = 1;
        DateTimeOffset expectedOperationTimeGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOperationTimeGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOperationTimeLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOperationTimeLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOperationTimeGt, parameters.OperationTimeGt);
        Assert.Equal(expectedOperationTimeGte, parameters.OperationTimeGte);
        Assert.Equal(expectedOperationTimeLt, parameters.OperationTimeLt);
        Assert.Equal(expectedOperationTimeLte, parameters.OperationTimeLte);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BalanceTransactionListParams
        {
            CustomerID = "customer_id",
            Cursor = "cursor",
            OperationTimeGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BalanceTransactionListParams
        {
            CustomerID = "customer_id",
            Cursor = "cursor",
            OperationTimeGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BalanceTransactionListParams { CustomerID = "customer_id", Limit = 1 };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.OperationTimeGt);
        Assert.False(parameters.RawQueryData.ContainsKey("operation_time[gt]"));
        Assert.Null(parameters.OperationTimeGte);
        Assert.False(parameters.RawQueryData.ContainsKey("operation_time[gte]"));
        Assert.Null(parameters.OperationTimeLt);
        Assert.False(parameters.RawQueryData.ContainsKey("operation_time[lt]"));
        Assert.Null(parameters.OperationTimeLte);
        Assert.False(parameters.RawQueryData.ContainsKey("operation_time[lte]"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BalanceTransactionListParams
        {
            CustomerID = "customer_id",
            Limit = 1,

            Cursor = null,
            OperationTimeGt = null,
            OperationTimeGte = null,
            OperationTimeLt = null,
            OperationTimeLte = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.OperationTimeGt);
        Assert.True(parameters.RawQueryData.ContainsKey("operation_time[gt]"));
        Assert.Null(parameters.OperationTimeGte);
        Assert.True(parameters.RawQueryData.ContainsKey("operation_time[gte]"));
        Assert.Null(parameters.OperationTimeLt);
        Assert.True(parameters.RawQueryData.ContainsKey("operation_time[lt]"));
        Assert.Null(parameters.OperationTimeLte);
        Assert.True(parameters.RawQueryData.ContainsKey("operation_time[lte]"));
    }

    [Fact]
    public void Url_Works()
    {
        BalanceTransactionListParams parameters = new()
        {
            CustomerID = "customer_id",
            Cursor = "cursor",
            Limit = 1,
            OperationTimeGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OperationTimeLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/customers/customer_id/balance_transactions?cursor=cursor&limit=1&operation_time%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&operation_time%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&operation_time%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&operation_time%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00"
            ),
            url
        );
    }
}
