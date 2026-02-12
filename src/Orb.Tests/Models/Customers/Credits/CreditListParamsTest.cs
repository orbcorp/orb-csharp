using System;
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
            EffectiveDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IncludeAllBlocks = true,
            Limit = 1,
        };

        string expectedCustomerID = "customer_id";
        string expectedCurrency = "currency";
        string expectedCursor = "cursor";
        DateTimeOffset expectedEffectiveDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEffectiveDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEffectiveDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEffectiveDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIncludeAllBlocks = true;
        long expectedLimit = 1;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEffectiveDateGt, parameters.EffectiveDateGt);
        Assert.Equal(expectedEffectiveDateGte, parameters.EffectiveDateGte);
        Assert.Equal(expectedEffectiveDateLt, parameters.EffectiveDateLt);
        Assert.Equal(expectedEffectiveDateLte, parameters.EffectiveDateLte);
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
            EffectiveDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            EffectiveDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

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
        Assert.Null(parameters.EffectiveDateGt);
        Assert.False(parameters.RawQueryData.ContainsKey("effective_date[gt]"));
        Assert.Null(parameters.EffectiveDateGte);
        Assert.False(parameters.RawQueryData.ContainsKey("effective_date[gte]"));
        Assert.Null(parameters.EffectiveDateLt);
        Assert.False(parameters.RawQueryData.ContainsKey("effective_date[lt]"));
        Assert.Null(parameters.EffectiveDateLte);
        Assert.False(parameters.RawQueryData.ContainsKey("effective_date[lte]"));
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
            EffectiveDateGt = null,
            EffectiveDateGte = null,
            EffectiveDateLt = null,
            EffectiveDateLte = null,
        };

        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EffectiveDateGt);
        Assert.True(parameters.RawQueryData.ContainsKey("effective_date[gt]"));
        Assert.Null(parameters.EffectiveDateGte);
        Assert.True(parameters.RawQueryData.ContainsKey("effective_date[gte]"));
        Assert.Null(parameters.EffectiveDateLt);
        Assert.True(parameters.RawQueryData.ContainsKey("effective_date[lt]"));
        Assert.Null(parameters.EffectiveDateLte);
        Assert.True(parameters.RawQueryData.ContainsKey("effective_date[lte]"));
    }

    [Fact]
    public void Url_Works()
    {
        CreditListParams parameters = new()
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Cursor = "cursor",
            EffectiveDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IncludeAllBlocks = true,
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/customers/customer_id/credits?currency=currency&cursor=cursor&effective_date%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&effective_date%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&effective_date%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&effective_date%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&include_all_blocks=true&limit=1"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditListParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Cursor = "cursor",
            EffectiveDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IncludeAllBlocks = true,
            Limit = 1,
        };

        CreditListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
