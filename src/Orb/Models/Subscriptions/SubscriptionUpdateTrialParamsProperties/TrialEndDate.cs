using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateProperties;
using TrialEndDateVariants = Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateVariants;

namespace Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties;

/// <summary>
/// The new date that the trial should end, or the literal string `immediate` to end
/// the trial immediately.
/// </summary>
[JsonConverter(typeof(TrialEndDateConverter))]
public abstract record class TrialEndDate
{
    internal TrialEndDate() { }

    public static implicit operator TrialEndDate(DateTime value) =>
        new TrialEndDateVariants::DateTime(value);

    public static implicit operator TrialEndDate(ApiEnum<string, UnionMember1> value) =>
        new TrialEndDateVariants::UnionMember1(value);

    public bool TryPickDateTime([NotNullWhen(true)] out DateTime? value)
    {
        value = (this as TrialEndDateVariants::DateTime)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember1([NotNullWhen(true)] out ApiEnum<string, UnionMember1>? value)
    {
        value = (this as TrialEndDateVariants::UnionMember1)?.Value;
        return value != null;
    }

    public void Switch(
        Action<TrialEndDateVariants::DateTime> @dateTime,
        Action<TrialEndDateVariants::UnionMember1> unionMember1
    )
    {
        switch (this)
        {
            case TrialEndDateVariants::DateTime inner:
                @dateTime(inner);
                break;
            case TrialEndDateVariants::UnionMember1 inner:
                unionMember1(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of TrialEndDate");
        }
    }

    public T Match<T>(
        Func<TrialEndDateVariants::DateTime, T> @dateTime,
        Func<TrialEndDateVariants::UnionMember1, T> unionMember1
    )
    {
        return this switch
        {
            TrialEndDateVariants::DateTime inner => @dateTime(inner),
            TrialEndDateVariants::UnionMember1 inner => unionMember1(inner),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of TrialEndDate"
            ),
        };
    }

    public abstract void Validate();
}

sealed class TrialEndDateConverter : JsonConverter<TrialEndDate>
{
    public override TrialEndDate? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new TrialEndDateVariants::UnionMember1(
                JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant TrialEndDateVariants::UnionMember1",
                    e
                )
            );
        }

        try
        {
            return new TrialEndDateVariants::DateTime(
                JsonSerializer.Deserialize<DateTime>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant TrialEndDateVariants::DateTime",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrialEndDate value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            TrialEndDateVariants::DateTime(var @dateTime) => @dateTime,
            TrialEndDateVariants::UnionMember1(var unionMember1) => unionMember1,
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of TrialEndDate"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
