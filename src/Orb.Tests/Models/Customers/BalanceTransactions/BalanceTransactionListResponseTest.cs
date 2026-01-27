using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Tests.Models.Customers.BalanceTransactions;

public class BalanceTransactionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceTransactionListResponse
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = BalanceTransactionListResponseAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = BalanceTransactionListResponseType.Increment,
        };

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, BalanceTransactionListResponseAction> expectedAction =
            BalanceTransactionListResponseAction.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, BalanceTransactionListResponseType> expectedType =
            BalanceTransactionListResponseType.Increment;

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
        var model = new BalanceTransactionListResponse
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = BalanceTransactionListResponseAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = BalanceTransactionListResponseType.Increment,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceTransactionListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceTransactionListResponse
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = BalanceTransactionListResponseAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = BalanceTransactionListResponseType.Increment,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceTransactionListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, BalanceTransactionListResponseAction> expectedAction =
            BalanceTransactionListResponseAction.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, BalanceTransactionListResponseType> expectedType =
            BalanceTransactionListResponseType.Increment;

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
        var model = new BalanceTransactionListResponse
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = BalanceTransactionListResponseAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = BalanceTransactionListResponseType.Increment,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceTransactionListResponse
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = BalanceTransactionListResponseAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = BalanceTransactionListResponseType.Increment,
        };

        BalanceTransactionListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BalanceTransactionListResponseActionTest : TestBase
{
    [Theory]
    [InlineData(BalanceTransactionListResponseAction.AppliedToInvoice)]
    [InlineData(BalanceTransactionListResponseAction.ManualAdjustment)]
    [InlineData(BalanceTransactionListResponseAction.ProratedRefund)]
    [InlineData(BalanceTransactionListResponseAction.RevertProratedRefund)]
    [InlineData(BalanceTransactionListResponseAction.ReturnFromVoiding)]
    [InlineData(BalanceTransactionListResponseAction.CreditNoteApplied)]
    [InlineData(BalanceTransactionListResponseAction.CreditNoteVoided)]
    [InlineData(BalanceTransactionListResponseAction.OverpaymentRefund)]
    [InlineData(BalanceTransactionListResponseAction.ExternalPayment)]
    [InlineData(BalanceTransactionListResponseAction.SmallInvoiceCarryover)]
    public void Validation_Works(BalanceTransactionListResponseAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceTransactionListResponseAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BalanceTransactionListResponseAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BalanceTransactionListResponseAction.AppliedToInvoice)]
    [InlineData(BalanceTransactionListResponseAction.ManualAdjustment)]
    [InlineData(BalanceTransactionListResponseAction.ProratedRefund)]
    [InlineData(BalanceTransactionListResponseAction.RevertProratedRefund)]
    [InlineData(BalanceTransactionListResponseAction.ReturnFromVoiding)]
    [InlineData(BalanceTransactionListResponseAction.CreditNoteApplied)]
    [InlineData(BalanceTransactionListResponseAction.CreditNoteVoided)]
    [InlineData(BalanceTransactionListResponseAction.OverpaymentRefund)]
    [InlineData(BalanceTransactionListResponseAction.ExternalPayment)]
    [InlineData(BalanceTransactionListResponseAction.SmallInvoiceCarryover)]
    public void SerializationRoundtrip_Works(BalanceTransactionListResponseAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceTransactionListResponseAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BalanceTransactionListResponseAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BalanceTransactionListResponseAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BalanceTransactionListResponseAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BalanceTransactionListResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(BalanceTransactionListResponseType.Increment)]
    [InlineData(BalanceTransactionListResponseType.Decrement)]
    public void Validation_Works(BalanceTransactionListResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceTransactionListResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceTransactionListResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BalanceTransactionListResponseType.Increment)]
    [InlineData(BalanceTransactionListResponseType.Decrement)]
    public void SerializationRoundtrip_Works(BalanceTransactionListResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceTransactionListResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BalanceTransactionListResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceTransactionListResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BalanceTransactionListResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
