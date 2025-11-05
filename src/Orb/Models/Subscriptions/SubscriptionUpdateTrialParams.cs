using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint is used to update the trial end date for a subscription. The new
/// trial end date must be within the time range of the current plan (i.e. the new
/// trial end date must be on or after the subscription's start date on the current
/// plan, and on or before the subscription end date).
///
/// In order to retroactively remove a trial completely, the end date can be set to
/// the transition date of the subscription to this plan (or, if this is the first
/// plan for this subscription, the subscription's start date). In order to end a
/// trial immediately, the keyword `immediate` can be provided as the trial end date.
///
/// By default, Orb will shift only the trial end date (and price intervals that start
/// or end on the previous trial end date), and leave all other future price intervals
/// untouched. If the `shift` parameter is set to `true`, Orb will shift all subsequent
/// price and adjustment intervals by the same amount as the trial end date shift
/// (so, e.g., if a plan change is scheduled or an add-on price was added, that change
/// will be pushed back by the same amount of time the trial is extended).
/// </summary>
public sealed record class SubscriptionUpdateTrialParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string SubscriptionID { get; init; }

    /// <summary>
    /// The new date that the trial should end, or the literal string `immediate`
    /// to end the trial immediately.
    /// </summary>
    public required TrialEndDate TrialEndDate
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("trial_end_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'trial_end_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "trial_end_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<TrialEndDate>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'trial_end_date' cannot be null",
                    new System::ArgumentNullException("trial_end_date")
                );
        }
        init
        {
            this._bodyProperties["trial_end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, shifts subsequent price and adjustment intervals (preserving their
    /// durations, but adjusting their absolute dates).
    /// </summary>
    public bool? Shift
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("shift", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["shift"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionUpdateTrialParams() { }

    public SubscriptionUpdateTrialParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUpdateTrialParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static SubscriptionUpdateTrialParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/update_trial", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// The new date that the trial should end, or the literal string `immediate` to end
/// the trial immediately.
/// </summary>
[JsonConverter(typeof(TrialEndDateConverter))]
public record class TrialEndDate
{
    public object Value { get; private init; }

    public TrialEndDate(System::DateTime value)
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

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTime? value)
    {
        value = this.Value as System::DateTime?;
        return value != null;
    }

    public bool TryPickUnionMember1([NotNullWhen(true)] out ApiEnum<string, UnionMember1>? value)
    {
        value = this.Value as ApiEnum<string, UnionMember1>?;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateTime> @dateTime,
        System::Action<ApiEnum<string, UnionMember1>> unionMember1
    )
    {
        switch (this.Value)
        {
            case System::DateTime value:
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
        System::Func<System::DateTime, T> @dateTime,
        System::Func<ApiEnum<string, UnionMember1>, T> unionMember1
    )
    {
        return this.Value switch
        {
            System::DateTime value => @dateTime(value),
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
        System::Type typeToConvert,
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
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
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
            return new TrialEndDate(
                JsonSerializer.Deserialize<System::DateTime>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTime'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
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

[JsonConverter(typeof(UnionMember1Converter))]
public enum UnionMember1
{
    Immediate,
}

sealed class UnionMember1Converter : JsonConverter<UnionMember1>
{
    public override UnionMember1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediate" => UnionMember1.Immediate,
            _ => (UnionMember1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember1.Immediate => "immediate",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
