using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertCreateForExternalCustomerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlertCreateForExternalCustomerParams
        {
            ExternalCustomerID = "external_customer_id",
            Currency = "currency",
            Type = AlertCreateForExternalCustomerParamsType.CreditBalanceDepleted,
            Thresholds = [new(0)],
        };

        string expectedExternalCustomerID = "external_customer_id";
        string expectedCurrency = "currency";
        ApiEnum<string, AlertCreateForExternalCustomerParamsType> expectedType =
            AlertCreateForExternalCustomerParamsType.CreditBalanceDepleted;
        List<Threshold> expectedThresholds = [new(0)];

        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
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
        var parameters = new AlertCreateForExternalCustomerParams
        {
            ExternalCustomerID = "external_customer_id",
            Currency = "currency",
            Type = AlertCreateForExternalCustomerParamsType.CreditBalanceDepleted,
        };

        Assert.Null(parameters.Thresholds);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholds"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AlertCreateForExternalCustomerParams
        {
            ExternalCustomerID = "external_customer_id",
            Currency = "currency",
            Type = AlertCreateForExternalCustomerParamsType.CreditBalanceDepleted,

            Thresholds = null,
        };

        Assert.Null(parameters.Thresholds);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholds"));
    }
}

public class AlertCreateForExternalCustomerParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(AlertCreateForExternalCustomerParamsType.CreditBalanceDepleted)]
    [InlineData(AlertCreateForExternalCustomerParamsType.CreditBalanceDropped)]
    [InlineData(AlertCreateForExternalCustomerParamsType.CreditBalanceRecovered)]
    public void Validation_Works(AlertCreateForExternalCustomerParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForExternalCustomerParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForExternalCustomerParamsType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AlertCreateForExternalCustomerParamsType.CreditBalanceDepleted)]
    [InlineData(AlertCreateForExternalCustomerParamsType.CreditBalanceDropped)]
    [InlineData(AlertCreateForExternalCustomerParamsType.CreditBalanceRecovered)]
    public void SerializationRoundtrip_Works(AlertCreateForExternalCustomerParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForExternalCustomerParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForExternalCustomerParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForExternalCustomerParamsType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForExternalCustomerParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
