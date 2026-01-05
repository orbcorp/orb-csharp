using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cursor = "cursor",
            CustomerID = ["string"],
            ExternalCustomerID = ["string"],
            ExternalPlanID = "external_plan_id",
            Limit = 1,
            PlanID = "plan_id",
            Status = Status.Active,
        };

        DateTimeOffset expectedCreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCursor = "cursor";
        List<string> expectedCustomerID = ["string"];
        List<string> expectedExternalCustomerID = ["string"];
        string expectedExternalPlanID = "external_plan_id";
        long expectedLimit = 1;
        string expectedPlanID = "plan_id";
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedCreatedAtGt, parameters.CreatedAtGt);
        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLt, parameters.CreatedAtLt);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.NotNull(parameters.CustomerID);
        Assert.Equal(expectedCustomerID.Count, parameters.CustomerID.Count);
        for (int i = 0; i < expectedCustomerID.Count; i++)
        {
            Assert.Equal(expectedCustomerID[i], parameters.CustomerID[i]);
        }
        Assert.NotNull(parameters.ExternalCustomerID);
        Assert.Equal(expectedExternalCustomerID.Count, parameters.ExternalCustomerID.Count);
        for (int i = 0; i < expectedExternalCustomerID.Count; i++)
        {
            Assert.Equal(expectedExternalCustomerID[i], parameters.ExternalCustomerID[i]);
        }
        Assert.Equal(expectedExternalPlanID, parameters.ExternalPlanID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cursor = "cursor",
            CustomerID = ["string"],
            ExternalCustomerID = ["string"],
            ExternalPlanID = "external_plan_id",
            PlanID = "plan_id",
            Status = Status.Active,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cursor = "cursor",
            CustomerID = ["string"],
            ExternalCustomerID = ["string"],
            ExternalPlanID = "external_plan_id",
            PlanID = "plan_id",
            Status = Status.Active,

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams { Limit = 1 };

        Assert.Null(parameters.CreatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.ExternalPlanID);
        Assert.False(parameters.RawQueryData.ContainsKey("external_plan_id"));
        Assert.Null(parameters.PlanID);
        Assert.False(parameters.RawQueryData.ContainsKey("plan_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionListParams
        {
            Limit = 1,

            CreatedAtGt = null,
            CreatedAtGte = null,
            CreatedAtLt = null,
            CreatedAtLte = null,
            Cursor = null,
            CustomerID = null,
            ExternalCustomerID = null,
            ExternalPlanID = null,
            PlanID = null,
            Status = null,
        };

        Assert.Null(parameters.CreatedAtGt);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.CustomerID);
        Assert.True(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.True(parameters.RawQueryData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.ExternalPlanID);
        Assert.True(parameters.RawQueryData.ContainsKey("external_plan_id"));
        Assert.Null(parameters.PlanID);
        Assert.True(parameters.RawQueryData.ContainsKey("plan_id"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionListParams parameters = new()
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cursor = "cursor",
            CustomerID = ["string"],
            ExternalCustomerID = ["string"],
            ExternalPlanID = "external_plan_id",
            Limit = 1,
            PlanID = "plan_id",
            Status = Status.Active,
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/subscriptions?created_at%5bgt%5d=2019-12-27T18%3a11%3a19.117Z&created_at%5bgte%5d=2019-12-27T18%3a11%3a19.117Z&created_at%5blt%5d=2019-12-27T18%3a11%3a19.117Z&created_at%5blte%5d=2019-12-27T18%3a11%3a19.117Z&cursor=cursor&customer_id%5b%5d=string&external_customer_id%5b%5d=string&external_plan_id=external_plan_id&limit=1&plan_id=plan_id&status=active"
            ),
            url
        );
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Ended)]
    [InlineData(Status.Upcoming)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Ended)]
    [InlineData(Status.Upcoming)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
