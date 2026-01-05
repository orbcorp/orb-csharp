using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertCreateForSubscriptionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlertCreateForSubscriptionParams
        {
            SubscriptionID = "subscription_id",
            Thresholds = [new(0)],
            Type = AlertCreateForSubscriptionParamsType.UsageExceeded,
            MetricID = "metric_id",
        };

        string expectedSubscriptionID = "subscription_id";
        List<Threshold> expectedThresholds = [new(0)];
        ApiEnum<string, AlertCreateForSubscriptionParamsType> expectedType =
            AlertCreateForSubscriptionParamsType.UsageExceeded;
        string expectedMetricID = "metric_id";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedThresholds.Count, parameters.Thresholds.Count);
        for (int i = 0; i < expectedThresholds.Count; i++)
        {
            Assert.Equal(expectedThresholds[i], parameters.Thresholds[i]);
        }
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedMetricID, parameters.MetricID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AlertCreateForSubscriptionParams
        {
            SubscriptionID = "subscription_id",
            Thresholds = [new(0)],
            Type = AlertCreateForSubscriptionParamsType.UsageExceeded,
        };

        Assert.Null(parameters.MetricID);
        Assert.False(parameters.RawBodyData.ContainsKey("metric_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AlertCreateForSubscriptionParams
        {
            SubscriptionID = "subscription_id",
            Thresholds = [new(0)],
            Type = AlertCreateForSubscriptionParamsType.UsageExceeded,

            MetricID = null,
        };

        Assert.Null(parameters.MetricID);
        Assert.True(parameters.RawBodyData.ContainsKey("metric_id"));
    }

    [Fact]
    public void Url_Works()
    {
        AlertCreateForSubscriptionParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            Thresholds = [new(0)],
            Type = AlertCreateForSubscriptionParamsType.UsageExceeded,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/alerts/subscription_id/subscription_id"),
            url
        );
    }
}

public class AlertCreateForSubscriptionParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(AlertCreateForSubscriptionParamsType.UsageExceeded)]
    [InlineData(AlertCreateForSubscriptionParamsType.CostExceeded)]
    public void Validation_Works(AlertCreateForSubscriptionParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForSubscriptionParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AlertCreateForSubscriptionParamsType.UsageExceeded)]
    [InlineData(AlertCreateForSubscriptionParamsType.CostExceeded)]
    public void SerializationRoundtrip_Works(AlertCreateForSubscriptionParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForSubscriptionParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
