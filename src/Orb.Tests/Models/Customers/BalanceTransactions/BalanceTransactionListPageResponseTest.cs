using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Tests.Models.Customers.BalanceTransactions;

public class BalanceTransactionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "cgZa3SXcsPTVyC4Y",
                    Action = DataAction.AppliedToInvoice,
                    Amount = "11.00",
                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                    CreditNote = new("id"),
                    Description = "An optional description",
                    EndingBalance = "22.00",
                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                    StartingBalance = "33.00",
                    Type = DataType.Increment,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Data> expectedData =
        [
            new()
            {
                ID = "cgZa3SXcsPTVyC4Y",
                Action = DataAction.AppliedToInvoice,
                Amount = "11.00",
                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                CreditNote = new("id"),
                Description = "An optional description",
                EndingBalance = "22.00",
                Invoice = new("gXcsPTVyC4YZa3Sc"),
                StartingBalance = "33.00",
                Type = DataType.Increment,
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, model.PaginationMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "cgZa3SXcsPTVyC4Y",
                    Action = DataAction.AppliedToInvoice,
                    Amount = "11.00",
                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                    CreditNote = new("id"),
                    Description = "An optional description",
                    EndingBalance = "22.00",
                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                    StartingBalance = "33.00",
                    Type = DataType.Increment,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BalanceTransactionListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "cgZa3SXcsPTVyC4Y",
                    Action = DataAction.AppliedToInvoice,
                    Amount = "11.00",
                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                    CreditNote = new("id"),
                    Description = "An optional description",
                    EndingBalance = "22.00",
                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                    StartingBalance = "33.00",
                    Type = DataType.Increment,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BalanceTransactionListPageResponse>(json);
        Assert.NotNull(deserialized);

        List<Data> expectedData =
        [
            new()
            {
                ID = "cgZa3SXcsPTVyC4Y",
                Action = DataAction.AppliedToInvoice,
                Amount = "11.00",
                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                CreditNote = new("id"),
                Description = "An optional description",
                EndingBalance = "22.00",
                Invoice = new("gXcsPTVyC4YZa3Sc"),
                StartingBalance = "33.00",
                Type = DataType.Increment,
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, deserialized.PaginationMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BalanceTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "cgZa3SXcsPTVyC4Y",
                    Action = DataAction.AppliedToInvoice,
                    Amount = "11.00",
                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                    CreditNote = new("id"),
                    Description = "An optional description",
                    EndingBalance = "22.00",
                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                    StartingBalance = "33.00",
                    Type = DataType.Increment,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = DataAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = DataType.Increment,
        };

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, DataAction> expectedAction = DataAction.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, DataType> expectedType = DataType.Increment;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditNote, model.CreditNote);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEndingBalance, model.EndingBalance);
        Assert.Equal(expectedInvoice, model.Invoice);
        Assert.Equal(expectedStartingBalance, model.StartingBalance);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = DataAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = DataType.Increment,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = DataAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = DataType.Increment,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);
        Assert.NotNull(deserialized);

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, DataAction> expectedAction = DataAction.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, DataType> expectedType = DataType.Increment;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditNote, deserialized.CreditNote);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEndingBalance, deserialized.EndingBalance);
        Assert.Equal(expectedInvoice, deserialized.Invoice);
        Assert.Equal(expectedStartingBalance, deserialized.StartingBalance);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = DataAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = DataType.Increment,
        };

        model.Validate();
    }
}

public class DataActionTest : TestBase
{
    [Theory]
    [InlineData(DataAction.AppliedToInvoice)]
    [InlineData(DataAction.ManualAdjustment)]
    [InlineData(DataAction.ProratedRefund)]
    [InlineData(DataAction.RevertProratedRefund)]
    [InlineData(DataAction.ReturnFromVoiding)]
    [InlineData(DataAction.CreditNoteApplied)]
    [InlineData(DataAction.CreditNoteVoided)]
    [InlineData(DataAction.OverpaymentRefund)]
    [InlineData(DataAction.ExternalPayment)]
    [InlineData(DataAction.SmallInvoiceCarryover)]
    public void Validation_Works(DataAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataAction.AppliedToInvoice)]
    [InlineData(DataAction.ManualAdjustment)]
    [InlineData(DataAction.ProratedRefund)]
    [InlineData(DataAction.RevertProratedRefund)]
    [InlineData(DataAction.ReturnFromVoiding)]
    [InlineData(DataAction.CreditNoteApplied)]
    [InlineData(DataAction.CreditNoteVoided)]
    [InlineData(DataAction.OverpaymentRefund)]
    [InlineData(DataAction.ExternalPayment)]
    [InlineData(DataAction.SmallInvoiceCarryover)]
    public void SerializationRoundtrip_Works(DataAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataTypeTest : TestBase
{
    [Theory]
    [InlineData(DataType.Increment)]
    [InlineData(DataType.Decrement)]
    public void Validation_Works(DataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataType.Increment)]
    [InlineData(DataType.Decrement)]
    public void SerializationRoundtrip_Works(DataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
