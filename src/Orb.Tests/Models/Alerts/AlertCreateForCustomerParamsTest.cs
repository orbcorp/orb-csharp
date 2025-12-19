using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertCreateForCustomerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlertCreateForCustomerParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Type = Type.CreditBalanceDepleted,
            Thresholds = [new(0)],
        };

        string expectedCustomerID = "customer_id";
        string expectedCurrency = "currency";
        ApiEnum<string, Type> expectedType = Type.CreditBalanceDepleted;
        List<Threshold> expectedThresholds = [new(0)];

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
        var parameters = new AlertCreateForCustomerParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Type = Type.CreditBalanceDepleted,
        };

        Assert.Null(parameters.Thresholds);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholds"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AlertCreateForCustomerParams
        {
            CustomerID = "customer_id",
            Currency = "currency",
            Type = Type.CreditBalanceDepleted,

            Thresholds = null,
        };

        Assert.Null(parameters.Thresholds);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholds"));
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.CreditBalanceDepleted)]
    [InlineData(Type.CreditBalanceDropped)]
    [InlineData(Type.CreditBalanceRecovered)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.CreditBalanceDepleted)]
    [InlineData(Type.CreditBalanceDropped)]
    [InlineData(Type.CreditBalanceRecovered)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
