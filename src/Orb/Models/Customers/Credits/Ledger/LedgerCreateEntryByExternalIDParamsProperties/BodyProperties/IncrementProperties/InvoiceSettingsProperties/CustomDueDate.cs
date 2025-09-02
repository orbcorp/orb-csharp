using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CustomDueDateVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties.CustomDueDateVariants;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties;

/// <summary>
/// An optional custom due date for the invoice. If not set, the due date will be
/// calculated based on the `net_terms` value.
/// </summary>
[JsonConverter(typeof(CustomDueDateConverter))]
public abstract record class CustomDueDate
{
    internal CustomDueDate() { }

    public static implicit operator CustomDueDate(DateOnly value) =>
        new CustomDueDateVariants::Date(value);

    public static implicit operator CustomDueDate(DateTime value) =>
        new CustomDueDateVariants::DateTime(value);

    public bool TryPickDate([NotNullWhen(true)] out DateOnly? value)
    {
        value = (this as CustomDueDateVariants::Date)?.Value;
        return value != null;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out DateTime? value)
    {
        value = (this as CustomDueDateVariants::DateTime)?.Value;
        return value != null;
    }

    public void Switch(
        Action<CustomDueDateVariants::Date> @date,
        Action<CustomDueDateVariants::DateTime> @dateTime
    )
    {
        switch (this)
        {
            case CustomDueDateVariants::Date inner:
                @date(inner);
                break;
            case CustomDueDateVariants::DateTime inner:
                @dateTime(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<CustomDueDateVariants::Date, T> @date,
        Func<CustomDueDateVariants::DateTime, T> @dateTime
    )
    {
        return this switch
        {
            CustomDueDateVariants::Date inner => @date(inner),
            CustomDueDateVariants::DateTime inner => @dateTime(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class CustomDueDateConverter : JsonConverter<CustomDueDate?>
{
    public override CustomDueDate? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new CustomDueDateVariants::Date(
                JsonSerializer.Deserialize<DateOnly>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new CustomDueDateVariants::DateTime(
                JsonSerializer.Deserialize<DateTime>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomDueDate? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value switch
        {
            null => null,
            CustomDueDateVariants::Date(var @date) => @date,
            CustomDueDateVariants::DateTime(var @dateTime) => @dateTime,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
