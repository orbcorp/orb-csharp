using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Tests.Models.Customers.Credits.TopUps;

public class TopUpListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopUpListParams
        {
            CustomerID = "customer_id",
            Cursor = "cursor",
            Limit = 1,
        };

        string expectedCustomerID = "customer_id";
        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TopUpListParams { CustomerID = "customer_id", Cursor = "cursor" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TopUpListParams
        {
            CustomerID = "customer_id",
            Cursor = "cursor",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TopUpListParams { CustomerID = "customer_id", Limit = 1 };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TopUpListParams
        {
            CustomerID = "customer_id",
            Limit = 1,

            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }
}
