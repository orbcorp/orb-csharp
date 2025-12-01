using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventSearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventSearchResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CustomerID = "customer_id",
                    Deprecated = true,
                    EventName = "event_name",
                    ExternalCustomerID = "external_customer_id",
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
                },
            ],
        };

        List<Data> expectedData =
        [
            new()
            {
                ID = "id",
                CustomerID = "customer_id",
                Deprecated = true,
                EventName = "event_name",
                ExternalCustomerID = "external_customer_id",
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            CustomerID = "customer_id",
            Deprecated = true,
            EventName = "event_name",
            ExternalCustomerID = "external_customer_id",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
        };

        string expectedID = "id";
        string expectedCustomerID = "customer_id";
        bool expectedDeprecated = true;
        string expectedEventName = "event_name";
        string expectedExternalCustomerID = "external_customer_id";
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedDeprecated, model.Deprecated);
        Assert.Equal(expectedEventName, model.EventName);
        Assert.Equal(expectedExternalCustomerID, model.ExternalCustomerID);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Properties[item.Key]));
        }
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }
}
