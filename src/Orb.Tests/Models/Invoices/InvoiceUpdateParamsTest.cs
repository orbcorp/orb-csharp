using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceUpdateParams
        {
            InvoiceID = "invoice_id",
            DueDate = "2023-09-22",
            InvoiceDate = "2023-09-22",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            NetTerms = 0,
        };

        string expectedInvoiceID = "invoice_id";
        InvoiceUpdateParamsDueDate expectedDueDate = "2023-09-22";
        InvoiceDate expectedInvoiceDate = "2023-09-22";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        long expectedNetTerms = 0;

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedDueDate, parameters.DueDate);
        Assert.Equal(expectedInvoiceDate, parameters.InvoiceDate);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedNetTerms, parameters.NetTerms);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceUpdateParams { InvoiceID = "invoice_id" };

        Assert.Null(parameters.DueDate);
        Assert.False(parameters.RawBodyData.ContainsKey("due_date"));
        Assert.Null(parameters.InvoiceDate);
        Assert.False(parameters.RawBodyData.ContainsKey("invoice_date"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.NetTerms);
        Assert.False(parameters.RawBodyData.ContainsKey("net_terms"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InvoiceUpdateParams
        {
            InvoiceID = "invoice_id",

            DueDate = null,
            InvoiceDate = null,
            Metadata = null,
            NetTerms = null,
        };

        Assert.Null(parameters.DueDate);
        Assert.True(parameters.RawBodyData.ContainsKey("due_date"));
        Assert.Null(parameters.InvoiceDate);
        Assert.True(parameters.RawBodyData.ContainsKey("invoice_date"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.NetTerms);
        Assert.True(parameters.RawBodyData.ContainsKey("net_terms"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceUpdateParams parameters = new() { InvoiceID = "invoice_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/invoices/invoice_id"), url);
    }
}

public class InvoiceUpdateParamsDueDateTest : TestBase
{
    [Fact]
    public void DateValidationWorks()
    {
        InvoiceUpdateParamsDueDate value = "2019-12-27";
        value.Validate();
    }

    [Fact]
    public void DateTimeValidationWorks()
    {
        InvoiceUpdateParamsDueDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DateSerializationRoundtripWorks()
    {
        InvoiceUpdateParamsDueDate value = "2019-12-27";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsDueDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        InvoiceUpdateParamsDueDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsDueDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceDateTest : TestBase
{
    [Fact]
    public void DateValidationWorks()
    {
        InvoiceDate value = "2019-12-27";
        value.Validate();
    }

    [Fact]
    public void DateTimeValidationWorks()
    {
        InvoiceDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DateSerializationRoundtripWorks()
    {
        InvoiceDate value = "2019-12-27";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        InvoiceDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
