using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using StartDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditAdjustmentProperties.StartDateVariants;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditAdjustmentProperties;

/// <summary>
/// The updated start date of this adjustment interval. If not specified, the start
/// date will not be updated.
/// </summary>
[JsonConverter(typeof(StartDateConverter))]
public abstract record class StartDate
{
    internal StartDate() { }

    public static implicit operator StartDate(DateTime value) =>
        new StartDateVariants::DateTime(value);

    public static implicit operator StartDate(ApiEnum<string, BillingCycleRelativeDate> value) =>
        new StartDateVariants::BillingCycleRelativeDate(value);

    public bool TryPickDateTime([NotNullWhen(true)] out DateTime? value)
    {
        value = (this as StartDateVariants::DateTime)?.Value;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = (this as StartDateVariants::BillingCycleRelativeDate)?.Value;
        return value != null;
    }

    public void Switch(
        Action<StartDateVariants::DateTime> @dateTime,
        Action<StartDateVariants::BillingCycleRelativeDate> billingCycleRelative
    )
    {
        switch (this)
        {
            case StartDateVariants::DateTime inner:
                @dateTime(inner);
                break;
            case StartDateVariants::BillingCycleRelativeDate inner:
                billingCycleRelative(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<StartDateVariants::DateTime, T> @dateTime,
        Func<StartDateVariants::BillingCycleRelativeDate, T> billingCycleRelative
    )
    {
        return this switch
        {
            StartDateVariants::DateTime inner => @dateTime(inner),
            StartDateVariants::BillingCycleRelativeDate inner => billingCycleRelative(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class StartDateConverter : JsonConverter<StartDate>
{
    public override StartDate? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new StartDateVariants::BillingCycleRelativeDate(
                JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new StartDateVariants::DateTime(
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
        StartDate value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            StartDateVariants::DateTime(var @dateTime) => @dateTime,
            StartDateVariants::BillingCycleRelativeDate(var billingCycleRelative) =>
                billingCycleRelative,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
