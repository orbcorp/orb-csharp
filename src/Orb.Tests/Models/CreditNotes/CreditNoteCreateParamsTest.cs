using System;
using System.Text.Json;
using Orb.Models.CreditNotes;

namespace Orb.Tests.Models.CreditNotes;

public class LineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LineItem
        {
            Amount = "amount",
            InvoiceLineItemID = "4khy3nwzktxv7",
            EndDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            StartDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
        };

        string expectedAmount = "amount";
        string expectedInvoiceLineItemID = "4khy3nwzktxv7";

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedEndDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2023-09-22");

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedStartDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2023-09-22");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedInvoiceLineItemID, model.InvoiceLineItemID);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LineItem
        {
            Amount = "amount",
            InvoiceLineItemID = "4khy3nwzktxv7",
            EndDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            StartDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LineItem>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LineItem
        {
            Amount = "amount",
            InvoiceLineItemID = "4khy3nwzktxv7",
            EndDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            StartDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LineItem>(json);
        Assert.NotNull(deserialized);

        string expectedAmount = "amount";
        string expectedInvoiceLineItemID = "4khy3nwzktxv7";

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedEndDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2023-09-22");

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedStartDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2023-09-22");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedInvoiceLineItemID, deserialized.InvoiceLineItemID);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LineItem
        {
            Amount = "amount",
            InvoiceLineItemID = "4khy3nwzktxv7",
            EndDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            StartDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LineItem { Amount = "amount", InvoiceLineItemID = "4khy3nwzktxv7" };

        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LineItem { Amount = "amount", InvoiceLineItemID = "4khy3nwzktxv7" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LineItem
        {
            Amount = "amount",
            InvoiceLineItemID = "4khy3nwzktxv7",

            EndDate = null,
            StartDate = null,
        };

        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.StartDate);
        Assert.True(model.RawData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LineItem
        {
            Amount = "amount",
            InvoiceLineItemID = "4khy3nwzktxv7",

            EndDate = null,
            StartDate = null,
        };

        model.Validate();
    }
}
