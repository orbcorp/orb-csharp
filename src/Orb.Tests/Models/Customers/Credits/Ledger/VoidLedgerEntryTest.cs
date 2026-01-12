using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class VoidLedgerEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoidLedgerEntry
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
            EntryStatus = VoidLedgerEntryEntryStatus.Committed,
            EntryType = VoidLedgerEntryEntryType.Void,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,
            VoidAmount = 0,
            VoidReason = "void_reason",
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
        ApiEnum<string, VoidLedgerEntryEntryStatus> expectedEntryStatus =
            VoidLedgerEntryEntryStatus.Committed;
        ApiEnum<string, VoidLedgerEntryEntryType> expectedEntryType = VoidLedgerEntryEntryType.Void;
        long expectedLedgerSequenceNumber = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        double expectedStartingBalance = 0;
        double expectedVoidAmount = 0;
        string expectedVoidReason = "void_reason";

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
        Assert.Equal(expectedStartingBalance, model.StartingBalance);
        Assert.Equal(expectedVoidAmount, model.VoidAmount);
        Assert.Equal(expectedVoidReason, model.VoidReason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoidLedgerEntry
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
            EntryStatus = VoidLedgerEntryEntryStatus.Committed,
            EntryType = VoidLedgerEntryEntryType.Void,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,
            VoidAmount = 0,
            VoidReason = "void_reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VoidLedgerEntry>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoidLedgerEntry
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
            EntryStatus = VoidLedgerEntryEntryStatus.Committed,
            EntryType = VoidLedgerEntryEntryType.Void,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,
            VoidAmount = 0,
            VoidReason = "void_reason",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VoidLedgerEntry>(element);
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
        ApiEnum<string, VoidLedgerEntryEntryStatus> expectedEntryStatus =
            VoidLedgerEntryEntryStatus.Committed;
        ApiEnum<string, VoidLedgerEntryEntryType> expectedEntryType = VoidLedgerEntryEntryType.Void;
        long expectedLedgerSequenceNumber = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        double expectedStartingBalance = 0;
        double expectedVoidAmount = 0;
        string expectedVoidReason = "void_reason";

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
        Assert.Equal(expectedStartingBalance, deserialized.StartingBalance);
        Assert.Equal(expectedVoidAmount, deserialized.VoidAmount);
        Assert.Equal(expectedVoidReason, deserialized.VoidReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoidLedgerEntry
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
            EntryStatus = VoidLedgerEntryEntryStatus.Committed,
            EntryType = VoidLedgerEntryEntryType.Void,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,
            VoidAmount = 0,
            VoidReason = "void_reason",
        };

        model.Validate();
    }
}

public class VoidLedgerEntryEntryStatusTest : TestBase
{
    [Theory]
    [InlineData(VoidLedgerEntryEntryStatus.Committed)]
    [InlineData(VoidLedgerEntryEntryStatus.Pending)]
    public void Validation_Works(VoidLedgerEntryEntryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VoidLedgerEntryEntryStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VoidLedgerEntryEntryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VoidLedgerEntryEntryStatus.Committed)]
    [InlineData(VoidLedgerEntryEntryStatus.Pending)]
    public void SerializationRoundtrip_Works(VoidLedgerEntryEntryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VoidLedgerEntryEntryStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VoidLedgerEntryEntryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VoidLedgerEntryEntryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VoidLedgerEntryEntryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VoidLedgerEntryEntryTypeTest : TestBase
{
    [Theory]
    [InlineData(VoidLedgerEntryEntryType.Void)]
    public void Validation_Works(VoidLedgerEntryEntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VoidLedgerEntryEntryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VoidLedgerEntryEntryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VoidLedgerEntryEntryType.Void)]
    public void SerializationRoundtrip_Works(VoidLedgerEntryEntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VoidLedgerEntryEntryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VoidLedgerEntryEntryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VoidLedgerEntryEntryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VoidLedgerEntryEntryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
