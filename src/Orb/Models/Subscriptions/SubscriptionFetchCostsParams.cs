using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint is used to fetch a day-by-day snapshot of a subscription's costs
/// in Orb, calculated by applying pricing information to the underlying usage (see
/// the [subscription usage endpoint](fetch-subscription-usage) to fetch usage per
/// metric, in usage units rather than a currency).
///
/// <para>The semantics of this endpoint exactly mirror those of [fetching a customer's
/// costs](fetch-customer-costs). Use this endpoint to limit your analysis of costs
/// to a specific subscription for the customer (e.g. to de-aggregate costs when
/// a customer's subscription has started and stopped on the same day).</para>
/// </summary>
public sealed record class SubscriptionFetchCostsParams : ParamsBase
{
    public string? SubscriptionID { get; init; }

    /// <summary>
    /// The currency or custom pricing unit to use.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("currency");
        }
        init { this._rawQueryData.Set("currency", value); }
    }

    /// <summary>
    /// Costs returned are exclusive of `timeframe_end`.
    /// </summary>
    public System::DateTimeOffset? TimeframeEnd
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("timeframe_end");
        }
        init { this._rawQueryData.Set("timeframe_end", value); }
    }

    /// <summary>
    /// Costs returned are inclusive of `timeframe_start`.
    /// </summary>
    public System::DateTimeOffset? TimeframeStart
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("timeframe_start");
        }
        init { this._rawQueryData.Set("timeframe_start", value); }
    }

    /// <summary>
    /// Controls whether Orb returns cumulative costs since the start of the billing
    /// period, or incremental day-by-day costs. If your customer has minimums or
    /// discounts, it's strongly recommended that you use the default cumulative behavior.
    /// </summary>
    public ApiEnum<string, ViewMode>? ViewMode
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, ViewMode>>("view_mode");
        }
        init { this._rawQueryData.Set("view_mode", value); }
    }

    public SubscriptionFetchCostsParams() { }

    public SubscriptionFetchCostsParams(SubscriptionFetchCostsParams subscriptionFetchCostsParams)
        : base(subscriptionFetchCostsParams)
    {
        this.SubscriptionID = subscriptionFetchCostsParams.SubscriptionID;
    }

    public SubscriptionFetchCostsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionFetchCostsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionFetchCostsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/costs", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
/// Controls whether Orb returns cumulative costs since the start of the billing
/// period, or incremental day-by-day costs. If your customer has minimums or discounts,
/// it's strongly recommended that you use the default cumulative behavior.
/// </summary>
[JsonConverter(typeof(ViewModeConverter))]
public enum ViewMode
{
    Periodic,
    Cumulative,
}

sealed class ViewModeConverter : JsonConverter<ViewMode>
{
    public override ViewMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "periodic" => ViewMode.Periodic,
            "cumulative" => ViewMode.Cumulative,
            _ => (ViewMode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, ViewMode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewMode.Periodic => "periodic",
                ViewMode.Cumulative => "cumulative",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
