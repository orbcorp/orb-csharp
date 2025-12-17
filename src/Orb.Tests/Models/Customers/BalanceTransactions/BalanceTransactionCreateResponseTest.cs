using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using BalanceTransactions = Orb.Models.Customers.BalanceTransactions;

namespace Orb.Tests.Models.Customers.BalanceTransactions;

public class BalanceTransactionCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceTransactions::BalanceTransactionCreateResponse
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = BalanceTransactions::Action.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = BalanceTransactions::BalanceTransactionCreateResponseType.Increment,
        };

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, BalanceTransactions::Action> expectedAction =
            BalanceTransactions::Action.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, BalanceTransactions::BalanceTransactionCreateResponseType> expectedType =
            BalanceTransactions::BalanceTransactionCreateResponseType.Increment;

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
        var model = new BalanceTransactions::BalanceTransactionCreateResponse
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = BalanceTransactions::Action.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = BalanceTransactions::BalanceTransactionCreateResponseType.Increment,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<BalanceTransactions::BalanceTransactionCreateResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceTransactions::BalanceTransactionCreateResponse
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = BalanceTransactions::Action.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = BalanceTransactions::BalanceTransactionCreateResponseType.Increment,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<BalanceTransactions::BalanceTransactionCreateResponse>(
                element
            );
        Assert.NotNull(deserialized);

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, BalanceTransactions::Action> expectedAction =
            BalanceTransactions::Action.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, BalanceTransactions::BalanceTransactionCreateResponseType> expectedType =
            BalanceTransactions::BalanceTransactionCreateResponseType.Increment;

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
        var model = new BalanceTransactions::BalanceTransactionCreateResponse
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = BalanceTransactions::Action.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = BalanceTransactions::BalanceTransactionCreateResponseType.Increment,
        };

        model.Validate();
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(BalanceTransactions::Action.AppliedToInvoice)]
    [InlineData(BalanceTransactions::Action.ManualAdjustment)]
    [InlineData(BalanceTransactions::Action.ProratedRefund)]
    [InlineData(BalanceTransactions::Action.RevertProratedRefund)]
    [InlineData(BalanceTransactions::Action.ReturnFromVoiding)]
    [InlineData(BalanceTransactions::Action.CreditNoteApplied)]
    [InlineData(BalanceTransactions::Action.CreditNoteVoided)]
    [InlineData(BalanceTransactions::Action.OverpaymentRefund)]
    [InlineData(BalanceTransactions::Action.ExternalPayment)]
    [InlineData(BalanceTransactions::Action.SmallInvoiceCarryover)]
    public void Validation_Works(BalanceTransactions::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceTransactions::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceTransactions::Action>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BalanceTransactions::Action.AppliedToInvoice)]
    [InlineData(BalanceTransactions::Action.ManualAdjustment)]
    [InlineData(BalanceTransactions::Action.ProratedRefund)]
    [InlineData(BalanceTransactions::Action.RevertProratedRefund)]
    [InlineData(BalanceTransactions::Action.ReturnFromVoiding)]
    [InlineData(BalanceTransactions::Action.CreditNoteApplied)]
    [InlineData(BalanceTransactions::Action.CreditNoteVoided)]
    [InlineData(BalanceTransactions::Action.OverpaymentRefund)]
    [InlineData(BalanceTransactions::Action.ExternalPayment)]
    [InlineData(BalanceTransactions::Action.SmallInvoiceCarryover)]
    public void SerializationRoundtrip_Works(BalanceTransactions::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceTransactions::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BalanceTransactions::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceTransactions::Action>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BalanceTransactions::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BalanceTransactionCreateResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(BalanceTransactions::BalanceTransactionCreateResponseType.Increment)]
    [InlineData(BalanceTransactions::BalanceTransactionCreateResponseType.Decrement)]
    public void Validation_Works(BalanceTransactions::BalanceTransactionCreateResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceTransactions::BalanceTransactionCreateResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BalanceTransactions::BalanceTransactionCreateResponseType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BalanceTransactions::BalanceTransactionCreateResponseType.Increment)]
    [InlineData(BalanceTransactions::BalanceTransactionCreateResponseType.Decrement)]
    public void SerializationRoundtrip_Works(
        BalanceTransactions::BalanceTransactionCreateResponseType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceTransactions::BalanceTransactionCreateResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BalanceTransactions::BalanceTransactionCreateResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BalanceTransactions::BalanceTransactionCreateResponseType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BalanceTransactions::BalanceTransactionCreateResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
