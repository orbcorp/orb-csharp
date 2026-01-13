using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionFetchUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionFetchUsageParams
        {
            SubscriptionID = "subscription_id",
            BillableMetricID = "billable_metric_id",
            FirstDimensionKey = "first_dimension_key",
            FirstDimensionValue = "first_dimension_value",
            Granularity = Granularity.Day,
            GroupBy = "group_by",
            SecondDimensionKey = "second_dimension_key",
            SecondDimensionValue = "second_dimension_value",
            TimeframeEnd = DateTimeOffset.Parse("2022-03-01T05:00:00Z"),
            TimeframeStart = DateTimeOffset.Parse("2022-02-01T05:00:00Z"),
            ViewMode = SubscriptionFetchUsageParamsViewMode.Periodic,
        };

        string expectedSubscriptionID = "subscription_id";
        string expectedBillableMetricID = "billable_metric_id";
        string expectedFirstDimensionKey = "first_dimension_key";
        string expectedFirstDimensionValue = "first_dimension_value";
        ApiEnum<string, Granularity> expectedGranularity = Granularity.Day;
        string expectedGroupBy = "group_by";
        string expectedSecondDimensionKey = "second_dimension_key";
        string expectedSecondDimensionValue = "second_dimension_value";
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2022-03-01T05:00:00Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2022-02-01T05:00:00Z");
        ApiEnum<string, SubscriptionFetchUsageParamsViewMode> expectedViewMode =
            SubscriptionFetchUsageParamsViewMode.Periodic;

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedBillableMetricID, parameters.BillableMetricID);
        Assert.Equal(expectedFirstDimensionKey, parameters.FirstDimensionKey);
        Assert.Equal(expectedFirstDimensionValue, parameters.FirstDimensionValue);
        Assert.Equal(expectedGranularity, parameters.Granularity);
        Assert.Equal(expectedGroupBy, parameters.GroupBy);
        Assert.Equal(expectedSecondDimensionKey, parameters.SecondDimensionKey);
        Assert.Equal(expectedSecondDimensionValue, parameters.SecondDimensionValue);
        Assert.Equal(expectedTimeframeEnd, parameters.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, parameters.TimeframeStart);
        Assert.Equal(expectedViewMode, parameters.ViewMode);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionFetchUsageParams { SubscriptionID = "subscription_id" };

        Assert.Null(parameters.BillableMetricID);
        Assert.False(parameters.RawQueryData.ContainsKey("billable_metric_id"));
        Assert.Null(parameters.FirstDimensionKey);
        Assert.False(parameters.RawQueryData.ContainsKey("first_dimension_key"));
        Assert.Null(parameters.FirstDimensionValue);
        Assert.False(parameters.RawQueryData.ContainsKey("first_dimension_value"));
        Assert.Null(parameters.Granularity);
        Assert.False(parameters.RawQueryData.ContainsKey("granularity"));
        Assert.Null(parameters.GroupBy);
        Assert.False(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.SecondDimensionKey);
        Assert.False(parameters.RawQueryData.ContainsKey("second_dimension_key"));
        Assert.Null(parameters.SecondDimensionValue);
        Assert.False(parameters.RawQueryData.ContainsKey("second_dimension_value"));
        Assert.Null(parameters.TimeframeEnd);
        Assert.False(parameters.RawQueryData.ContainsKey("timeframe_end"));
        Assert.Null(parameters.TimeframeStart);
        Assert.False(parameters.RawQueryData.ContainsKey("timeframe_start"));
        Assert.Null(parameters.ViewMode);
        Assert.False(parameters.RawQueryData.ContainsKey("view_mode"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionFetchUsageParams
        {
            SubscriptionID = "subscription_id",

            BillableMetricID = null,
            FirstDimensionKey = null,
            FirstDimensionValue = null,
            Granularity = null,
            GroupBy = null,
            SecondDimensionKey = null,
            SecondDimensionValue = null,
            TimeframeEnd = null,
            TimeframeStart = null,
            ViewMode = null,
        };

        Assert.Null(parameters.BillableMetricID);
        Assert.True(parameters.RawQueryData.ContainsKey("billable_metric_id"));
        Assert.Null(parameters.FirstDimensionKey);
        Assert.True(parameters.RawQueryData.ContainsKey("first_dimension_key"));
        Assert.Null(parameters.FirstDimensionValue);
        Assert.True(parameters.RawQueryData.ContainsKey("first_dimension_value"));
        Assert.Null(parameters.Granularity);
        Assert.True(parameters.RawQueryData.ContainsKey("granularity"));
        Assert.Null(parameters.GroupBy);
        Assert.True(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.SecondDimensionKey);
        Assert.True(parameters.RawQueryData.ContainsKey("second_dimension_key"));
        Assert.Null(parameters.SecondDimensionValue);
        Assert.True(parameters.RawQueryData.ContainsKey("second_dimension_value"));
        Assert.Null(parameters.TimeframeEnd);
        Assert.True(parameters.RawQueryData.ContainsKey("timeframe_end"));
        Assert.Null(parameters.TimeframeStart);
        Assert.True(parameters.RawQueryData.ContainsKey("timeframe_start"));
        Assert.Null(parameters.ViewMode);
        Assert.True(parameters.RawQueryData.ContainsKey("view_mode"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionFetchUsageParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            BillableMetricID = "billable_metric_id",
            FirstDimensionKey = "first_dimension_key",
            FirstDimensionValue = "first_dimension_value",
            Granularity = Granularity.Day,
            GroupBy = "group_by",
            SecondDimensionKey = "second_dimension_key",
            SecondDimensionValue = "second_dimension_value",
            TimeframeEnd = DateTimeOffset.Parse("2022-03-01T05:00:00+00:00"),
            TimeframeStart = DateTimeOffset.Parse("2022-02-01T05:00:00+00:00"),
            ViewMode = SubscriptionFetchUsageParamsViewMode.Periodic,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/subscriptions/subscription_id/usage?billable_metric_id=billable_metric_id&first_dimension_key=first_dimension_key&first_dimension_value=first_dimension_value&granularity=day&group_by=group_by&second_dimension_key=second_dimension_key&second_dimension_value=second_dimension_value&timeframe_end=2022-03-01T05%3a00%3a00%2b00%3a00&timeframe_start=2022-02-01T05%3a00%3a00%2b00%3a00&view_mode=periodic"
            ),
            url
        );
    }
}

public class GranularityTest : TestBase
{
    [Theory]
    [InlineData(Granularity.Day)]
    public void Validation_Works(Granularity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Granularity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Granularity.Day)]
    public void SerializationRoundtrip_Works(Granularity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Granularity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionFetchUsageParamsViewModeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionFetchUsageParamsViewMode.Periodic)]
    [InlineData(SubscriptionFetchUsageParamsViewMode.Cumulative)]
    public void Validation_Works(SubscriptionFetchUsageParamsViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionFetchUsageParamsViewMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionFetchUsageParamsViewMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionFetchUsageParamsViewMode.Periodic)]
    [InlineData(SubscriptionFetchUsageParamsViewMode.Cumulative)]
    public void SerializationRoundtrip_Works(SubscriptionFetchUsageParamsViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionFetchUsageParamsViewMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionFetchUsageParamsViewMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionFetchUsageParamsViewMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionFetchUsageParamsViewMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
