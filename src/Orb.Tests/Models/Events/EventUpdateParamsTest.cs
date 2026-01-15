using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventUpdateParams
        {
            EventID = "event_id",
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
        };

        string expectedEventID = "event_id";
        string expectedEventName = "event_name";
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z");
        string expectedCustomerID = "customer_id";
        string expectedExternalCustomerID = "external_customer_id";

        Assert.Equal(expectedEventID, parameters.EventID);
        Assert.Equal(expectedEventName, parameters.EventName);
        Assert.Equal(expectedProperties.Count, parameters.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(parameters.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Properties[item.Key]));
        }
        Assert.Equal(expectedTimestamp, parameters.Timestamp);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventUpdateParams
        {
            EventID = "event_id",
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
        };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_customer_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EventUpdateParams
        {
            EventID = "event_id",
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),

            CustomerID = null,
            ExternalCustomerID = null,
        };

        Assert.Null(parameters.CustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_customer_id"));
    }

    [Fact]
    public void Url_Works()
    {
        EventUpdateParams parameters = new()
        {
            EventID = "event_id",
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/events/event_id"), url);
    }
}
