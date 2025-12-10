using System;
using System.Text.Json;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceUpdateParamsDueDateTest : TestBase
{
    [Fact]
    public void dateValidation_Works()
    {
        InvoiceUpdateParamsDueDate value = new(
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"));
        value.Validate();
    }

    [Fact]
    public void date_timeValidation_Works()
    {
        InvoiceUpdateParamsDueDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        value.Validate();
    }

    [Fact]
    public void dateSerializationRoundtrip_Works()
    {
        InvoiceUpdateParamsDueDate value = new(
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsDueDate>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void date_timeSerializationRoundtrip_Works()
    {
        InvoiceUpdateParamsDueDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsDueDate>(json);

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceDateTest : TestBase
{
    [Fact]
    public void dateValidation_Works()
    {
        InvoiceDate value = new(
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"));
        value.Validate();
    }

    [Fact]
    public void date_timeValidation_Works()
    {
        InvoiceDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        value.Validate();
    }

    [Fact]
    public void dateSerializationRoundtrip_Works()
    {
        InvoiceDate value = new(
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceDate>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void date_timeSerializationRoundtrip_Works()
    {
        InvoiceDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceDate>(json);

        Assert.Equal(value, deserialized);
    }
}
