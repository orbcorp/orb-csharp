using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

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
