using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateProperties;

namespace Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties;

/// <summary>
/// The new date that the trial should end, or the literal string `immediate` to end
/// the trial immediately.
/// </summary>
[JsonConverter(typeof(TrialEndDateConverter))]
public record class TrialEndDate
{
    public object Value { get; private init; }

    public TrialEndDate(DateTime value)
    {
        Value = value;
    }

    public TrialEndDate(ApiEnum<string, UnionMember1> value)
    {
        Value = value;
    }

    TrialEndDate(UnknownVariant value)
    {
        Value = value;
    }

    public static TrialEndDate CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickDateTime([NotNullWhen(true)] out DateTime? value)
    {
        value = this.Value as DateTime?;
        return value != null;
    }

    public bool TryPickUnionMember1([NotNullWhen(true)] out ApiEnum<string, UnionMember1>? value)
    {
        value = this.Value as ApiEnum<string, UnionMember1>?;
        return value != null;
    }

    public void Switch(
        Action<DateTime> @dateTime,
        Action<ApiEnum<string, UnionMember1>> unionMember1
    )
    {
        switch (this.Value)
        {
            case DateTime value:
                @dateTime(value);
                break;
            case ApiEnum<string, UnionMember1> value:
                unionMember1(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of TrialEndDate");
        }
    }

    public T Match<T>(
        Func<DateTime, T> @dateTime,
        Func<ApiEnum<string, UnionMember1>, T> unionMember1
    )
    {
        return this.Value switch
        {
            DateTime value => @dateTime(value),
            ApiEnum<string, UnionMember1> value => unionMember1(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of TrialEndDate"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of TrialEndDate");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
            return new TrialEndDate(
                JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(ref reader, options)
            );
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'ApiEnum<string, UnionMember1>'",
                    e
                )
            );
        }

        try
        {
            return new TrialEndDate(JsonSerializer.Deserialize<DateTime>(ref reader, options));
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
        TrialEndDate value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
