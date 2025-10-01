using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using InvoiceDateVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties.InvoiceDateVariants;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties;

/// <summary>
/// An ISO 8601 format date that denotes when this invoice should be dated in the
/// customer's timezone. If not provided, the invoice date will default to the credit
/// block's effective date.
/// </summary>
[JsonConverter(typeof(InvoiceDateConverter))]
public abstract record class InvoiceDate
{
    internal InvoiceDate() { }

    public static implicit operator InvoiceDate(DateOnly value) =>
        new InvoiceDateVariants::Date(value);

    public static implicit operator InvoiceDate(DateTime value) =>
        new InvoiceDateVariants::DateTime(value);

    public bool TryPickDate([NotNullWhen(true)] out DateOnly? value)
    {
        value = (this as InvoiceDateVariants::Date)?.Value;
        return value != null;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out DateTime? value)
    {
        value = (this as InvoiceDateVariants::DateTime)?.Value;
        return value != null;
    }

    public void Switch(
        Action<InvoiceDateVariants::Date> @date,
        Action<InvoiceDateVariants::DateTime> @dateTime
    )
    {
        switch (this)
        {
            case InvoiceDateVariants::Date inner:
                @date(inner);
                break;
            case InvoiceDateVariants::DateTime inner:
                @dateTime(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate");
        }
    }

    public T Match<T>(
        Func<InvoiceDateVariants::Date, T> @date,
        Func<InvoiceDateVariants::DateTime, T> @dateTime
    )
    {
        return this switch
        {
            InvoiceDateVariants::Date inner => @date(inner),
            InvoiceDateVariants::DateTime inner => @dateTime(inner),
            _ => throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate"),
        };
    }

    public abstract void Validate();
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
            return new InvoiceDateVariants::Date(
                JsonSerializer.Deserialize<DateOnly>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant InvoiceDateVariants::Date",
                    e
                )
            );
        }

        try
        {
            return new InvoiceDateVariants::DateTime(
                JsonSerializer.Deserialize<DateTime>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant InvoiceDateVariants::DateTime",
                    e
                )
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
        object? variant = value switch
        {
            null => null,
            InvoiceDateVariants::Date(var @date) => @date,
            InvoiceDateVariants::DateTime(var @dateTime) => @dateTime,
            _ => throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
