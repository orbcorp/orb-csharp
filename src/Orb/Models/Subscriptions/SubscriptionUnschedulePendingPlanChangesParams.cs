using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to unschedule any pending plan changes on an existing
/// subscription. When called, all upcoming plan changes will be unscheduled.
/// </summary>
public sealed record class SubscriptionUnschedulePendingPlanChangesParams : ParamsBase
{
    public string? SubscriptionID { get; init; }

    public SubscriptionUnschedulePendingPlanChangesParams() { }

    public SubscriptionUnschedulePendingPlanChangesParams(
        SubscriptionUnschedulePendingPlanChangesParams subscriptionUnschedulePendingPlanChangesParams
    )
        : base(subscriptionUnschedulePendingPlanChangesParams)
    {
        this.SubscriptionID = subscriptionUnschedulePendingPlanChangesParams.SubscriptionID;
    }

    public SubscriptionUnschedulePendingPlanChangesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUnschedulePendingPlanChangesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionUnschedulePendingPlanChangesParams FromRawUnchecked(
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
                + string.Format(
                    "/subscriptions/{0}/unschedule_pending_plan_changes",
                    this.SubscriptionID
                )
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
