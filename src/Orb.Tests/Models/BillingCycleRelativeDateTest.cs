using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class BillingCycleRelativeDateTest : TestBase
{
    [Theory]
    [InlineData(BillingCycleRelativeDate.StartOfTerm)]
    [InlineData(BillingCycleRelativeDate.EndOfTerm)]
    public void Validation_Works(BillingCycleRelativeDate rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingCycleRelativeDate> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BillingCycleRelativeDate.StartOfTerm)]
    [InlineData(BillingCycleRelativeDate.EndOfTerm)]
    public void SerializationRoundtrip_Works(BillingCycleRelativeDate rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingCycleRelativeDate> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
