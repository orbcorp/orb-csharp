using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class LedgerListByExternalIDParamsEntryStatusTest : TestBase
{
    [Theory]
    [InlineData(LedgerListByExternalIDParamsEntryStatus.Committed)]
    [InlineData(LedgerListByExternalIDParamsEntryStatus.Pending)]
    public void Validation_Works(LedgerListByExternalIDParamsEntryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LedgerListByExternalIDParamsEntryStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LedgerListByExternalIDParamsEntryStatus>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LedgerListByExternalIDParamsEntryStatus.Committed)]
    [InlineData(LedgerListByExternalIDParamsEntryStatus.Pending)]
    public void SerializationRoundtrip_Works(LedgerListByExternalIDParamsEntryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LedgerListByExternalIDParamsEntryStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LedgerListByExternalIDParamsEntryStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LedgerListByExternalIDParamsEntryStatus>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LedgerListByExternalIDParamsEntryStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class LedgerListByExternalIDParamsEntryTypeTest : TestBase
{
    [Theory]
    [InlineData(LedgerListByExternalIDParamsEntryType.Increment)]
    [InlineData(LedgerListByExternalIDParamsEntryType.Decrement)]
    [InlineData(LedgerListByExternalIDParamsEntryType.ExpirationChange)]
    [InlineData(LedgerListByExternalIDParamsEntryType.CreditBlockExpiry)]
    [InlineData(LedgerListByExternalIDParamsEntryType.Void)]
    [InlineData(LedgerListByExternalIDParamsEntryType.VoidInitiated)]
    [InlineData(LedgerListByExternalIDParamsEntryType.Amendment)]
    public void Validation_Works(LedgerListByExternalIDParamsEntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LedgerListByExternalIDParamsEntryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LedgerListByExternalIDParamsEntryType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LedgerListByExternalIDParamsEntryType.Increment)]
    [InlineData(LedgerListByExternalIDParamsEntryType.Decrement)]
    [InlineData(LedgerListByExternalIDParamsEntryType.ExpirationChange)]
    [InlineData(LedgerListByExternalIDParamsEntryType.CreditBlockExpiry)]
    [InlineData(LedgerListByExternalIDParamsEntryType.Void)]
    [InlineData(LedgerListByExternalIDParamsEntryType.VoidInitiated)]
    [InlineData(LedgerListByExternalIDParamsEntryType.Amendment)]
    public void SerializationRoundtrip_Works(LedgerListByExternalIDParamsEntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LedgerListByExternalIDParamsEntryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LedgerListByExternalIDParamsEntryType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LedgerListByExternalIDParamsEntryType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LedgerListByExternalIDParamsEntryType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
