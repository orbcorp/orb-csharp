using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.SubscriptionChanges;

namespace Orb.Tests.Models.SubscriptionChanges;

public class SubscriptionChangeListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionChangeListParams
        {
            Cursor = "cursor",
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
            Limit = 1,
            Status = Status.Pending,
        };

        string expectedCursor = "cursor";
        string expectedCustomerID = "customer_id";
        string expectedExternalCustomerID = "external_customer_id";
        long expectedLimit = 1;
        ApiEnum<string, Status> expectedStatus = Status.Pending;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionChangeListParams
        {
            Cursor = "cursor",
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
            Status = Status.Pending,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionChangeListParams
        {
            Cursor = "cursor",
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
            Status = Status.Pending,

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionChangeListParams { Limit = 1 };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionChangeListParams
        {
            Limit = 1,

            Cursor = null,
            CustomerID = null,
            ExternalCustomerID = null,
            Status = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.CustomerID);
        Assert.True(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.True(parameters.RawQueryData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionChangeListParams parameters = new()
        {
            Cursor = "cursor",
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
            Limit = 1,
            Status = Status.Pending,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/subscription_changes?cursor=cursor&customer_id=customer_id&external_customer_id=external_customer_id&limit=1&status=pending"
            ),
            url
        );
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Applied)]
    [InlineData(Status.Cancelled)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Applied)]
    [InlineData(Status.Cancelled)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
