using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties;

/// <summary>
/// The updated end date of this price interval. If not specified, the end date will
/// not be updated.
/// </summary>
[JsonConverter(typeof(EndDateConverter))]
public record class EndDate
{
    public object Value { get; private init; }

    public EndDate(DateTime value)
    {
        Value = value;
    }

    public EndDate(ApiEnum<string, BillingCycleRelativeDate> value)
    {
        Value = value;
    }

    EndDate(UnknownVariant value)
    {
        Value = value;
    }

    public static EndDate CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickDateTime([NotNullWhen(true)] out DateTime? value)
    {
        value = this.Value as DateTime?;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>?;
        return value != null;
    }

    public void Switch(
        Action<DateTime> @dateTime,
        Action<ApiEnum<string, BillingCycleRelativeDate>> billingCycleRelative
    )
    {
        switch (this.Value)
        {
            case DateTime value:
                @dateTime(value);
                break;
            case ApiEnum<string, BillingCycleRelativeDate> value:
                billingCycleRelative(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of EndDate");
        }
    }

    public T Match<T>(
        Func<DateTime, T> @dateTime,
        Func<ApiEnum<string, BillingCycleRelativeDate>, T> billingCycleRelative
    )
    {
        return this.Value switch
        {
            DateTime value => @dateTime(value),
            ApiEnum<string, BillingCycleRelativeDate> value => billingCycleRelative(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of EndDate"),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EndDate");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class EndDateConverter : JsonConverter<EndDate?>
{
    public override EndDate? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new EndDate(
                JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'ApiEnum<string, BillingCycleRelativeDate>'",
                    e
                )
            );
        }

        try
        {
            return new EndDate(JsonSerializer.Deserialize<DateTime>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException("Data does not match union variant 'DateTime'", e)
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, EndDate? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
