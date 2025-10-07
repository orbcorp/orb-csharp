using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties;

/// <summary>
/// An optional custom due date for the invoice. If not set, the due date will be
/// calculated based on the `net_terms` value.
/// </summary>
[JsonConverter(typeof(CustomDueDateConverter))]
public record class CustomDueDate
{
    public object Value { get; private init; }

    public CustomDueDate(DateOnly value)
    {
        Value = value;
    }

    public CustomDueDate(DateTime value)
    {
        Value = value;
    }

    CustomDueDate(UnknownVariant value)
    {
        Value = value;
    }

    public static CustomDueDate CreateUnknownVariant(JsonElement value)
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
                throw new OrbInvalidDataException(
                    "Data did not match any variant of CustomDueDate"
                );
        }
    }

    public T Match<T>(Func<DateOnly, T> @date, Func<DateTime, T> @dateTime)
    {
        return this.Value switch
        {
            DateOnly value => @date(value),
            DateTime value => @dateTime(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of CustomDueDate"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of CustomDueDate");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class CustomDueDateConverter : JsonConverter<CustomDueDate?>
{
    public override CustomDueDate? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new CustomDueDate(JsonSerializer.Deserialize<DateOnly>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException("Data does not match union variant 'DateOnly'", e)
            );
        }

        try
        {
            return new CustomDueDate(JsonSerializer.Deserialize<DateTime>(ref reader, options));
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
        CustomDueDate? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
