using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class EntryStatusTest : TestBase
{
    [Theory]
    [InlineData(EntryStatus.Committed)]
    [InlineData(EntryStatus.Pending)]
    public void Validation_Works(EntryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntryStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntryStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntryStatus.Committed)]
    [InlineData(EntryStatus.Pending)]
    public void SerializationRoundtrip_Works(EntryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntryStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntryStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntryTypeTest : TestBase
{
    [Theory]
    [InlineData(EntryType.Increment)]
    [InlineData(EntryType.Decrement)]
    [InlineData(EntryType.ExpirationChange)]
    [InlineData(EntryType.CreditBlockExpiry)]
    [InlineData(EntryType.Void)]
    [InlineData(EntryType.VoidInitiated)]
    [InlineData(EntryType.Amendment)]
    public void Validation_Works(EntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntryType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntryType.Increment)]
    [InlineData(EntryType.Decrement)]
    [InlineData(EntryType.ExpirationChange)]
    [InlineData(EntryType.CreditBlockExpiry)]
    [InlineData(EntryType.Void)]
    [InlineData(EntryType.VoidInitiated)]
    [InlineData(EntryType.Amendment)]
    public void SerializationRoundtrip_Works(EntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntryType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
