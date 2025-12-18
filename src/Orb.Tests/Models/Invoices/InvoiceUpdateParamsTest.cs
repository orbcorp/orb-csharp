using System;
using System.Text.Json;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceUpdateParamsDueDateTest : TestBase
{
    [Fact]
    public void DateValidationWorks()
    {
        InvoiceUpdateParamsDueDate value = new("2019-12-27");
        value.Validate();
    }

    [Fact]
    public void DateTimeValidationWorks()
    {
        InvoiceUpdateParamsDueDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        value.Validate();
    }

    [Fact]
    public void DateSerializationRoundtripWorks()
    {
        InvoiceUpdateParamsDueDate value = new("2019-12-27");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsDueDate>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        InvoiceUpdateParamsDueDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsDueDate>(element);

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceDateTest : TestBase
{
    [Fact]
    public void DateValidationWorks()
    {
        InvoiceDate value = new("2019-12-27");
        value.Validate();
    }

    [Fact]
    public void DateTimeValidationWorks()
    {
        InvoiceDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        value.Validate();
    }

    [Fact]
    public void DateSerializationRoundtripWorks()
    {
        InvoiceDate value = new("2019-12-27");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceDate>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        InvoiceDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceDate>(element);

        Assert.Equal(value, deserialized);
    }
}
