using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Costs;

namespace Orb.Tests.Models.Customers.Costs;

public class CostListByExternalIDParamsViewModeTest : TestBase
{
    [Theory]
    [InlineData(CostListByExternalIDParamsViewMode.Periodic)]
    [InlineData(CostListByExternalIDParamsViewMode.Cumulative)]
    public void Validation_Works(CostListByExternalIDParamsViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CostListByExternalIDParamsViewMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CostListByExternalIDParamsViewMode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CostListByExternalIDParamsViewMode.Periodic)]
    [InlineData(CostListByExternalIDParamsViewMode.Cumulative)]
    public void SerializationRoundtrip_Works(CostListByExternalIDParamsViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CostListByExternalIDParamsViewMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CostListByExternalIDParamsViewMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CostListByExternalIDParamsViewMode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CostListByExternalIDParamsViewMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
