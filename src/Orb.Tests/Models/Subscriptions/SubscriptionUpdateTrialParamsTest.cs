using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class TrialEndDateTest : TestBase
{
    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        TrialEndDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        value.Validate();
    }

    [Fact]
    public void UnionMember1ValidationWorks()
    {
        TrialEndDate value = new(UnionMember1.Immediate);
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        TrialEndDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TrialEndDate>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember1SerializationRoundtripWorks()
    {
        TrialEndDate value = new(UnionMember1.Immediate);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TrialEndDate>(element);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember1Test : TestBase
{
    [Theory]
    [InlineData(UnionMember1.Immediate)]
    public void Validation_Works(UnionMember1 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember1> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember1.Immediate)]
    public void SerializationRoundtrip_Works(UnionMember1 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember1> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
