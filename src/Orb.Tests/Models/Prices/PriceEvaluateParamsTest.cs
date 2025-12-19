using System;
using System.Collections.Generic;
using Orb.Models.Prices;

namespace Orb.Tests.Models.Prices;

public class PriceEvaluateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PriceEvaluateParams
        {
            PriceID = "price_id",
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
        };

        string expectedPriceID = "price_id";
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        string expectedExternalCustomerID = "external_customer_id";
        string expectedFilter = "my_numeric_property > 100 AND my_other_property = 'bar'";
        List<string> expectedGroupingKeys =
        [
            "case when my_event_type = 'foo' then true else false end",
        ];

        Assert.Equal(expectedPriceID, parameters.PriceID);
        Assert.Equal(expectedTimeframeEnd, parameters.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, parameters.TimeframeStart);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
        Assert.Equal(expectedFilter, parameters.Filter);
        Assert.NotNull(parameters.GroupingKeys);
        Assert.Equal(expectedGroupingKeys.Count, parameters.GroupingKeys.Count);
        for (int i = 0; i < expectedGroupingKeys.Count; i++)
        {
            Assert.Equal(expectedGroupingKeys[i], parameters.GroupingKeys[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PriceEvaluateParams
        {
            PriceID = "price_id",
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
        };

        Assert.Null(parameters.GroupingKeys);
        Assert.False(parameters.RawBodyData.ContainsKey("grouping_keys"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PriceEvaluateParams
        {
            PriceID = "price_id",
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",

            // Null should be interpreted as omitted for these properties
            GroupingKeys = null,
        };

        Assert.Null(parameters.GroupingKeys);
        Assert.False(parameters.RawBodyData.ContainsKey("grouping_keys"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PriceEvaluateParams
        {
            PriceID = "price_id",
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
        };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PriceEvaluateParams
        {
            PriceID = "price_id",
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],

            CustomerID = null,
            ExternalCustomerID = null,
            Filter = null,
        };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
    }
}
