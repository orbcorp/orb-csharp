using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Events.Backfills;

namespace Orb.Tests.Models.Events.Backfills;

public class BackfillFetchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BackfillFetchResponse
        {
            ID = "id",
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EventsIngested = 0,
            ReplaceExistingEvents = true,
            RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = BackfillFetchResponseStatus.Pending,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
        };

        string expectedID = "id";
        DateTimeOffset expectedCloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        long expectedEventsIngested = 0;
        bool expectedReplaceExistingEvents = true;
        DateTimeOffset expectedRevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BackfillFetchResponseStatus> expectedStatus =
            BackfillFetchResponseStatus.Pending;
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeprecationFilter =
            "my_numeric_property > 100 AND my_other_property = 'bar'";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCloseTime, model.CloseTime);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEventsIngested, model.EventsIngested);
        Assert.Equal(expectedReplaceExistingEvents, model.ReplaceExistingEvents);
        Assert.Equal(expectedRevertedAt, model.RevertedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimeframeEnd, model.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, model.TimeframeStart);
        Assert.Equal(expectedDeprecationFilter, model.DeprecationFilter);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BackfillFetchResponse
        {
            ID = "id",
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EventsIngested = 0,
            ReplaceExistingEvents = true,
            RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = BackfillFetchResponseStatus.Pending,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BackfillFetchResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BackfillFetchResponse
        {
            ID = "id",
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EventsIngested = 0,
            ReplaceExistingEvents = true,
            RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = BackfillFetchResponseStatus.Pending,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BackfillFetchResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        long expectedEventsIngested = 0;
        bool expectedReplaceExistingEvents = true;
        DateTimeOffset expectedRevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BackfillFetchResponseStatus> expectedStatus =
            BackfillFetchResponseStatus.Pending;
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeprecationFilter =
            "my_numeric_property > 100 AND my_other_property = 'bar'";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCloseTime, deserialized.CloseTime);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEventsIngested, deserialized.EventsIngested);
        Assert.Equal(expectedReplaceExistingEvents, deserialized.ReplaceExistingEvents);
        Assert.Equal(expectedRevertedAt, deserialized.RevertedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimeframeEnd, deserialized.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, deserialized.TimeframeStart);
        Assert.Equal(expectedDeprecationFilter, deserialized.DeprecationFilter);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BackfillFetchResponse
        {
            ID = "id",
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EventsIngested = 0,
            ReplaceExistingEvents = true,
            RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = BackfillFetchResponseStatus.Pending,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BackfillFetchResponse
        {
            ID = "id",
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EventsIngested = 0,
            ReplaceExistingEvents = true,
            RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = BackfillFetchResponseStatus.Pending,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.DeprecationFilter);
        Assert.False(model.RawData.ContainsKey("deprecation_filter"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BackfillFetchResponse
        {
            ID = "id",
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EventsIngested = 0,
            ReplaceExistingEvents = true,
            RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = BackfillFetchResponseStatus.Pending,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BackfillFetchResponse
        {
            ID = "id",
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EventsIngested = 0,
            ReplaceExistingEvents = true,
            RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = BackfillFetchResponseStatus.Pending,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            DeprecationFilter = null,
        };

        Assert.Null(model.DeprecationFilter);
        Assert.True(model.RawData.ContainsKey("deprecation_filter"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BackfillFetchResponse
        {
            ID = "id",
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EventsIngested = 0,
            ReplaceExistingEvents = true,
            RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = BackfillFetchResponseStatus.Pending,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            DeprecationFilter = null,
        };

        model.Validate();
    }
}

public class BackfillFetchResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(BackfillFetchResponseStatus.Pending)]
    [InlineData(BackfillFetchResponseStatus.Reflected)]
    [InlineData(BackfillFetchResponseStatus.PendingRevert)]
    [InlineData(BackfillFetchResponseStatus.Reverted)]
    public void Validation_Works(BackfillFetchResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BackfillFetchResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BackfillFetchResponseStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BackfillFetchResponseStatus.Pending)]
    [InlineData(BackfillFetchResponseStatus.Reflected)]
    [InlineData(BackfillFetchResponseStatus.PendingRevert)]
    [InlineData(BackfillFetchResponseStatus.Reverted)]
    public void SerializationRoundtrip_Works(BackfillFetchResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BackfillFetchResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BackfillFetchResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BackfillFetchResponseStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BackfillFetchResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
