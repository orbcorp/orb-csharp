using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventIngestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventIngestParams
        {
            Events =
            [
                new()
                {
                    EventName = "event_name",
                    IdempotencyKey = "idempotency_key",
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
                    CustomerID = "customer_id",
                    ExternalCustomerID = "external_customer_id",
                },
            ],
            BackfillID = "backfill_id",
            Debug = true,
        };

        List<Event> expectedEvents =
        [
            new()
            {
                EventName = "event_name",
                IdempotencyKey = "idempotency_key",
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
                CustomerID = "customer_id",
                ExternalCustomerID = "external_customer_id",
            },
        ];
        string expectedBackfillID = "backfill_id";
        bool expectedDebug = true;

        Assert.Equal(expectedEvents.Count, parameters.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], parameters.Events[i]);
        }
        Assert.Equal(expectedBackfillID, parameters.BackfillID);
        Assert.Equal(expectedDebug, parameters.Debug);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventIngestParams
        {
            Events =
            [
                new()
                {
                    EventName = "event_name",
                    IdempotencyKey = "idempotency_key",
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
                    CustomerID = "customer_id",
                    ExternalCustomerID = "external_customer_id",
                },
            ],
            BackfillID = "backfill_id",
        };

        Assert.Null(parameters.Debug);
        Assert.False(parameters.RawQueryData.ContainsKey("debug"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventIngestParams
        {
            Events =
            [
                new()
                {
                    EventName = "event_name",
                    IdempotencyKey = "idempotency_key",
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
                    CustomerID = "customer_id",
                    ExternalCustomerID = "external_customer_id",
                },
            ],
            BackfillID = "backfill_id",

            // Null should be interpreted as omitted for these properties
            Debug = null,
        };

        Assert.Null(parameters.Debug);
        Assert.False(parameters.RawQueryData.ContainsKey("debug"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventIngestParams
        {
            Events =
            [
                new()
                {
                    EventName = "event_name",
                    IdempotencyKey = "idempotency_key",
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
                    CustomerID = "customer_id",
                    ExternalCustomerID = "external_customer_id",
                },
            ],
            Debug = true,
        };

        Assert.Null(parameters.BackfillID);
        Assert.False(parameters.RawQueryData.ContainsKey("backfill_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EventIngestParams
        {
            Events =
            [
                new()
                {
                    EventName = "event_name",
                    IdempotencyKey = "idempotency_key",
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
                    CustomerID = "customer_id",
                    ExternalCustomerID = "external_customer_id",
                },
            ],
            Debug = true,

            BackfillID = null,
        };

        Assert.Null(parameters.BackfillID);
        Assert.True(parameters.RawQueryData.ContainsKey("backfill_id"));
    }

    [Fact]
    public void Url_Works()
    {
        EventIngestParams parameters = new()
        {
            Events =
            [
                new()
                {
                    EventName = "event_name",
                    IdempotencyKey = "idempotency_key",
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
                    CustomerID = "customer_id",
                    ExternalCustomerID = "external_customer_id",
                },
            ],
            BackfillID = "backfill_id",
            Debug = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/ingest?backfill_id=backfill_id&debug=true"),
            url
        );
    }
}

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            IdempotencyKey = "idempotency_key",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
        };

        string expectedEventName = "event_name";
        string expectedIdempotencyKey = "idempotency_key";
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z");
        string expectedCustomerID = "customer_id";
        string expectedExternalCustomerID = "external_customer_id";

        Assert.Equal(expectedEventName, model.EventName);
        Assert.Equal(expectedIdempotencyKey, model.IdempotencyKey);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Properties[item.Key]));
        }
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedExternalCustomerID, model.ExternalCustomerID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            IdempotencyKey = "idempotency_key",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            IdempotencyKey = "idempotency_key",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedEventName = "event_name";
        string expectedIdempotencyKey = "idempotency_key";
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z");
        string expectedCustomerID = "customer_id";
        string expectedExternalCustomerID = "external_customer_id";

        Assert.Equal(expectedEventName, deserialized.EventName);
        Assert.Equal(expectedIdempotencyKey, deserialized.IdempotencyKey);
        Assert.Equal(expectedProperties.Count, deserialized.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(deserialized.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Properties[item.Key]));
        }
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedExternalCustomerID, deserialized.ExternalCustomerID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            IdempotencyKey = "idempotency_key",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            IdempotencyKey = "idempotency_key",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
        };

        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.ExternalCustomerID);
        Assert.False(model.RawData.ContainsKey("external_customer_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            IdempotencyKey = "idempotency_key",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            IdempotencyKey = "idempotency_key",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),

            CustomerID = null,
            ExternalCustomerID = null,
        };

        Assert.Null(model.CustomerID);
        Assert.True(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.ExternalCustomerID);
        Assert.True(model.RawData.ContainsKey("external_customer_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            IdempotencyKey = "idempotency_key",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),

            CustomerID = null,
            ExternalCustomerID = null,
        };

        model.Validate();
    }
}
