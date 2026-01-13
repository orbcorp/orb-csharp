using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionUpdateTrialParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUpdateTrialParams
        {
            SubscriptionID = "subscription_id",
            TrialEndDate = DateTimeOffset.Parse("2017-07-21T17:32:28Z"),
            Shift = true,
        };

        string expectedSubscriptionID = "subscription_id";
        TrialEndDate expectedTrialEndDate = DateTimeOffset.Parse("2017-07-21T17:32:28Z");
        bool expectedShift = true;

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedTrialEndDate, parameters.TrialEndDate);
        Assert.Equal(expectedShift, parameters.Shift);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateTrialParams
        {
            SubscriptionID = "subscription_id",
            TrialEndDate = DateTimeOffset.Parse("2017-07-21T17:32:28Z"),
        };

        Assert.Null(parameters.Shift);
        Assert.False(parameters.RawBodyData.ContainsKey("shift"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateTrialParams
        {
            SubscriptionID = "subscription_id",
            TrialEndDate = DateTimeOffset.Parse("2017-07-21T17:32:28Z"),

            // Null should be interpreted as omitted for these properties
            Shift = null,
        };

        Assert.Null(parameters.Shift);
        Assert.False(parameters.RawBodyData.ContainsKey("shift"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionUpdateTrialParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            TrialEndDate = DateTimeOffset.Parse("2017-07-21T17:32:28Z"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/subscriptions/subscription_id/update_trial"),
            url
        );
    }
}

public class TrialEndDateTest : TestBase
{
    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        TrialEndDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void UnionMember1ValidationWorks()
    {
        TrialEndDate value = UnionMember1.Immediate;
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        TrialEndDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TrialEndDate>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember1SerializationRoundtripWorks()
    {
        TrialEndDate value = UnionMember1.Immediate;
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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
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
