using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Invoices.InvoiceUpdateParamsProperties;

/// <summary>
/// The date of the invoice. Can only be modified for one-off draft invoices.
/// </summary>
[JsonConverter(typeof(InvoiceDateConverter))]
public record class InvoiceDate
{
    public object Value { get; private init; }

    public InvoiceDate(DateOnly value)
    {
        Value = value;
    }

    public InvoiceDate(DateTime value)
    {
        Value = value;
    }

    InvoiceDate(UnknownVariant value)
    {
        Value = value;
    }

    public static InvoiceDate CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickDate([NotNullWhen(true)] out DateOnly? value)
    {
        value = this.Value as DateOnly?;
        return value != null;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out DateTime? value)
    {
        value = this.Value as DateTime?;
        return value != null;
    }

    public void Switch(Action<DateOnly> @date, Action<DateTime> @dateTime)
    {
        switch (this.Value)
        {
            case DateOnly value:
                @date(value);
                break;
            case DateTime value:
                @dateTime(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate");
        }
    }

    public T Match<T>(Func<DateOnly, T> @date, Func<DateTime, T> @dateTime)
    {
        return this.Value switch
        {
            DateOnly value => @date(value),
            DateTime value => @dateTime(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class InvoiceDateConverter : JsonConverter<InvoiceDate?>
{
    public override InvoiceDate? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new InvoiceDate(JsonSerializer.Deserialize<DateOnly>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException("Data does not match union variant 'DateOnly'", e)
            );
        }

        try
        {
            return new InvoiceDate(JsonSerializer.Deserialize<DateTime>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException("Data does not match union variant 'DateTime'", e)
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceDate? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
