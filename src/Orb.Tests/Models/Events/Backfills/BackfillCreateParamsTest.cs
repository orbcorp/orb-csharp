using System;
using Orb.Models.Events.Backfills;

namespace Orb.Tests.Models.Events.Backfills;

public class BackfillCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BackfillCreateParams
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            ExternalCustomerID = "external_customer_id",
            ReplaceExistingEvents = true,
        };

        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        string expectedDeprecationFilter =
            "my_numeric_property > 100 AND my_other_property = 'bar'";
        string expectedExternalCustomerID = "external_customer_id";
        bool expectedReplaceExistingEvents = true;

        Assert.Equal(expectedTimeframeEnd, parameters.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, parameters.TimeframeStart);
        Assert.Equal(expectedCloseTime, parameters.CloseTime);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedDeprecationFilter, parameters.DeprecationFilter);
        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
        Assert.Equal(expectedReplaceExistingEvents, parameters.ReplaceExistingEvents);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BackfillCreateParams
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            ExternalCustomerID = "external_customer_id",
        };

        Assert.Null(parameters.ReplaceExistingEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("replace_existing_events"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BackfillCreateParams
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            ExternalCustomerID = "external_customer_id",

            // Null should be interpreted as omitted for these properties
            ReplaceExistingEvents = null,
        };

        Assert.Null(parameters.ReplaceExistingEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("replace_existing_events"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BackfillCreateParams
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReplaceExistingEvents = true,
        };

        Assert.Null(parameters.CloseTime);
        Assert.False(parameters.RawBodyData.ContainsKey("close_time"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.DeprecationFilter);
        Assert.False(parameters.RawBodyData.ContainsKey("deprecation_filter"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_customer_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BackfillCreateParams
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReplaceExistingEvents = true,

            CloseTime = null,
            CustomerID = null,
            DeprecationFilter = null,
            ExternalCustomerID = null,
        };

        Assert.Null(parameters.CloseTime);
        Assert.True(parameters.RawBodyData.ContainsKey("close_time"));
        Assert.Null(parameters.CustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.DeprecationFilter);
        Assert.True(parameters.RawBodyData.ContainsKey("deprecation_filter"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_customer_id"));
    }

    [Fact]
    public void Url_Works()
    {
        BackfillCreateParams parameters = new()
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/events/backfills"), url);
    }
}
