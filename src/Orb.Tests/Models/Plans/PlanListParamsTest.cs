using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Plans;

namespace Orb.Tests.Models.Plans;

public class PlanListParamsStatusTest : TestBase
{
    [Theory]
    [InlineData(PlanListParamsStatus.Active)]
    [InlineData(PlanListParamsStatus.Archived)]
    [InlineData(PlanListParamsStatus.Draft)]
    public void Validation_Works(PlanListParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListParamsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanListParamsStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListParamsStatus.Active)]
    [InlineData(PlanListParamsStatus.Archived)]
    [InlineData(PlanListParamsStatus.Draft)]
    public void SerializationRoundtrip_Works(PlanListParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListParamsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PlanListParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanListParamsStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PlanListParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
