using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Plans.ExternalPlanID;

/// <summary>
/// This endpoint is used to fetch [plan](/core-concepts##plan-and-price) details
/// given an external_plan_id identifier. It returns information about the prices
/// included in the plan and their configuration, as well as the product that the
/// plan is attached to.
///
/// <para>If multiple plans are found to contain the specified external_plan_id,
/// the active plans will take priority over archived ones, and among those, the endpoint
/// will return the most recently created plan.</para>
///
/// <para>## Serialized prices Orb supports a few different pricing models out of
/// the box. Each of these models is serialized differently in a given [Price](/core-concepts#plan-and-price)
/// object. The `model_type` field determines the key for the configuration object
/// that is present. A detailed explanation of price types can be found in the [Price
/// schema](/core-concepts#plan-and-price). "</para>
/// </summary>
public sealed record class ExternalPlanIDFetchParams : ParamsBase
{
    public string? ExternalPlanID { get; init; }

    public ExternalPlanIDFetchParams() { }

    public ExternalPlanIDFetchParams(ExternalPlanIDFetchParams externalPlanIDFetchParams)
        : base(externalPlanIDFetchParams)
    {
        this.ExternalPlanID = externalPlanIDFetchParams.ExternalPlanID;
    }

    public ExternalPlanIDFetchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalPlanIDFetchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ExternalPlanIDFetchParams FromRawUnchecked(
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
                + string.Format("/plans/external_plan_id/{0}", this.ExternalPlanID)
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
