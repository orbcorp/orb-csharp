using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.SubscriptionChanges;

namespace Orb.Tests.Models.SubscriptionChanges;

public class SubscriptionChangeListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionChangeListResponse
        {
            ID = "id",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeListResponseStatus.Pending,
            SubscriptionID = "subscription_id",
            AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionChangeListResponseStatus> expectedStatus =
            SubscriptionChangeListResponseStatus.Pending;
        string expectedSubscriptionID = "subscription_id";
        DateTimeOffset expectedAppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExpirationTime, model.ExpirationTime);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedAppliedAt, model.AppliedAt);
        Assert.Equal(expectedCancelledAt, model.CancelledAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionChangeListResponse
        {
            ID = "id",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeListResponseStatus.Pending,
            SubscriptionID = "subscription_id",
            AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionChangeListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionChangeListResponse
        {
            ID = "id",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeListResponseStatus.Pending,
            SubscriptionID = "subscription_id",
            AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionChangeListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionChangeListResponseStatus> expectedStatus =
            SubscriptionChangeListResponseStatus.Pending;
        string expectedSubscriptionID = "subscription_id";
        DateTimeOffset expectedAppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExpirationTime, deserialized.ExpirationTime);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedAppliedAt, deserialized.AppliedAt);
        Assert.Equal(expectedCancelledAt, deserialized.CancelledAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionChangeListResponse
        {
            ID = "id",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeListResponseStatus.Pending,
            SubscriptionID = "subscription_id",
            AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionChangeListResponse
        {
            ID = "id",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeListResponseStatus.Pending,
            SubscriptionID = "subscription_id",
        };

        Assert.Null(model.AppliedAt);
        Assert.False(model.RawData.ContainsKey("applied_at"));
        Assert.Null(model.CancelledAt);
        Assert.False(model.RawData.ContainsKey("cancelled_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionChangeListResponse
        {
            ID = "id",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeListResponseStatus.Pending,
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionChangeListResponse
        {
            ID = "id",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeListResponseStatus.Pending,
            SubscriptionID = "subscription_id",

            AppliedAt = null,
            CancelledAt = null,
        };

        Assert.Null(model.AppliedAt);
        Assert.True(model.RawData.ContainsKey("applied_at"));
        Assert.Null(model.CancelledAt);
        Assert.True(model.RawData.ContainsKey("cancelled_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionChangeListResponse
        {
            ID = "id",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeListResponseStatus.Pending,
            SubscriptionID = "subscription_id",

            AppliedAt = null,
            CancelledAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionChangeListResponse
        {
            ID = "id",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeListResponseStatus.Pending,
            SubscriptionID = "subscription_id",
            AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionChangeListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionChangeListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionChangeListResponseStatus.Pending)]
    [InlineData(SubscriptionChangeListResponseStatus.Applied)]
    [InlineData(SubscriptionChangeListResponseStatus.Cancelled)]
    public void Validation_Works(SubscriptionChangeListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionChangeListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionChangeListResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionChangeListResponseStatus.Pending)]
    [InlineData(SubscriptionChangeListResponseStatus.Applied)]
    [InlineData(SubscriptionChangeListResponseStatus.Cancelled)]
    public void SerializationRoundtrip_Works(SubscriptionChangeListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionChangeListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionChangeListResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionChangeListResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionChangeListResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
