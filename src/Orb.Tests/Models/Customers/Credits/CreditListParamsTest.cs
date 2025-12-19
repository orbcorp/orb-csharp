using Orb.Models.Customers.Credits;

namespace Orb.Tests.Models.Customers.Credits;

public class CreditListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditListParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Cursor = "cursor",
            IncludeAllBlocks = true,
            Limit = 1,
        };

        string expectedCustomerID = "customer_id";
        string expectedCurrency = "currency";
        string expectedCursor = "cursor";
        bool expectedIncludeAllBlocks = true;
        long expectedLimit = 1;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedIncludeAllBlocks, parameters.IncludeAllBlocks);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CreditListParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Cursor = "cursor",
        };

        Assert.Null(parameters.IncludeAllBlocks);
        Assert.False(parameters.RawQueryData.ContainsKey("include_all_blocks"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CreditListParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Cursor = "cursor",

            // Null should be interpreted as omitted for these properties
            IncludeAllBlocks = null,
            Limit = null,
        };

        Assert.Null(parameters.IncludeAllBlocks);
        Assert.False(parameters.RawQueryData.ContainsKey("include_all_blocks"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CreditListParams
        {
            CustomerID = "customer_id",
            IncludeAllBlocks = true,
            Limit = 1,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CreditListParams
        {
            CustomerID = "customer_id",
            IncludeAllBlocks = true,
            Limit = 1,

            Currency = null,
            Cursor = null,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }
}
