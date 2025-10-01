using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using DueDateVariants = Orb.Models.Invoices.InvoiceUpdateParamsProperties.DueDateVariants;

namespace Orb.Models.Invoices.InvoiceUpdateParamsProperties;

/// <summary>
/// An optional custom due date for the invoice. If not set, the due date will be
/// calculated based on the `net_terms` value.
/// </summary>
[JsonConverter(typeof(DueDateConverter))]
public abstract record class DueDate
{
    internal DueDate() { }

    public static implicit operator DueDate(DateOnly value) => new DueDateVariants::Date(value);

    public static implicit operator DueDate(DateTime value) => new DueDateVariants::DateTime(value);

    public bool TryPickDate([NotNullWhen(true)] out DateOnly? value)
    {
        value = (this as DueDateVariants::Date)?.Value;
        return value != null;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out DateTime? value)
    {
        value = (this as DueDateVariants::DateTime)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DueDateVariants::Date> @date,
        Action<DueDateVariants::DateTime> @dateTime
    )
    {
        switch (this)
        {
            case DueDateVariants::Date inner:
                @date(inner);
                break;
            case DueDateVariants::DateTime inner:
                @dateTime(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of DueDate");
        }
    }

    public T Match<T>(
        Func<DueDateVariants::Date, T> @date,
        Func<DueDateVariants::DateTime, T> @dateTime
    )
    {
        return this switch
        {
            DueDateVariants::Date inner => @date(inner),
            DueDateVariants::DateTime inner => @dateTime(inner),
            _ => throw new OrbInvalidDataException("Data did not match any variant of DueDate"),
        };
    }

    public abstract void Validate();
}

sealed class DueDateConverter : JsonConverter<DueDate?>
{
    public override DueDate? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new DueDateVariants::Date(
                JsonSerializer.Deserialize<DateOnly>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant DueDateVariants::Date",
                    e
                )
            );
        }

        try
        {
            return new DueDateVariants::DateTime(
                JsonSerializer.Deserialize<DateTime>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant DueDateVariants::DateTime",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, DueDate? value, JsonSerializerOptions options)
    {
        object? variant = value switch
        {
            null => null,
            DueDateVariants::Date(var @date) => @date,
            DueDateVariants::DateTime(var @dateTime) => @dateTime,
            _ => throw new OrbInvalidDataException("Data did not match any variant of DueDate"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
