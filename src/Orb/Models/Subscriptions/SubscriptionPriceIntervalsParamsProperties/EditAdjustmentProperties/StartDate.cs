using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditAdjustmentProperties;

/// <summary>
/// The updated start date of this adjustment interval. If not specified, the start
/// date will not be updated.
/// </summary>
[JsonConverter(typeof(StartDateConverter))]
public record class StartDate
{
    public object Value { get; private init; }

    public StartDate(DateTime value)
    {
        Value = value;
    }

    public StartDate(ApiEnum<string, BillingCycleRelativeDate> value)
    {
        Value = value;
    }

    StartDate(UnknownVariant value)
    {
        Value = value;
    }

    public static StartDate CreateUnknownVariant(JsonElement value)
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
                throw new OrbInvalidDataException("Data did not match any variant of StartDate");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of StartDate"),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of StartDate");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class StartDateConverter : JsonConverter<StartDate>
{
    public override StartDate? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new StartDate(
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
            return new StartDate(JsonSerializer.Deserialize<DateTime>(ref reader, options));
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
        StartDate value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
