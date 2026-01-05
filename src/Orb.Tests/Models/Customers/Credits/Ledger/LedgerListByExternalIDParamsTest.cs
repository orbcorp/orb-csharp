using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class LedgerListByExternalIDParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LedgerListByExternalIDParams
        {
            ExternalCustomerID = "external_customer_id",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Cursor = "cursor",
            EntryStatus = LedgerListByExternalIDParamsEntryStatus.Committed,
            EntryType = LedgerListByExternalIDParamsEntryType.Increment,
            Limit = 1,
            MinimumAmount = "minimum_amount",
        };

        string expectedExternalCustomerID = "external_customer_id";
        DateTimeOffset expectedCreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedCursor = "cursor";
        ApiEnum<string, LedgerListByExternalIDParamsEntryStatus> expectedEntryStatus =
            LedgerListByExternalIDParamsEntryStatus.Committed;
        ApiEnum<string, LedgerListByExternalIDParamsEntryType> expectedEntryType =
            LedgerListByExternalIDParamsEntryType.Increment;
        long expectedLimit = 1;
        string expectedMinimumAmount = "minimum_amount";

        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
        Assert.Equal(expectedCreatedAtGt, parameters.CreatedAtGt);
        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLt, parameters.CreatedAtLt);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEntryStatus, parameters.EntryStatus);
        Assert.Equal(expectedEntryType, parameters.EntryType);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMinimumAmount, parameters.MinimumAmount);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LedgerListByExternalIDParams
        {
            ExternalCustomerID = "external_customer_id",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Cursor = "cursor",
            EntryStatus = LedgerListByExternalIDParamsEntryStatus.Committed,
            EntryType = LedgerListByExternalIDParamsEntryType.Increment,
            MinimumAmount = "minimum_amount",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LedgerListByExternalIDParams
        {
            ExternalCustomerID = "external_customer_id",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Cursor = "cursor",
            EntryStatus = LedgerListByExternalIDParamsEntryStatus.Committed,
            EntryType = LedgerListByExternalIDParamsEntryType.Increment,
            MinimumAmount = "minimum_amount",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LedgerListByExternalIDParams
        {
            ExternalCustomerID = "external_customer_id",
            Limit = 1,
        };

        Assert.Null(parameters.CreatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EntryStatus);
        Assert.False(parameters.RawQueryData.ContainsKey("entry_status"));
        Assert.Null(parameters.EntryType);
        Assert.False(parameters.RawQueryData.ContainsKey("entry_type"));
        Assert.Null(parameters.MinimumAmount);
        Assert.False(parameters.RawQueryData.ContainsKey("minimum_amount"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LedgerListByExternalIDParams
        {
            ExternalCustomerID = "external_customer_id",
            Limit = 1,

            CreatedAtGt = null,
            CreatedAtGte = null,
            CreatedAtLt = null,
            CreatedAtLte = null,
            Currency = null,
            Cursor = null,
            EntryStatus = null,
            EntryType = null,
            MinimumAmount = null,
        };

        Assert.Null(parameters.CreatedAtGt);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EntryStatus);
        Assert.True(parameters.RawQueryData.ContainsKey("entry_status"));
        Assert.Null(parameters.EntryType);
        Assert.True(parameters.RawQueryData.ContainsKey("entry_type"));
        Assert.Null(parameters.MinimumAmount);
        Assert.True(parameters.RawQueryData.ContainsKey("minimum_amount"));
    }

    [Fact]
    public void Url_Works()
    {
        LedgerListByExternalIDParams parameters = new()
        {
            ExternalCustomerID = "external_customer_id",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Cursor = "cursor",
            EntryStatus = LedgerListByExternalIDParamsEntryStatus.Committed,
            EntryType = LedgerListByExternalIDParamsEntryType.Increment,
            Limit = 1,
            MinimumAmount = "minimum_amount",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/customers/external_customer_id/external_customer_id/credits/ledger?created_at%5bgt%5d=2019-12-27T18%3a11%3a19.117Z&created_at%5bgte%5d=2019-12-27T18%3a11%3a19.117Z&created_at%5blt%5d=2019-12-27T18%3a11%3a19.117Z&created_at%5blte%5d=2019-12-27T18%3a11%3a19.117Z&currency=currency&cursor=cursor&entry_status=committed&entry_type=increment&limit=1&minimum_amount=minimum_amount"
            ),
            url
        );
    }
}

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
