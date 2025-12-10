using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class ExpirationChangeLedgerEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExpirationChangeLedgerEntry
        {
            ID = "id",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditBlock = new()
            {
                ID = "id",
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = AffectedBlockFilterField.PriceID,
                        Operator = AffectedBlockFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Currency = "currency",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            Description = "description",
            EndingBalance = 0,
            EntryStatus = ExpirationChangeLedgerEntryEntryStatus.Committed,
            EntryType = ExpirationChangeLedgerEntryEntryType.ExpirationChange,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            NewBlockExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartingBalance = 0,
        };

        string expectedID = "id";
        double expectedAmount = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        AffectedBlock expectedCreditBlock = new()
        {
            ID = "id",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = AffectedBlockFilterField.PriceID,
                    Operator = AffectedBlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        string expectedCurrency = "currency";
        CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        string expectedDescription = "description";
        double expectedEndingBalance = 0;
        ApiEnum<string, ExpirationChangeLedgerEntryEntryStatus> expectedEntryStatus =
            ExpirationChangeLedgerEntryEntryStatus.Committed;
        ApiEnum<string, ExpirationChangeLedgerEntryEntryType> expectedEntryType =
            ExpirationChangeLedgerEntryEntryType.ExpirationChange;
        long expectedLedgerSequenceNumber = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedNewBlockExpiryDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        double expectedStartingBalance = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditBlock, model.CreditBlock);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEndingBalance, model.EndingBalance);
        Assert.Equal(expectedEntryStatus, model.EntryStatus);
        Assert.Equal(expectedEntryType, model.EntryType);
        Assert.Equal(expectedLedgerSequenceNumber, model.LedgerSequenceNumber);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedNewBlockExpiryDate, model.NewBlockExpiryDate);
        Assert.Equal(expectedStartingBalance, model.StartingBalance);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExpirationChangeLedgerEntry
        {
            ID = "id",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditBlock = new()
            {
                ID = "id",
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = AffectedBlockFilterField.PriceID,
                        Operator = AffectedBlockFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Currency = "currency",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            Description = "description",
            EndingBalance = 0,
            EntryStatus = ExpirationChangeLedgerEntryEntryStatus.Committed,
            EntryType = ExpirationChangeLedgerEntryEntryType.ExpirationChange,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            NewBlockExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartingBalance = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExpirationChangeLedgerEntry>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExpirationChangeLedgerEntry
        {
            ID = "id",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditBlock = new()
            {
                ID = "id",
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = AffectedBlockFilterField.PriceID,
                        Operator = AffectedBlockFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Currency = "currency",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            Description = "description",
            EndingBalance = 0,
            EntryStatus = ExpirationChangeLedgerEntryEntryStatus.Committed,
            EntryType = ExpirationChangeLedgerEntryEntryType.ExpirationChange,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            NewBlockExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartingBalance = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExpirationChangeLedgerEntry>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        AffectedBlock expectedCreditBlock = new()
        {
            ID = "id",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = AffectedBlockFilterField.PriceID,
                    Operator = AffectedBlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        string expectedCurrency = "currency";
        CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        string expectedDescription = "description";
        double expectedEndingBalance = 0;
        ApiEnum<string, ExpirationChangeLedgerEntryEntryStatus> expectedEntryStatus =
            ExpirationChangeLedgerEntryEntryStatus.Committed;
        ApiEnum<string, ExpirationChangeLedgerEntryEntryType> expectedEntryType =
            ExpirationChangeLedgerEntryEntryType.ExpirationChange;
        long expectedLedgerSequenceNumber = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedNewBlockExpiryDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        double expectedStartingBalance = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditBlock, deserialized.CreditBlock);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEndingBalance, deserialized.EndingBalance);
        Assert.Equal(expectedEntryStatus, deserialized.EntryStatus);
        Assert.Equal(expectedEntryType, deserialized.EntryType);
        Assert.Equal(expectedLedgerSequenceNumber, deserialized.LedgerSequenceNumber);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedNewBlockExpiryDate, deserialized.NewBlockExpiryDate);
        Assert.Equal(expectedStartingBalance, deserialized.StartingBalance);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExpirationChangeLedgerEntry
        {
            ID = "id",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditBlock = new()
            {
                ID = "id",
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = AffectedBlockFilterField.PriceID,
                        Operator = AffectedBlockFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Currency = "currency",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            Description = "description",
            EndingBalance = 0,
            EntryStatus = ExpirationChangeLedgerEntryEntryStatus.Committed,
            EntryType = ExpirationChangeLedgerEntryEntryType.ExpirationChange,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            NewBlockExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartingBalance = 0,
        };

        model.Validate();
    }
}

public class ExpirationChangeLedgerEntryEntryStatusTest : TestBase
{
    [Theory]
    [InlineData(ExpirationChangeLedgerEntryEntryStatus.Committed)]
    [InlineData(ExpirationChangeLedgerEntryEntryStatus.Pending)]
    public void Validation_Works(ExpirationChangeLedgerEntryEntryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExpirationChangeLedgerEntryEntryStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExpirationChangeLedgerEntryEntryStatus>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExpirationChangeLedgerEntryEntryStatus.Committed)]
    [InlineData(ExpirationChangeLedgerEntryEntryStatus.Pending)]
    public void SerializationRoundtrip_Works(ExpirationChangeLedgerEntryEntryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExpirationChangeLedgerEntryEntryStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExpirationChangeLedgerEntryEntryStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExpirationChangeLedgerEntryEntryStatus>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExpirationChangeLedgerEntryEntryStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ExpirationChangeLedgerEntryEntryTypeTest : TestBase
{
    [Theory]
    [InlineData(ExpirationChangeLedgerEntryEntryType.ExpirationChange)]
    public void Validation_Works(ExpirationChangeLedgerEntryEntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExpirationChangeLedgerEntryEntryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExpirationChangeLedgerEntryEntryType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExpirationChangeLedgerEntryEntryType.ExpirationChange)]
    public void SerializationRoundtrip_Works(ExpirationChangeLedgerEntryEntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExpirationChangeLedgerEntryEntryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExpirationChangeLedgerEntryEntryType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExpirationChangeLedgerEntryEntryType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExpirationChangeLedgerEntryEntryType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
