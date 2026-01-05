using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Alerts = Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertCreateForCustomerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Alerts::AlertCreateForCustomerParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Type = Alerts::Type.CreditBalanceDepleted,
            Thresholds = [new(0)],
        };

        string expectedCustomerID = "customer_id";
        string expectedCurrency = "currency";
        ApiEnum<string, Alerts::Type> expectedType = Alerts::Type.CreditBalanceDepleted;
        List<Alerts::Threshold> expectedThresholds = [new(0)];

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedType, parameters.Type);
        Assert.NotNull(parameters.Thresholds);
        Assert.Equal(expectedThresholds.Count, parameters.Thresholds.Count);
        for (int i = 0; i < expectedThresholds.Count; i++)
        {
            Assert.Equal(expectedThresholds[i], parameters.Thresholds[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Alerts::AlertCreateForCustomerParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Type = Alerts::Type.CreditBalanceDepleted,
        };

        Assert.Null(parameters.Thresholds);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholds"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Alerts::AlertCreateForCustomerParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Type = Alerts::Type.CreditBalanceDepleted,

            Thresholds = null,
        };

        Assert.Null(parameters.Thresholds);
        Assert.True(parameters.RawBodyData.ContainsKey("thresholds"));
    }

    [Fact]
    public void Url_Works()
    {
        Alerts::AlertCreateForCustomerParams parameters = new()
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Type = Alerts::Type.CreditBalanceDepleted,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/alerts/customer_id/customer_id"), url);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Alerts::Type.CreditBalanceDepleted)]
    [InlineData(Alerts::Type.CreditBalanceDropped)]
    [InlineData(Alerts::Type.CreditBalanceRecovered)]
    public void Validation_Works(Alerts::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Alerts::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Alerts::Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Alerts::Type.CreditBalanceDepleted)]
    [InlineData(Alerts::Type.CreditBalanceDropped)]
    [InlineData(Alerts::Type.CreditBalanceRecovered)]
    public void SerializationRoundtrip_Works(Alerts::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Alerts::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Alerts::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Alerts::Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Alerts::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
