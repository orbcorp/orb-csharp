using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint returns a [paginated](/api-reference/pagination) list of all plans
/// associated with a subscription along with their start and end dates. This list
/// contains the subscription's initial plan along with past and future plan changes.
/// </summary>
public sealed record class SubscriptionFetchScheduleParams : ParamsBase
{
    public string? SubscriptionID { get; init; }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "cursor"); }
        init { JsonModel.Set(this._rawQueryData, "cursor", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "limit", value);
        }
    }

    public DateTimeOffset? StartDateGt
    {
        get
        {
            return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawQueryData, "start_date[gt]");
        }
        init { JsonModel.Set(this._rawQueryData, "start_date[gt]", value); }
    }

    public DateTimeOffset? StartDateGte
    {
        get
        {
            return JsonModel.GetNullableStruct<DateTimeOffset>(
                this.RawQueryData,
                "start_date[gte]"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "start_date[gte]", value); }
    }

    public DateTimeOffset? StartDateLt
    {
        get
        {
            return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawQueryData, "start_date[lt]");
        }
        init { JsonModel.Set(this._rawQueryData, "start_date[lt]", value); }
    }

    public DateTimeOffset? StartDateLte
    {
        get
        {
            return JsonModel.GetNullableStruct<DateTimeOffset>(
                this.RawQueryData,
                "start_date[lte]"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "start_date[lte]", value); }
    }

    public SubscriptionFetchScheduleParams() { }

    public SubscriptionFetchScheduleParams(
        SubscriptionFetchScheduleParams subscriptionFetchScheduleParams
    )
        : base(subscriptionFetchScheduleParams)
    {
        this.SubscriptionID = subscriptionFetchScheduleParams.SubscriptionID;
    }

    public SubscriptionFetchScheduleParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionFetchScheduleParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionFetchScheduleParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/schedule", this.SubscriptionID)
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
