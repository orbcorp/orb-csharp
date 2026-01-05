using System;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionFetchScheduleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionFetchScheduleParams
        {
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            Limit = 1,
            StartDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedSubscriptionID = "subscription_id";
        string expectedCursor = "cursor";
        long expectedLimit = 1;
        DateTimeOffset expectedStartDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStartDateGt, parameters.StartDateGt);
        Assert.Equal(expectedStartDateGte, parameters.StartDateGte);
        Assert.Equal(expectedStartDateLt, parameters.StartDateLt);
        Assert.Equal(expectedStartDateLte, parameters.StartDateLte);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionFetchScheduleParams
        {
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            StartDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionFetchScheduleParams
        {
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            StartDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionFetchScheduleParams
        {
            SubscriptionID = "subscription_id",
            Limit = 1,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.StartDateGt);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date[gt]"));
        Assert.Null(parameters.StartDateGte);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date[gte]"));
        Assert.Null(parameters.StartDateLt);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date[lt]"));
        Assert.Null(parameters.StartDateLte);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date[lte]"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionFetchScheduleParams
        {
            SubscriptionID = "subscription_id",
            Limit = 1,

            Cursor = null,
            StartDateGt = null,
            StartDateGte = null,
            StartDateLt = null,
            StartDateLte = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.StartDateGt);
        Assert.True(parameters.RawQueryData.ContainsKey("start_date[gt]"));
        Assert.Null(parameters.StartDateGte);
        Assert.True(parameters.RawQueryData.ContainsKey("start_date[gte]"));
        Assert.Null(parameters.StartDateLt);
        Assert.True(parameters.RawQueryData.ContainsKey("start_date[lt]"));
        Assert.Null(parameters.StartDateLte);
        Assert.True(parameters.RawQueryData.ContainsKey("start_date[lte]"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionFetchScheduleParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            Limit = 1,
            StartDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/subscriptions/subscription_id/schedule?cursor=cursor&limit=1&start_date%5bgt%5d=2019-12-27T18%3a11%3a19.117Z&start_date%5bgte%5d=2019-12-27T18%3a11%3a19.117Z&start_date%5blt%5d=2019-12-27T18%3a11%3a19.117Z&start_date%5blte%5d=2019-12-27T18%3a11%3a19.117Z"
            ),
            url
        );
    }
}
