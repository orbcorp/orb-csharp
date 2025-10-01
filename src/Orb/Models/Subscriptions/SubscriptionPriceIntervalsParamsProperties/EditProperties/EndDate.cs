using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using EndDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties.EndDateVariants;
using Models = Orb.Models;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties;

/// <summary>
/// The updated end date of this price interval. If not specified, the end date will
/// not be updated.
/// </summary>
[JsonConverter(typeof(EndDateConverter))]
public abstract record class EndDate
{
    internal EndDate() { }

    public static implicit operator EndDate(DateTime value) => new EndDateVariants::DateTime(value);

    public static implicit operator EndDate(
        ApiEnum<string, Models::BillingCycleRelativeDate> value
    ) => new EndDateVariants::BillingCycleRelativeDate(value);

    public bool TryPickDateTime([NotNullWhen(true)] out DateTime? value)
    {
        value = (this as EndDateVariants::DateTime)?.Value;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, Models::BillingCycleRelativeDate>? value
    )
    {
        value = (this as EndDateVariants::BillingCycleRelativeDate)?.Value;
        return value != null;
    }

    public void Switch(
        Action<EndDateVariants::DateTime> @dateTime,
        Action<EndDateVariants::BillingCycleRelativeDate> billingCycleRelative
    )
    {
        switch (this)
        {
            case EndDateVariants::DateTime inner:
                @dateTime(inner);
                break;
            case EndDateVariants::BillingCycleRelativeDate inner:
                billingCycleRelative(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of EndDate");
        }
    }

    public T Match<T>(
        Func<EndDateVariants::DateTime, T> @dateTime,
        Func<EndDateVariants::BillingCycleRelativeDate, T> billingCycleRelative
    )
    {
        return this switch
        {
            EndDateVariants::DateTime inner => @dateTime(inner),
            EndDateVariants::BillingCycleRelativeDate inner => billingCycleRelative(inner),
            _ => throw new OrbInvalidDataException("Data did not match any variant of EndDate"),
        };
    }

    public abstract void Validate();
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
            return new EndDateVariants::BillingCycleRelativeDate(
                JsonSerializer.Deserialize<ApiEnum<string, Models::BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant EndDateVariants::BillingCycleRelativeDate",
                    e
                )
            );
        }

        try
        {
            return new EndDateVariants::DateTime(
                JsonSerializer.Deserialize<DateTime>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant EndDateVariants::DateTime",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, EndDate? value, JsonSerializerOptions options)
    {
        object? variant = value switch
        {
            null => null,
            EndDateVariants::DateTime(var @dateTime) => @dateTime,
            EndDateVariants::BillingCycleRelativeDate(var billingCycleRelative) =>
                billingCycleRelative,
            _ => throw new OrbInvalidDataException("Data did not match any variant of EndDate"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
