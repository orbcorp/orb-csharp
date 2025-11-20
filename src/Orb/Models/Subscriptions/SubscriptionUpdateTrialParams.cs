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
/// <para>In order to retroactively remove a trial completely, the end date can be
/// set to the transition date of the subscription to this plan (or, if this is the
/// first plan for this subscription, the subscription's start date). In order to
/// end a trial immediately, the keyword `immediate` can be provided as the trial
/// end date.</para>
///
/// <para>By default, Orb will shift only the trial end date (and price intervals
/// that start or end on the previous trial end date), and leave all other future
/// price intervals untouched. If the `shift` parameter is set to `true`, Orb will
/// shift all subsequent price and adjustment intervals by the same amount as the
/// trial end date shift (so, e.g., if a plan change is scheduled or an add-on price
/// was added, that change will be pushed back by the same amount of time the trial
/// is extended).</para>
/// </summary>
public sealed record class SubscriptionUpdateTrialParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    /// <summary>
    /// The new date that the trial should end, or the literal string `immediate`
    /// to end the trial immediately.
    /// </summary>
    public required TrialEndDate TrialEndDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("trial_end_date", out JsonElement element))
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
            this._rawBodyData["trial_end_date"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("shift", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["shift"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionUpdateTrialParams() { }

    public SubscriptionUpdateTrialParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUpdateTrialParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static SubscriptionUpdateTrialParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/update_trial", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// The new date that the trial should end, or the literal string `immediate` to
/// end the trial immediately.
/// </summary>
[JsonConverter(typeof(TrialEndDateConverter))]
public record class TrialEndDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public TrialEndDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TrialEndDate(ApiEnum<string, UnionMember1> value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TrialEndDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDateTimeOffset([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public bool TryPickUnionMember1([NotNullWhen(true)] out ApiEnum<string, UnionMember1>? value)
    {
        value = this.Value as ApiEnum<string, UnionMember1>?;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateTimeOffset> @dateTimeOffset,
        System::Action<ApiEnum<string, UnionMember1>> unionMember1
    )
    {
        switch (this.Value)
        {
            case System::DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            case ApiEnum<string, UnionMember1> value:
                unionMember1(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of TrialEndDate");
        }
    }

    public T Match<T>(
        System::Func<System::DateTimeOffset, T> @dateTimeOffset,
        System::Func<ApiEnum<string, UnionMember1>, T> unionMember1
    )
    {
        return this.Value switch
        {
            System::DateTimeOffset value => @dateTimeOffset(value),
            ApiEnum<string, UnionMember1> value => unionMember1(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of TrialEndDate"
            ),
        };
    }

    public static implicit operator TrialEndDate(System::DateTimeOffset value) => new(value);

    public static implicit operator TrialEndDate(ApiEnum<string, UnionMember1> value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of TrialEndDate");
        }
    }
}

sealed class TrialEndDateConverter : JsonConverter<TrialEndDate>
{
    public override TrialEndDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrialEndDate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
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
