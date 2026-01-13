using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to clear scheduled updates to the quantity for a fixed fee.
///
/// <para>If there are no updates scheduled, a request validation error will be returned
/// with a 400 status code.</para>
/// </summary>
public sealed record class SubscriptionUnscheduleFixedFeeQuantityUpdatesParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    /// <summary>
    /// Price for which the updates should be cleared. Must be a fixed fee.
    /// </summary>
    public required string PriceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("price_id");
        }
        init { this._rawBodyData.Set("price_id", value); }
    }

    public SubscriptionUnscheduleFixedFeeQuantityUpdatesParams() { }

    public SubscriptionUnscheduleFixedFeeQuantityUpdatesParams(
        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams subscriptionUnscheduleFixedFeeQuantityUpdatesParams
    )
        : base(subscriptionUnscheduleFixedFeeQuantityUpdatesParams)
    {
        this.SubscriptionID = subscriptionUnscheduleFixedFeeQuantityUpdatesParams.SubscriptionID;

        this._rawBodyData = new(subscriptionUnscheduleFixedFeeQuantityUpdatesParams._rawBodyData);
    }

    public SubscriptionUnscheduleFixedFeeQuantityUpdatesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUnscheduleFixedFeeQuantityUpdatesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionUnscheduleFixedFeeQuantityUpdatesParams FromRawUnchecked(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/subscriptions/{0}/unschedule_fixed_fee_quantity_updates",
                    this.SubscriptionID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
