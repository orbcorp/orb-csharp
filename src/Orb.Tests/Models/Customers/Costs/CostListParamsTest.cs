using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Costs;

namespace Orb.Tests.Models.Customers.Costs;

public class CostListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CostListParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            TimeframeEnd = DateTimeOffset.Parse("2022-03-01T05:00:00Z"),
            TimeframeStart = DateTimeOffset.Parse("2022-02-01T05:00:00Z"),
            ViewMode = ViewMode.Periodic,
        };

        string expectedCustomerID = "customer_id";
        string expectedCurrency = "currency";
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2022-03-01T05:00:00Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2022-02-01T05:00:00Z");
        ApiEnum<string, ViewMode> expectedViewMode = ViewMode.Periodic;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedTimeframeEnd, parameters.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, parameters.TimeframeStart);
        Assert.Equal(expectedViewMode, parameters.ViewMode);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CostListParams { CustomerID = "customer_id" };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
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
        var parameters = new CostListParams
        {
            CustomerID = "customer_id",

            Currency = null,
            TimeframeEnd = null,
            TimeframeStart = null,
            ViewMode = null,
        };

        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawQueryData.ContainsKey("currency"));
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
        CostListParams parameters = new()
        {
            CustomerID = "customer_id",
            Currency = "currency",
            TimeframeEnd = DateTimeOffset.Parse("2022-03-01T05:00:00Z"),
            TimeframeStart = DateTimeOffset.Parse("2022-02-01T05:00:00Z"),
            ViewMode = ViewMode.Periodic,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/customers/customer_id/costs?currency=currency&timeframe_end=2022-03-01T05%3a00%3a00%2b00%3a00&timeframe_start=2022-02-01T05%3a00%3a00%2b00%3a00&view_mode=periodic"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CostListParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            TimeframeEnd = DateTimeOffset.Parse("2022-03-01T05:00:00Z"),
            TimeframeStart = DateTimeOffset.Parse("2022-02-01T05:00:00Z"),
            ViewMode = ViewMode.Periodic,
        };

        CostListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ViewModeTest : TestBase
{
    [Theory]
    [InlineData(ViewMode.Periodic)]
    [InlineData(ViewMode.Cumulative)]
    public void Validation_Works(ViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewMode.Periodic)]
    [InlineData(ViewMode.Cumulative)]
    public void SerializationRoundtrip_Works(ViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ViewMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ViewMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
