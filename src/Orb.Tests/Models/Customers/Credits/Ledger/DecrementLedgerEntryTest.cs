using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class DecrementLedgerEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DecrementLedgerEntry
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
            EntryStatus = DecrementLedgerEntryEntryStatus.Committed,
            EntryType = DecrementLedgerEntryEntryType.Decrement,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,
            EventID = "event_id",
            InvoiceID = "invoice_id",
            PriceID = "price_id",
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
        ApiEnum<string, DecrementLedgerEntryEntryStatus> expectedEntryStatus =
            DecrementLedgerEntryEntryStatus.Committed;
        ApiEnum<string, DecrementLedgerEntryEntryType> expectedEntryType =
            DecrementLedgerEntryEntryType.Decrement;
        long expectedLedgerSequenceNumber = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        double expectedStartingBalance = 0;
        string expectedEventID = "event_id";
        string expectedInvoiceID = "invoice_id";
        string expectedPriceID = "price_id";

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
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.Equal(expectedPriceID, model.PriceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DecrementLedgerEntry
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
            EntryStatus = DecrementLedgerEntryEntryStatus.Committed,
            EntryType = DecrementLedgerEntryEntryType.Decrement,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,
            EventID = "event_id",
            InvoiceID = "invoice_id",
            PriceID = "price_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DecrementLedgerEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DecrementLedgerEntry
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
            EntryStatus = DecrementLedgerEntryEntryStatus.Committed,
            EntryType = DecrementLedgerEntryEntryType.Decrement,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,
            EventID = "event_id",
            InvoiceID = "invoice_id",
            PriceID = "price_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DecrementLedgerEntry>(
            element,
            ModelBase.SerializerOptions
        );
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
        ApiEnum<string, DecrementLedgerEntryEntryStatus> expectedEntryStatus =
            DecrementLedgerEntryEntryStatus.Committed;
        ApiEnum<string, DecrementLedgerEntryEntryType> expectedEntryType =
            DecrementLedgerEntryEntryType.Decrement;
        long expectedLedgerSequenceNumber = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        double expectedStartingBalance = 0;
        string expectedEventID = "event_id";
        string expectedInvoiceID = "invoice_id";
        string expectedPriceID = "price_id";

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
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.Equal(expectedPriceID, deserialized.PriceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DecrementLedgerEntry
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
            EntryStatus = DecrementLedgerEntryEntryStatus.Committed,
            EntryType = DecrementLedgerEntryEntryType.Decrement,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,
            EventID = "event_id",
            InvoiceID = "invoice_id",
            PriceID = "price_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DecrementLedgerEntry
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
            EntryStatus = DecrementLedgerEntryEntryStatus.Committed,
            EntryType = DecrementLedgerEntryEntryType.Decrement,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,
        };

        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
        Assert.Null(model.InvoiceID);
        Assert.False(model.RawData.ContainsKey("invoice_id"));
        Assert.Null(model.PriceID);
        Assert.False(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DecrementLedgerEntry
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
            EntryStatus = DecrementLedgerEntryEntryStatus.Committed,
            EntryType = DecrementLedgerEntryEntryType.Decrement,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DecrementLedgerEntry
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
            EntryStatus = DecrementLedgerEntryEntryStatus.Committed,
            EntryType = DecrementLedgerEntryEntryType.Decrement,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,

            EventID = null,
            InvoiceID = null,
            PriceID = null,
        };

        Assert.Null(model.EventID);
        Assert.True(model.RawData.ContainsKey("event_id"));
        Assert.Null(model.InvoiceID);
        Assert.True(model.RawData.ContainsKey("invoice_id"));
        Assert.Null(model.PriceID);
        Assert.True(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DecrementLedgerEntry
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
            EntryStatus = DecrementLedgerEntryEntryStatus.Committed,
            EntryType = DecrementLedgerEntryEntryType.Decrement,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartingBalance = 0,

            EventID = null,
            InvoiceID = null,
            PriceID = null,
        };

        model.Validate();
    }
}

public class DecrementLedgerEntryEntryStatusTest : TestBase
{
    [Theory]
    [InlineData(DecrementLedgerEntryEntryStatus.Committed)]
    [InlineData(DecrementLedgerEntryEntryStatus.Pending)]
    public void Validation_Works(DecrementLedgerEntryEntryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DecrementLedgerEntryEntryStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DecrementLedgerEntryEntryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DecrementLedgerEntryEntryStatus.Committed)]
    [InlineData(DecrementLedgerEntryEntryStatus.Pending)]
    public void SerializationRoundtrip_Works(DecrementLedgerEntryEntryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DecrementLedgerEntryEntryStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DecrementLedgerEntryEntryStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DecrementLedgerEntryEntryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DecrementLedgerEntryEntryStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DecrementLedgerEntryEntryTypeTest : TestBase
{
    [Theory]
    [InlineData(DecrementLedgerEntryEntryType.Decrement)]
    public void Validation_Works(DecrementLedgerEntryEntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DecrementLedgerEntryEntryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DecrementLedgerEntryEntryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DecrementLedgerEntryEntryType.Decrement)]
    public void SerializationRoundtrip_Works(DecrementLedgerEntryEntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DecrementLedgerEntryEntryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DecrementLedgerEntryEntryType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DecrementLedgerEntryEntryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DecrementLedgerEntryEntryType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
